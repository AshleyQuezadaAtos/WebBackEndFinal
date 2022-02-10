def namespace=      "courses"
def appName=        "courses-service"
def deploy=         "courses-srv-depl"
def image=          "egonzalezatos/courses"
def k8s_path=       "./devops/Kubernetes"

pipeline {

    agent any 
    stages {
        stage('Greetings') {
            steps {
                echo 'Hello world!' 
            }
        }
        stage('Build') {
            steps {
                bat "dotnet restore"
                bat "dotnet clean"
                bat "dotnet publish -c Release -o out"
                bat "docker build -t ${image} . -f ./devops/Docker/Dockerfile"
            }
        }
        stage('Push') {
            steps {
                bat "docker push ${image}"
            }
        }
        stage('Sonar Coverage') {
            steps {
                bat "docker push ${image}"
            }
        }
        stage('Deployment') {
            steps {
                bat "kubectl get ns ${namespace} || kubectl create ns ${namespace}"   
                bat "kubectl --namespace=${namespace} delete deploy ${deploy} || (exit 0)" 
                bat "kubectl --namespace=${namespace} apply -f ${k8s_path}/${namespace}-srv-depl.yml"    
            }
        }
    }
}
