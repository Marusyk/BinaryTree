var target = Argument("Target", "Default");
var configuration = Argument("Configuration", "Release");

var nugetApiKey = EnvironmentVariable("NUGET_API_KEY");
var nugetApiUrl = EnvironmentVariable("NUGET_API_URL");

DirectoryPath artifactsDirectory = Directory("./artifacts");
var projectFile = File("./src/BinaryTree/BinaryTree.csproj");

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

        DotNetCoreTest("./tests/BinaryTreeTest/BinaryTreeTest.csproj", settings);
    });

Task("NuGetPack")
    .IsDependentOn("Test")
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