// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

#load "./src/Pulsewave.Box.Recipe/content/build.cake"
#addin "nuget:?package=Cake.Http&version=2.0.0"

Setup(context =>
{
    Box box = new("Pulsewave.Box.Recipe", context);
    Information($"Configuring {box.NuGet.Name}-{box.NuGet.Version} with configuration: {box.Configuration}\n");

    context.StartProcess("curl", "-w '%{size_download}' https://api.nuget.org/v3-flatcontainer/Newtonsoft.Json/index.json");
    
    return box;
});

RunTarget(Argument<string>("run"));
