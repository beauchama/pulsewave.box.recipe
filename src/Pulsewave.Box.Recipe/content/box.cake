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
/// <param name="NuGet">The NuGet package metadata.</param>
/// <param name="Configuration">The configuration.</param>
/// <param name="StepCounter">The counter for steps.</param>
public sealed record class Box
{
    /// <summary>
    /// Gets the nuget package metadata
    /// </summary>
    public NuGet NuGet { get; init; }

    /// <summary>
    /// Gets the box configuration
    /// </summary>
    public string Configuration { get; init; }

    /// <summary>
    /// Gets the step counter
    /// </summary>
    public StepCounter StepCounter { get; init; }

    /// <summary>
    /// Gets box project paths
    /// </summary>
    public FilePathCollection Paths { get; init; }
}
