#addin nuget:?package=Cake.Git&version=0.19.0
#load "common.cake"
#load "globals.cake"

using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;


/*
- Run build
   - DotNet: 
       - Update version for projects
       - Restore packages
       - Build
       - Test - parallel
       - If not Pull Request
          - If packages:
             - create NuGet packages
             - If release - Deploy to NuGet
             - If not release - Deploy to MyGet or other source
 */

Task("UpdateVersionForAllProjects")
    .Does(() => 
{
    var projectFiles = GetFiles($"{globals.source_path}/Source/**/*.csproj");
    foreach( var projectFile in projectFiles )
    {
        var file = projectFile.FullPath;
        var xml = XDocument.Load(file);

        var found = false;
        var query = (IEnumerable)xml.XPathEvaluate("//Version");
        foreach( var element in query.Cast<XElement>())
        {
            element.Value = globals.version;
            Information($"Settings version element with version '{globals.version}' to '{file}'");
            found = true;
        }

        if( !found ) 
        {
            var propertyGroupElement = new XElement("PropertyGroup");
            var versionElement = new XElement("Version");
            versionElement.Value = globals.version;
            propertyGroupElement.Add(versionElement);
            xml.Element("Project").Add(propertyGroupElement);
            Information($"Adding version element with version '{globals.version}' to '{file}'");
        }

        var settings = new XmlWriterSettings { OmitXmlDeclaration = true };
        using( var writer = XmlWriter.Create(file, settings)) xml.Save(writer);
    }
});
 
Task("Build")
    .IsDependentOn("Common")
    .IsDependentOn("UpdateVersionForAllProjects")
    .Does(() => 
{
    DotNetCoreRestore(globals.source_path);
    DotNetCoreBuild(globals.source_path, new DotNetCoreBuildSettings 
    {
        Configuration = "Release",
        NoRestore = true
    });

    var specFilesPattern = $"{globals.source_path}/Specifications/**/bin/**/*.Specs.dll";
    var specFiles = GetFiles(specFilesPattern);
    foreach( var spec in specFiles ) Information(spec);
    DotNetCoreVSTest(specFiles,new DotNetCoreVSTestSettings 
    {
        Parallel = true
    });

    var projectFiles = GetFiles($"{globals.source_path}/Source/**/*.csproj");
    foreach( var projectFile in projectFiles )
    {
        DotNetCorePack(projectFile.FullPath, new DotNetCorePackSettings
        {
            Configuration = "Release",
            NoRestore = true,
            NoBuild = true,
            IncludeSymbols = true,
            IncludeSource = true,
            OutputDirectory = "/packages"
        });
    }
});
