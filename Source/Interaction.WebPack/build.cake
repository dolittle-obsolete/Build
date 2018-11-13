#load "webpack.cake"

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);