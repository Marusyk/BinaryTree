// ARGUMENTS
var target = Argument("Target", "Default");
var configuration = Argument("Configuration", "Release");
var nugetApiKey = Argument("NugetApiKey", "");

// GLOBAL VARIABLES
var artifactsDirectory = Directory("./artifacts");
var solutionFile = "./BinaryTree.sln";
var solutionFileBackup = solutionFile + ".build.backup";
var isRunningOnWindows = IsRunningOnWindows();
var IsOnAppVeyorAndNotPR = AppVeyor.IsRunningOnAppVeyor && !AppVeyor.Environment.PullRequest.IsPullRequest;

Setup(_ =>
{
    StartProcess("dotnet", new ProcessSettings { Arguments = "--info" });
    if(!isRunningOnWindows)
    {
        StartProcess("mono", new ProcessSettings { Arguments = "--version" });
        
        // create solution backup
        CopyFile(solutionFile, solutionFileBackup);
    }
});

Teardown(_ =>
{
    if(!isRunningOnWindows && BuildSystem.IsLocalBuild)
    {
        if(FileExists(solutionFileBackup)) // Revert back solution file
        {
            DeleteFile(solutionFile);
            MoveFile(solutionFileBackup, solutionFile);
        } 
    }
});

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(artifactsDirectory);

        if(BuildSystem.IsLocalBuild)
        {
            CleanDirectories(GetDirectories("./**/obj") + GetDirectories("./**/bin"));
        }
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore(solutionFile);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var buildSettings = new MSBuildSettings()
            .SetConfiguration(configuration)
            .WithTarget("Rebuild")
            .SetVerbosity(Verbosity.Minimal)
            .UseToolVersion(MSBuildToolVersion.Default)
            .SetMSBuildPlatform(MSBuildPlatform.Automatic)
            .SetPlatformTarget(PlatformTarget.MSIL) // Any CPU
            .SetNodeReuse(true);

        if(!isRunningOnWindows)
        {
            // hack for Linux bug - missing MSBuild path
            if(new CakePlatform().Family == PlatformFamily.Linux)
            {
                var monoVersion = GetMonoVersionMoniker();
                var isMSBuildSupported = monoVersion != null && System.Text.RegularExpressions.Regex.IsMatch(monoVersion,@"([5-9]|\d{2,})\.\d+\.\d+(\.\d+)?");
                if(isMSBuildSupported)
                {
                    buildSettings.ToolPath = new FilePath(@"/usr/lib/mono/msbuild/15.0/bin/MSBuild.dll");
                    Information(string.Format("Mono supports MSBuild. Override ToolPath value with `{0}`", buildSettings.ToolPath));
                }
            }
        }

        var path = MakeAbsolute(new DirectoryPath(solutionFile));
        MSBuild(path.FullPath, buildSettings);
    });

Task("Test")  
    .IsDependentOn("Build")
    .Does(() =>
    {
        var projectFile = GetFiles("./**/BinaryTreeTest.csproj");
        DotNetCoreTest(projectFile.First().FullPath, new DotNetCoreTestSettings()
        {
            Configuration = configuration
        });
    });

Task("Pack")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var settings = new DotNetCorePackSettings
        {
            Configuration = configuration,
            OutputDirectory = artifactsDirectory
        };

        var projects = GetFiles("./src/**/*.csproj");
        foreach(var project in projects)
        {
            DotNetCorePack(project.FullPath, settings);
        }
    });

Task("Publish")
    .IsDependentOn("Pack")
    .WithCriteria(IsOnAppVeyorAndNotPR || !string.IsNullOrEmpty(nugetApiKey))
    .Does(() =>
    {
        var dir = string.Concat(artifactsDirectory, @"\*.nupkg");
        NuGetPush(GetFiles(dir).First(), new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = nugetApiKey
        });
    });

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Pack")
    .IsDependentOn("Publish");

RunTarget(target);

// HELPERS

private string GetMonoVersionMoniker()
{
    var type = Type.GetType("Mono.Runtime");
    if (type != null)
    {
        var displayName = type.GetMethod("GetDisplayName", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        if (displayName != null)
        {
            return displayName.Invoke(null, null).ToString();
        }
    }
    return null;
}
