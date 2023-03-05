// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

Task("clean-project").Description("Cleaning the bin and obj folders").Does(() =>
{
    Clean("./**/bin");
    Clean("./**/obj");

    void Clean(GlobPattern pattern)
    {
        foreach(var folder in GetDirectories(pattern))
        {
            string parentFolder = folder.GetParent().GetDirectoryName();

            Information($"Cleaning {folder.GetDirectoryName()} of {parentFolder}");
            CleanDirectory(folder);
        }
    }
});