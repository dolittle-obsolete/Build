#addin nuget:?package=Cake.Git&version=0.19.0
#load "versioning.cake"
#load "globals.cake"

var target = Argument("target", "Default");

/*
- Copy entire folder from /repository to /source
- Checkout specific commit
- Get Git Version
 */

Task("CloneAndCheckout")
    .Does(() =>
    {
        GitClone(globals.repository, globals.source_path, new GitCloneSettings
        {
            RecurseSubmodules = true
        });
        if (!string.IsNullOrEmpty(globals.commit))
        {
            Information($"Checking out to {globals.commit}");
            GitCheckout(globals.source_path, globals.commit);
        }
    });

Task("Globals")
    .Does(globals.Initialize);

Task("Common")
    .IsDependentOn("Globals")
    .IsDependentOn("CloneAndCheckout")
    .IsDependentOn("GetVersionFromGit")
    .Does(() =>
    {
        Information($"Version is {globals.version}");
    });