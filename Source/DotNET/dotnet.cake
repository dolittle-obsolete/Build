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
    DotNetCoreRestore(globals.source_path);
    DotNetCoreBuild(globals.source_path, new DotNetCoreBuildSettings 
    {
        Configuration = "Release",
        OutputDirectory = "/artifacts",
        NoRestore = true
    });

    var projectFiles = GetFiles($"{globals.source_path}/Specifications/**/*.csproj");
    DotNetCoreVSTest(projectFiles,new DotNetCoreVSTestSettings 
    {
        Parallel = true
    });
});
