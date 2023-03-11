// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

/// <summary>
/// Represent a counter to display the progress during the process.
/// </summary>
public sealed class StepCounter
{
    private int _currentStep = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="StepCounter"/> class.
    /// </summary>
    /// <param name="context">The context of <see cref="ISetupContext"/>.</param>
    public StepCounter(ISetupContext context)
    {
        Count = context.TasksToExecute.Count;
    }

    /// <summary>
    /// Gets the count of <see cref="ISetupContext.TasksToExecute.Count"/>.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// return the incremented step.
    /// </summary>
    /// <returns>The incremented step.</returns>
    public int IncrementStep() => ++_currentStep;
}
