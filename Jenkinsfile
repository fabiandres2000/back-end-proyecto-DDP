node {

  stage('Checkout') {
     url: 'git@github.com:fabiandres2000/back-end-proyecto-DDP.git',branch: 'master'
  }
  //SignusFinanciero.sln
  stage ('Restore Nuget') {
  bat "dotnet restore ExampleDdd.sln"
  }
  
  stage('Clean') {
    bat 'dotnet clean ExampleDdd.sln'
  }
  
  stage('Build') {
    bat 'dotnet build ExampleDdd.sln --configuration Release'
  }

  stage ('Test') {
    bat "dotnet test Domain.Test/Domain.Test.csproj --logger trx;LogFileName=unit_tests.trx"
    bat "dotnet test Domain.Test/Aplication.Test.csproj --logger trx;LogFileName=unit_tests.trx"
    mstest testResultsFile:"**/*.trx", keepLongStdio: true
  }
    

  stage('Publish') {
    bat 'dotnet publish WebApi/WebApi.csproj -c Release -o C:/Users/USUARIO/source/repos/back-end-proyecto-DDP'
  } 
  
}