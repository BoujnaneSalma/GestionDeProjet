using GestionPrj.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GestionPrj.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {

        }

        public DbSet<Projet> Projets { get; set; }
        public DbSet<RScrum> RScrums { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Tache> Taches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStory> UserStories { get; set; }
        public DbSet<UserReunion> UserReunions { get; set;}
        public DbSet<UserProjet> UserProjets { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ... votre configuration existante ...

            // Configuration pour la shadow property SprintId
            modelBuilder.Entity<UserStory>().Property<int?>("SprintId");

            // ... toute autre configuration ...
        }

    }
}
