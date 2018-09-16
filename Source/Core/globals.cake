public class globals
{
    public static string version = "0.0.0";
    public static string source_path = "/source";

    public static void Initialize(ICakeContext context)
    {
        source_path = context.Argument("source_path", "/source");

        context.Information($"Source is located in ${source_path}");
    }
}
