#addin nuget:?package=Cake.Coveralls&version=1.0.0
#addin nuget:?package=Cake.Coverlet&version=2.5.4

#tool nuget:?package=coveralls.io&version=1.4.2

var target = Argument("Target", "Default");
var configuration = Argument("Configuration", "Release");

var coverallsRepoToken = EnvironmentVariable("COVERALLS_REPO_TOKEN");
var nugetApiKey = EnvironmentVariable("NUGET_API_KEY");
var nugetApiUrl = EnvironmentVariable("NUGET_API_URL");

DirectoryPath artifactsDirectory = Directory("./artifacts");
var projectFile = File("./src/BinaryTree/BinaryTree.csproj");
var testResultsDir = artifactsDirectory.Combine("test-results");
var testCoverageOutputFilePath = testResultsDir.CombineWithFilePath("OpenCover.xml");

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(artifactsDirectory);
        CleanDirectories(GetDirectories("./**/obj") + GetDirectories("./**/bin"));
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore(projectFile);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
       DotNetCoreBuild(projectFile, new DotNetCoreBuildSettings
       { 
           Configuration = configuration,
           NoRestore = true,
           NoLogo = true
       });  
    });

Task("Test")  
    .IsDependentOn("Build")
    .Does(() =>
    {
        var settings = new DotNetCoreTestSettings
        {
            Configuration = configuration,
            NoLogo = true
        };

        DotNetCoreTest("./tests/BinaryTreeTest/BinaryTreeTest.csproj", settings, new CoverletSettings
            {
                CollectCoverage = true,
                CoverletOutputFormat = CoverletOutputFormat.opencover,
                CoverletOutputDirectory = testResultsDir,
                CoverletOutputName = testCoverageOutputFilePath.GetFilename().ToString()
            });
    });
    
Task("UploadTestReport")
    .IsDependentOn("Test")
    .WithCriteria((context) => FileExists(testCoverageOutputFilePath))
    .WithCriteria(!string.IsNullOrWhiteSpace(coverallsRepoToken))
    .Does(() =>
  {
      CoverallsIo(testCoverageOutputFilePath, new CoverallsIoSettings
      {
          RepoToken = coverallsRepoToken,
          Debug = true
      });
  });

Task("NuGetPack")
    .IsDependentOn("UploadTestReport")
    .Does(() =>
    {
        DotNetCorePack(projectFile, new DotNetCorePackSettings
        {
            Configuration = configuration,
            NoRestore = true,
            NoBuild = true,
            NoLogo = true,
            OutputDirectory = artifactsDirectory
        });
    });

Task("NuGetPush")
    .IsDependentOn("NuGetPack")
    .WithCriteria(!string.IsNullOrWhiteSpace(nugetApiUrl))
    .WithCriteria(!string.IsNullOrWhiteSpace(nugetApiKey))
    .Does(() =>
    {
        DotNetCoreNuGetPush(artifactsDirectory.CombineWithFilePath("*.nupkg").FullPath, new DotNetCoreNuGetPushSettings
        {
            Source = nugetApiUrl,
            ApiKey = nugetApiKey
        });
    });

Task("Default")
    .IsDependentOn("Test");

RunTarget(target);