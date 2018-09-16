#addin nuget:?package=Cake.Git&version=0.19.0
#load "common.cake"
#load "globals.cake"

/*
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
    .IsDependentOn("Common")
    .Does(() => 
{
    Information("Build");
});
