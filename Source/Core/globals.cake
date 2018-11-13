public class globals
{
    public static string version = "0.0.0";
    public static string source_path = "/source";
    public static string base_path = "/Source";
    public static string repository = "";
    public static string commit = "";
    public static bool package = false;
    public static bool publish = false;
    public static string folder_with_project_to_publish = "";
    public static string callbackUrl = "";
    

    public static void Initialize(ICakeContext context)
    {
        repository = context.Argument("repository", "");
        source_path = context.Argument("source_path", "/source");
        base_path = context.Argument("base_path", "/Source");
        package = bool.Parse(context.Argument("package", "false"));
        publish = bool.Parse(context.Argument("publish", "false"));
        folder_with_project_to_publish = context.Argument("folder_with_project_to_publish","");
        commit = context.Argument("commit", "");
        version = context.EnvironmentVariable("VERSION") ?? "1.0.0";
        callbackUrl = EnvironmentVariable("CALLBACK");

        context.Information($"Repository to build            : ${repository}");
        context.Information($"Source is located in           : ${source_path}");
        context.Information($"Base path                      : ${base_path}");
        context.Information($"Create Packages                : ${package}");
        context.Information($"Publish                        : ${package}");
        context.Information($"Folder with project to publish : ${folder_with_project_to_publish}");
        context.Information($"Commit                         : ${commit}");
        context.Information($"Version                        : ${version}");
        context.Information($"Callback                       : ${callbackUrl}");
    }
}
