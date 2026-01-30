pipeline {

  agent none

  options {
    skipDefaultCheckout(true)
  }

  stages {

    stage('Checkout') {
      agent { label 'linux' }
      steps {
        checkout scm
        stash name: 'source', includes: 'src/**,k8s/**,Dockerfile,Jenkinsfile'
      }
    }

    stage('Build docker image (Windows)') {
      agent { label 'windows' }
      steps {
        unstash 'source'
        bat '''
          docker build ^
            -t k8syns/hello-world-windows:%BUILD_ID% ^
            -t k8syns/hello-world-windows:latest ^
            -f Dockerfile .
        '''
      }
    }

    stage('Push docker image') {
      agent { label 'windows' }
      steps {
        withDockerRegistry([credentialsId: 'dockerhub', url: '']) {
          bat '''
            docker push k8syns/hello-world-windows:%BUILD_ID%
            docker push k8syns/hello-world-windows:latest
          '''
        }
      }
    }

    stage('Deploy no Kubernetes') {
      agent { label 'linux' }
      environment {
        TAG_VERSION = "${BUILD_ID}"
      }
      steps {
        withKubeConfig([credentialsId: 'kubeconfig']) {
          sh '''
            sed "s/{{tag}}/${TAG_VERSION}/g" k8s/deployment.yaml | kubectl apply -f -
          '''
        }
      }
    }
  }
}
