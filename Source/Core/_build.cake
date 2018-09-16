#addin nuget:?package=Cake.Git&version=0.19.0
#load "versioning.cake"
#load "globals.cake"

var target = Argument("target", "Default");

/*

- Copy entire folder from /repository to /source
- Checkout specific commit
- Get Git Version
- Run build
   - DotNet: 
       - Update version for projects
       - Restore packages
       - Build
       - Test - parallel
       - If not Pull Request
          - If packages:
             - create NuGet packages
             - If release - Deploy to NuGet
             - If not release - Deploy to MyGet or other source

 */

Task("Build")
    .Does(() =>
{

});

Task("Default")
    .IsDependentOn("GetVersionFromGit")
    .Does(() => 
{
    Information($"Version is {globals.version}");
    RunTarget("Build");
});

globals.Initialize(Context);
RunTarget(target);