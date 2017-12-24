
"%~dp0NuGet.exe" pack "..\ISC.Whitest.Core\ISC.Whitest.Core.csproj" -Prop Configuration=debug -Version 0.0.1.0

copy "%~dp0*.nupkg" "%localappdata%\NuGet\Cache"
copy "%~dp0*.nupkg" "\\MR27\wwwroot\Nuget portal Publish\Packages"
pause
