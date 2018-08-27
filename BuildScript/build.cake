#tool "nuget:?package=xunit.runner.console"
#addin "NuGet.Core"
#addin nuget:?package=System.Threading.Tasks.Dataflow&version=4.5.24
#r "References/CSProjectHelpers.dll"
#r "References/Microsoft.Build.dll"

var target = Argument("target", "Default");
var configuration = Argument("Configuration", "Release");
var solutionPath = Argument("SolutionPath", "../Code/Netsa.Whitest/ISC.Whitest.sln");
var buildVersion = Argument("BuildVersion", "0");
var nugetServerUrl = Argument("NugetServerUrl","https://www.myget.org/F/isc-feed/api/v2/package");
var nugetApiKey = Argument("NugetApiKey","a03fe7c7-f8b0-4f4a-8f7b-768e1347cdbe");


if (String.IsNullOrEmpty(solutionPath)) throw new Exception("argument 'SolutionPath' is not provided");

var tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(),"ISC_" + Guid.NewGuid().ToString().Replace("-","") + @"\");
System.IO.Directory.CreateDirectory(tempPath);
Console.WriteLine("Temp path is " + tempPath);

if (buildVersion == "0"){
    var appVeyorBuildNumber = EnvironmentVariable("APPVEYOR_BUILD_NUMBER");
    if (appVeyorBuildNumber != null){
        buildVersion = appVeyorBuildNumber;
    }
}

Task("Clean")
    .Does(() =>
{
    CleanDirectories(string.Format("../**/obj/{0}",configuration));
    CleanDirectories(string.Format("../**/bin/{0}",configuration));
});

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    NuGetRestore(solutionPath);
});

Task("Build")
    .Does(()=>
{

    DotNetBuild(solutionPath, settings =>
        settings.SetConfiguration(configuration)
            .WithTarget("Build"));
});

// Task("Run-Tests")
//      .IsDependentOn("Build")
//      .Does(()=>
//  {
//      var pathForTests = "../**/bin/" + configuration + "/*.Tests*.dll";
//      XUnit2(pathForTests);
//  });

Task("Create-Nuget-Packages")
    .Does(() =>
{
    var parsedSolution = ParseSolution(solutionPath);
    var candidateProjects = parsedSolution.Projects
                    .Where(a=>a.Name.StartsWith("ISC.Whitest") && !a.Name.EndsWith("Tests"))
                    .ToList();

    var allDependencies = new List<NuGet.PackageReference>();
    foreach(var project in candidateProjects){
        var directory = System.IO.Path.GetDirectoryName(project.Path.ToString());
        var directoryPath = new DirectoryPath(directory);
        var filePath = directoryPath.CombineWithFilePath(new FilePath("packages.config"));
        var dependencies = new NuGet.PackageReferenceFile(filePath.FullPath).GetPackageReferences();
        allDependencies.AddRange(dependencies);
    }

    var consolidateDependencies = allDependencies
                        .GroupBy(a=> new {a.Id, a.Version}, (key,value)=> new {key,value})
                        .GroupBy(a=>a.key.Id, (key, value)=> new {id= key, count = value.Count()})
                        .Where(a=>a.count > 1)
                        .ToList();

    if (consolidateDependencies.Count() > 0)
    {
        foreach(var package in consolidateDependencies){
            Error("Consolidate dependencies found : " + package.id.ToString());
        }
        throw new Exception("Consolidate dependencies found");
    }
    
    var nugetDependencies = allDependencies
                    .GroupBy(p => p.Id)
                    .Select(g => g.First())
                    .Select(a=> new NuSpecDependency()
                    {
                        Version = a.Version.ToString(),
                        Id = a.Id,
                    }).ToList();
    var nuGetPackSettings = new NuGetPackSettings
	{
        Id= "ISC.Whitest",
        Authors = new List<string>(){ "H.Ahmadi","M.Eydimorad"},
        Description ="Unit, Integration and Acceptance testing framework based on Selenium and Specflow",
		OutputDirectory = tempPath,
        Dependencies = nugetDependencies,
		Properties = new Dictionary<string, string>
		{
			{ "Configuration", "Release" }
		},
        Version= string.Format("1.0.{0}", buildVersion),
	};
    
    var files = new List<NuSpecContent>();
    var paths = candidateProjects.Select(a=> a.Path).ToList();
    foreach(var p in paths){
        var dllPath = CSProjectHelpers.ProjectParser.GetDllPathForProject(p.ToString(),"Release");
        files.Add(new NuSpecContent()
                {
                    Source = dllPath,
                    Target = @"lib\net451"
                });
    }
    nuGetPackSettings.Files = files;

    NuGetPack(nuGetPackSettings);
});

 Task("Push-Nuget-Packages")
.Does(() =>
{
     var files = System.IO.Directory.GetFiles(tempPath, "*.nupkg")
                                        .Select(z => new FilePath(z)).ToList();

    foreach(var f in files){
        Console.WriteLine(f);
    }
                    var settings = new NuGetPushSettings()
                    {
                        Source = nugetServerUrl,
                        ApiKey = nugetApiKey,
                    };
    NuGetPush(files, settings);
});

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("Build")
    .IsDependentOn("Create-Nuget-Packages")
    .IsDependentOn("Push-Nuget-Packages");

RunTarget(target);