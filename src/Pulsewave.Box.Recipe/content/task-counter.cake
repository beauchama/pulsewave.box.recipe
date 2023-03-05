// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

Setup(context => new TaskCounter(context.TasksToExecute.Count));

TaskTeardown<TaskCounter>((context, counter) =>
{
    int currentStep = counter.IncrementStep();

    Information($"Executing Step {currentStep} of {counter.Count}\n");
    Information($"{context.Task.Name} step: {context.Task.Description}\n");
});

/// <summary>
/// Represent a counter to display the progress during the process.
/// </summary>
public sealed class TaskCounter
{
    private int _currentStep = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskCounter"/> class.
    /// </summary>
    /// <param name="count">The count of <see cref="ISetupCakeContext.TasksToExecute"/>.</param>
    public TaskCounter(int count)
    {
        Count = count;
    }

    /// <summary>
    /// Gets the count of <see cref="ISetupCakeContext.TasksToExecute"/>.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// return the incremented step.
    /// </summary>
    /// <returns>The incremented step.</returns>
    public int IncrementStep() => ++_currentStep;
}
