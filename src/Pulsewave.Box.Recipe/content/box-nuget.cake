// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

#load "./Configuration.cake"

/// <summary>
/// Represent a Box NuGet with his information.
/// </summary>
public sealed class BoxNuGet
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BoxNuGet"/> class.
    /// </summary>
    /// <param name="context">The <see cref="ICakeContext"/>.</param>
    public BoxNuGet(ICakeContext context)
    {
        Path = context.Argument<FilePath>("nuget");

        Name = context.XmlPeek(Path, "//PackageId");
        Version = context.XmlPeek(Path, "//Version");
        Configuration = context.Argument("configuration", Configuration.Release);
    }

    /// <summary>
    /// Gets the Box NuGet name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the Box NuGet version.
    /// </summary>
    public string Version { get; }

    /// <summary>
    /// Gets the Box NuGet configuration.
    /// </summary>
    public Configuration Configuration { get; }

    /// <summary>
    /// Gets the NuGet path.
    /// </summary>
    public FilePath Path { get; }
}