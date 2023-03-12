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
### Commands

`dotnet cake main.cake --run [command] --[options]`

| command   | description                                                                                               |
| :-------: | :-------------------------------------------------------------------------------------------------------- |
| `clean`   | Cleanup TestResults folder.                                                                               |
| `restore` | Execute `dotnet restore` for the current project.                                                         | 
| `build`   | Execute `dotnet build` for the current project. It execute `clean` and `restore` before executing `build` |
| `test`    | Execute `dotnet test` for all test projects. It execute `build` before executing `test`                   |

#### options

| options         | description                                                                  | values             |
| :-------------: | :--------------------------------------------------------------------------- | :----------------: |
| `all`           | Search all csproj in the folder.                                             |                    |
| `clean`         | Cleanup the bin and obj folders                                              |                    |
| `configuration` | Set the configuration for the project. Default value: `Release`              | `Release`, `Debug` |
| `beta`          | Create a beta version for the project. Default value: `.beta-yyyyMMddHHmmss` |                    |
| `code-coverage` | Generate a code coverage report.                                             |                    |

[main-build]: https://img.shields.io/azure-devops/build/pulsewave/box/1/main?label=main%20build
[develop-build]: https://img.shields.io/azure-devops/build/wavetechno/box/7/develop
[nuget]: https://img.shields.io/nuget/v/Pulsewave.Box.Recipe