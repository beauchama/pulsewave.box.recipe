// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

#load "./src/Pulsewave.Box.Recipe/content/build.cake"

Setup(context =>
{
    string project = context.Argument<string>("project");

    FilePathCollection projectPaths = context.HasArgument("all")
        ? context.GetFiles("./**/*.csproj")
        : context.GetFiles("./src/**/*.csproj");

    Box box = new()
    {
        Configuration = context.Argument("configuration", Configuration.Release).ToString(),
        NuGet = new NuGet(project, context),
        StepCounter = new StepCounter(context),
        Paths = projectPaths
    };

    Information($"Configuring {box.NuGet.Name}-{box.NuGet.Version} with configuration: {box.Configuration}\n");

    return box;
});

RunTarget(Argument<string>("run"));
