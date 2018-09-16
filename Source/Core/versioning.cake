#load "globals.cake"

Task("GetVersionFromGit")
    .Does(() =>
{
    var tags = GitTags(globals.source_path);
    var cleanTags = tags.Select(_ => _.CanonicalName.Replace("refs/tags/", string.Empty));
    if( cleanTags.Count() >= 0 ) globals.version = cleanTags.Last();
});