// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

/// <summary>
/// Represents NuGet package metadata
/// </summary>
public sealed class NuGet
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NuGet"/> class.
    /// </summary>
    /// <param name="projectName">The project name.</param>
    /// <param name="context">The <see cref="ICakeContext"/>.</param>
    public NuGet(string projectName, ICakeContext context)
    {
        Path = $"./src/{projectName}/{projectName}.csproj";

        Name = projectName;
        Version = GetVersion(context);
    }

    /// <summary>
    /// Gets the Box NuGet name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the Box NuGet version.
    /// </summary>
    public SemVersion Version { get; }

    /// <summary>
    /// Gets the NuGet path.
    /// </summary>
    public FilePath Path { get; }

    private SemVersion GetVersion(ICakeContext context)
    {
        string version = context.XmlPeek(Path, "//Version");

        if (context.HasArgument("beta"))
            version = $"{version}-beta.{DateTime.Now:yyyyMMddHHmmss}";

        SemVersion.TryParse(version, out var parsedVersion);

        return parsedVersion;
    }
}
