#load "common.cake"
#load "globals.cake"
Task("Build")
    .Does(() => 
{
    var currentDirectory = System.IO.Directory.GetCurrentDirectory();
    System.IO.Directory.SetCurrentDirectory(globals.folder_with_project_to_publish);

    StartProcess("yarn");
    StartProcess("webpack","-p --env.production --output-path=/publish");

    System.IO.Directory.SetCurrentDirectory(currentDirectory);
});