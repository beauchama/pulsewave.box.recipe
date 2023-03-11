// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

#load "./box.cake"

Task("clean").Description("Cleaning box folders").Does(() =>
{
    if (Context.HasArgument("clean"))
    {
        Clean("./**/bin");
        Clean("./**/obj");
    }

    Clean("./**/TestResults");
});

Task("restore").Description("Restore box").DoesForEach<Box, FilePath>(box => box.Paths, path =>
{
    Information($"Restoring {path.GetFilenameWithoutExtension()}\n");
    DotNetRestore(path.ToString());

    Information(new string('-', 40));
});

Task("build").Description("Build box").IsDependentOn("restore").Does<Box>(box =>
{
    DotNetBuildSettings settings = new()
    {
        Configuration = box.Configuration.ToString(),
        NoRestore = true
    };

    foreach (var projectPath in box.Paths)
    {
        Information($"Building {projectPath.GetFilenameWithoutExtension()}\n");
        DotNetBuild(projectPath.ToString(), settings);

        Information(new string('-', 40));
    }
});

/// <summary>
/// Clean all folders based on a glob pattern.
/// </summary>
/// <param name="pattern">The pattern to search folder to be cleaned.</param>
public void Clean(GlobPattern pattern)
{
    foreach(var folder in Context.GetDirectories(pattern))
    {
        string parentFolder = folder.GetParent().GetDirectoryName();

        Context.Information($"Cleaning {folder.GetDirectoryName()} of {parentFolder}");
        Context.CleanDirectory(folder);
    }
}
