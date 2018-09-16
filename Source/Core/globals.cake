public class globals
{
    public static string version = "0.0.0";
    public static string source_path = "/source";
    public static string repository = "";
    public static string commit = "";

    public static void Initialize(ICakeContext context)
    {
        source_path = context.Argument("source_path", "/source");
        repository = context.Argument("repository", "");
        commit = context.Argument("commit", "");

        context.Information($"Repository to build: ${repository}");
        context.Information($"Source is located in ${source_path}");
    }
}
