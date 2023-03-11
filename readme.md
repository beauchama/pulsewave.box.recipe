Pulsewave.Box.Recipe
====================
![main-build] ![develop-build] ![nuget]

Re-usable cake scripts to build, test, deploy, codeql, dependenbot, mutation testing, release for Box nugets.

## Documentation

### Entry point

You should add a entry point to run all cake commands. This entry point should follow a standard in every Box nugets

* the entry point file should be named as `main.cake`
* Should have the license header
* Should load `Pulsewave.Box.Recipe` nuget with latest version
* Should setup box information
* Should have ` RunTarget(Argument<string>("run"));` at the end of the file

Here an example
```cs
// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

#load nuget:?package=Pulsewave.Box.Recipe&version=1.0.0

Setup(context =>
{
    Box box = new("Box nuget name", context);
    Information($"Configuring {box.NuGet.Name}-{box.NuGet.Version} with configuration: {box.Configuration}\n");

    return box;
});

RunTarget(Argument<string>("run"));

```
### Execute the script

`dotnet cake main.cake --run [command] --[options]`

### build.cake

This script permit to restore/build the project.

#### clean

`dotnet cake main.cake --run clean`

This command permit to cleanup folders. When running this command it will clean TestResults folder.

#### restore

`dotnet cake main.cake --run restore`

This command execute `dotnet restore` for the project. By default it will restore the projet which was given in the setup.

#### build

This command execute `dotnet build` for the project. By default it will build the projet which was given in the setup.

This commande will execute his dependencies before executing himself which are
* clean
* restore

#### options

all options to be executed with the executed command
* `--all`: Search all csproj in the folder. Use this options if you need to restore/build all csproj.
* `--clean`: Cleanup the bin and obj folders
* `--configuration`: Set the configuration for the project. By default is Release
* `--beta`: Add metadata on the version: `.beta-yyyyMMddHHmmss`

[main-build]: https://img.shields.io/azure-devops/build/pulsewave/box/1/main?label=main%20build
[develop-build]: https://img.shields.io/azure-devops/build/wavetechno/box/7/develop
[nuget]: https://img.shields.io/nuget/v/Pulsewave.Box.Recipe