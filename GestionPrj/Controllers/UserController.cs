using GestionPrj.Context;
using GestionPrj.Models;
using GestionPrj.service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace GestionPrj.Controllers
{
    public class UserController : Controller
    {
        MyContext db;
        public UserController(MyContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(User U, IFormFile MyImage)
        {
            
                if (MyImage != null && MyImage.Length > 0) // Check for null and empty file
                {
                    var imageUploader = new uplead(); // Assuming uplead is a class for image handling
                    var uploadedFileName = await imageUploader.UploadImageAsync(MyImage, Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img"));
                    U.Photo = uploadedFileName;
                
                    db.Users.Add(U);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            return View();
        }

        public IActionResult Index()
        {
            List<User> users = db.Users.Include(U => U.UserStories).Include(U => U.UProjets).ToList();

            // Hasher les mots de passe avant de les afficher
            foreach (var user in users)
            {
                user.Password = HashPasswordWithMD5(user.Password);
            }
            return View(users);

        }
        public static string HashPasswordWithMD5(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            
            User U = db.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(U);
        }
        [HttpPost]
        public async Task<IActionResult> Update(User U, IFormFile MyImage)
        {
            if (MyImage != null)
            {
                var randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(MyImage.FileName);
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
                string filePath = Path.Combine(uploadsFolder, randomFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await MyImage.CopyToAsync(fileStream);
                }
                U.Photo = randomFileName;
            }
            

            db.Users.Update(U);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
