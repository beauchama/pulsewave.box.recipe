// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

#load "./src/Pulsewave.Box.Recipe/content/recipe.cake"

Setup(context =>
{
    Box box = new("Pulsewave.Box.Recipe", context);
    Information($"Configuring {box.NuGet.Name}-{box.NuGet.Version} with configuration: {box.Configuration}\n");

    return box;
});

RunTarget(Argument<string>("run"));
