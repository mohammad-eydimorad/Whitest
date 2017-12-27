#tool "nuget:?package=xunit.runner.console"

var target = Argument("target", "Default");
var configuration = Argument("Configuration", "Release");
var solutionPath = Argument("SolutionPath", "../ISC.Whitest.sln");
var buildVersion = Argument("BuildVersion", "0");

if (String.IsNullOrEmpty(solutionPath)) throw new Exception("argument 'SolutionPath' is not provided");

if (TFBuild.IsRunningOnVSTS || TFBuild.IsRunningOnTFS){
    buildVersion = TFBuild.Environment.Build.Number;
}

var tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(),"ISC_" + Guid.NewGuid().ToString().Replace("-","") + @"\");
System.IO.Directory.CreateDirectory(tempPath);
Console.WriteLine("Temp path is " + tempPath);

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
            .UseToolVersion(MSBuildToolVersion.VS2017)
            .SetMSBuildPlatform(MSBuildPlatform.x86)
            .SetPlatformTarget(PlatformTarget.MSIL));
});

// Task("Run-Tests")
//     .IsDependentOn("Build")
//     .Does(()=>
// {
//     XUnit2("../**/*.Tests*.dll");
// });

// Task("Create-Nuget-Packages")
//     .IsDependentOn("Build")
//     .Does(()=>{

//     var nuGetPackSettings = new NuGetPackSettings
// 	{
//         Authors = new List<string>(){ "H.Ahmadi"},
// 		OutputDirectory = tempPath,
// 		IncludeReferencedProjects = true,
// 		Properties = new Dictionary<string, string>
// 		{
// 			{ "Configuration", "Release" }
// 		},
//         Version= string.Format("1.0.0.{0}-alpha", buildVersion),
// 	};

//     NuGetPack(@"../ISC.Whitest.Web.Api/ISC.Whitest.Web.Api.csproj", nuGetPackSettings);
//     NuGetPack(@"../ISC.Whitest.Web.UI/ISC.Whitest.Web.UI.csproj", nuGetPackSettings);
//     NuGetPack(@"../ISC.Whitest.Core/ISC.Whitest.Core.csproj", nuGetPackSettings);
// });

//  Task("Push-Nuget-Packages")
// .IsDependentOn("Create-Nuget-Packages")
// .Does(() =>
// {
    //  var files = System.IO.Directory.GetFiles(tempPath, "*.nupkg")
    //                                     .Select(z => new FilePath(z)).ToList();

    // foreach(var f in files){
    //     Console.WriteLine(f);
    // }
    //                 var settings = new NuGetPushSettings()
    //                 {
    //                     Source = nugetServerUrl,
    //                     ApiKey = nugetApiKey,
    //                 };

   

    // NuGetPush(files, settings);
// });

Task("Default").IsDependentOn("Build");

RunTarget(target);