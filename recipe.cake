#load "./src/Pulsewave.Box.Recipe/content/box.cake"

string target = Context.Argument<string>("run");

Task("A")
    .Description("Alpha")
    .IsDependentOn("B")
    .Does(()=>{});

Task("B")
    .Description("Beta")
    .IsDependentOn("C")
    .Does(()=>{});

Task("C")
    .Description("Charlie")
    .IsDependentOn("D")
    .Does(()=>{});

Task("D")
    .Description("Delta")
    .Does(()=>{});

Task("E")
    .Description("Echo")
    .Does(()=>{});

Task("F")
    .Description("Foxtrot")
    .Does(()=>{});

RunTarget("A");