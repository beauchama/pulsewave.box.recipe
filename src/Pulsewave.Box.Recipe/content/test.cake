// Copyright (c) Wave. All rights reserved.
// The source code is licensed under MIT License

#load "./box.cake"
#tool nuget:?package=ReportGenerator&version=5.1.17

Task("test").IsDependentOn("build").Does<Box>(box =>
{
    bool hasCodeCoverageArgument = HasArgument("code-coverage");
    DotNetTestSettings settings = ConfigureTestSettings(box);

    if (hasCodeCoverageArgument)
        settings.WithArgumentCustomization(CollectCodeCoverage);

    foreach (var testProjectPath in GetFiles("./test/**/*.csproj"))
    {
        Information($"Running {testProjectPath.GetFilenameWithoutExtension()} unit tests\n");
        DotNetTest(testProjectPath.ToString(), settings);

        Information(new string('-', 40));
    }

    if (hasCodeCoverageArgument)
        GenerateReport();
});

private DotNetTestSettings ConfigureTestSettings(Box box) => new()
{
    Configuration = box.Configuration.ToString(),
    NoBuild = true,
    Loggers = new[] { "trx;logfilename=tests.trx" }
};

private void GenerateReport()
{
    Information("Generating the code coverage report\n");
    ReportGenerator(new GlobPattern("**/coverage.*.xml"), "reports", new ReportGeneratorSettings
    {
        ReportTypes = new[] { ReportGeneratorReportType.Cobertura }
    });
}

private static ProcessArgumentBuilder CollectCodeCoverage(ProcessArgumentBuilder argsBuilder)
    => argsBuilder.Append("--collect:").AppendQuoted("XPlat Code Coverage");