#load "dotnet.cake"
Task("Default")
    .IsDependentOn("Build");

RunTarget(target);