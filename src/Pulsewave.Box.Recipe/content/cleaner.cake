Setup(context => new Cleaner(context));

/// <summary>
/// Class which clean folders.
/// </summary>
public sealed class Cleaner
{
    private readonly ICakeContext _context;

    /// <summary>
    /// Initializes a new class of the <see cref=""/>
    public Cleaner(ISetupContext context)
    {
        _context = context;   
    }

    /// <summary>
    /// Clean all folders based on a glob pattern
    /// </summary>
    /// <param name="pattern">The pattern to search folder to be cleaned.</param>
    public void Clean(GlobPattern pattern)
    {
        foreach(var folder in _context.GetDirectories(pattern))
        {
            string parentFolder = folder.GetParent().GetDirectoryName();

            _context.Information($"Cleaning {folder.GetDirectoryName()} of {parentFolder}");
            _context.CleanDirectory(folder);
        }
    }
}