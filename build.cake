#load build/paths.cake
#load build/version.cake

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var packageOutputDirectory = Argument("packageOutputDirectory", "dist");
var packageVersion = Argument("packageVersion", string.Empty);

Task("Clean")
    .Does(() =>
{
    CleanDirectory(packageOutputDirectory);
    CleanDirectories("**/bin");
    CleanDirectories("**/obj");
});

Task("Restore-Packages")
    .Does(() =>
{
    DotNetCoreRestore(Paths.SolutionFile.FullPath);
});

Task("Compile")
    .IsDependentOn("Restore-Packages")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration
    };

    DotNetCoreBuild(Paths.ProjectFile.FullPath, settings);
});

Task("Version")
    .Does(() =>
{
    if (string.IsNullOrEmpty(packageVersion))
    {
        packageVersion = GetVersionFromProjectFile(Context, Paths.ProjectFile);
        Information($"Determined version {packageVersion} from the project file");
    }
    else
    {
        SetVersionToProjectFile(Context, Paths.ProjectFile, packageVersion);
        Information($"Assigned version {packageVersion} to the project file");
    }
});

Task("Test")
    .IsDependentOn("Restore-Packages")
    .Does(() =>
{
    var settings = new DotNetCoreTestSettings
    {
        Configuration = configuration
    };

    DotNetCoreTest(Paths.TestProjectFile.FullPath, settings);
});

Task("Package")
    .IsDependentOn("Restore-Packages")
    .IsDependentOn("Version")
    .Does(() =>
{
    DotNetCorePack(
        Paths.ProjectFile.FullPath,
        new DotNetCorePackSettings
        {
            OutputDirectory = packageOutputDirectory,
            Configuration = configuration
        });
});

Task("Build")
    .IsDependentOn("Version")
    .IsDependentOn("Test")
    .IsDependentOn("Package");

Task("Default")
    .IsDependentOn("Test");

RunTarget(target);
