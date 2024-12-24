pipeline {
    agent any
    
    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'master', url: 'https://github.com/BoujnaneSalma/GestionDeProjet.git'
            }
        }
        
        stage('Restore Dependencies') {
            steps {
                bat 'dotnet restore'
            }
        }
        
        stage('Build Project') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }
        
        stage('Run Tests') {
            steps {
                bat 'dotnet test'
            }
        }
        
        stage('Publish') {
            steps {
                bat 'dotnet publish --configuration Release'
            }
        }
    }
}