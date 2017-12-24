#tool "nuget:?package=xunit.runner.console"

var target = Argument("target", "Default");
var configuration = Argument("Configuration", "Release");
var solutionPath = Argument("SolutionPath", "../ISC.Whitest.sln");

if (String.IsNullOrEmpty(solutionPath)) throw new Exception("argument 'SolutionPath' is not provided");

Task("Clean")
    .Does(() =>
{
    CleanDirectories(string.Format("../**/obj/{0}",configuration));
    CleanDirectories(string.Format("../**/bin/{0}",configuration));
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solutionPath);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(()=>
{

    MSBuild(solutionPath, configurator =>
        configurator.SetConfiguration(configuration)
            .SetVerbosity(Verbosity.Minimal)
            .UseToolVersion(MSBuildToolVersion.VS2015)
            .SetMSBuildPlatform(MSBuildPlatform.x86)
            .SetPlatformTarget(PlatformTarget.MSIL));
});

Task("Run-Tests")
    .IsDependentOn("Build")
    .Does(()=>
{
    XUnit2("../**/*.Tests*.dll");
});


Task("Default").IsDependentOn("Run-Tests");

RunTarget(target);