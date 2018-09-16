#addin nuget:?package=Cake.Git&version=0.19.0
#load "globals.cake"

Task("GetVersionFromGit")
    .Does(() =>
{
    var tags = GitTags("/Users/einari/Projects/Dolittle/DotNET.SDK");
    var cleanTags = tags.Select(_ => _.CanonicalName.Replace("refs/tags/", string.Empty));
    if( cleanTags.Count() >= 0 ) version = cleanTags.Last();
});