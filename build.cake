#load build/package.cake
#load build/paths.cake
#load build/version.cake

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Setup<PackageMetadata>(context =>
    new PackageMetadata(
        outputDirectory: Argument("packageOutputPath", "dist"),
        version: Argument("packageVersion", string.Empty),
        name: "NuFind")
);

Task("Clean")
    .Does<PackageMetadata>(package =>
{
    CleanDirectory(package.OutputDirectory);
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
    .Does<PackageMetadata>(package =>
{
    if (string.IsNullOrEmpty(package.Version))
    {
        package.Version = GetVersionFromProjectFile(Context, Paths.ProjectFile);
        Information($"Determined version {package.Version} from the project file");
    }
    else
    {
        Information($"Using version {package.Version} specified as argument");
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
    .Does<PackageMetadata>(package =>
{
    DotNetCorePack(
        Paths.ProjectFile.FullPath,
        new DotNetCorePackSettings
        {
            OutputDirectory = package.OutputDirectory,
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
