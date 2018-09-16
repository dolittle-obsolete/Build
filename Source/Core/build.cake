#load "common.cake"

Task("Default")
    .IsDependentOn("Common");

RunTarget(target);