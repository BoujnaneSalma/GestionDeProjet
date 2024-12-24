pipeline {
    agent any
    
    stages {
        stage('Clone Repository') {
            steps {
                git branch: 'main', url: 'https://github.com/BoujnaneSalma/GestionDeProjet.git'
            }
        }
        stage('Restore Dependencies') {
            steps {
                sh 'dotnet restore'
            }
        }
        stage('Build Project') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }
        stage('Run Tests') {
            steps {
                sh 'dotnet test'
            }
        }
        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o ./publish'
            }
        }
    }
}
