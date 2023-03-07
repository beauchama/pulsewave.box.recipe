// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

#load "./step-counter.cake"
#load "./nuget.cake"
#load "./configuration.cake"

TaskSetup<Box>((context, box) =>
{
    int currentStep = box.StepCounter.IncrementStep();

    Information($"Executing Step {currentStep} of {box.StepCounter.Count}\n");
    Information($"{context.Task.Name} step: {context.Task.Description}\n");
});

/// <summary>
/// Represents the configuration for a box project
/// </summary>
public sealed class Box
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Box"/> class.
    /// </summary>
    /// <param name="name">The box name.</param>
    /// <param name="context">The context of <see cref="ISetupContext"/>.</param>
    public Box(string name, ISetupContext context)
    {
        NuGet = new NuGet(name, context);
        Configuration = context.Argument("configuration", Configuration.Release);
        StepCounter = new StepCounter(context);
        Paths = context.HasArgument("all")
            ? context.GetFiles("./**/*.csproj")
            : context.GetFiles("./src/**/*.csproj");
    }

    /// <summary>
    /// Gets the nuget package metadata
    /// </summary>
    public NuGet NuGet { get; }

    /// <summary>
    /// Gets the box configuration
    /// </summary>
    public Configuration Configuration { get; }

    /// <summary>
    /// Gets the step counter
    /// </summary>
    public StepCounter StepCounter { get; }

    /// <summary>
    /// Gets box project paths
    /// </summary>
    public FilePathCollection Paths { get; }
}
