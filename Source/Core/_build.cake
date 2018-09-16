#load "versioning.cake"
#load "globals.cake"

var target = Argument("target", "Default");

/*

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
    Information($"Version is {version}");
    RunTarget("Build");
});

RunTarget(target);