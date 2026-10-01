using System.Reflection;

namespace IntoTheDepths.Tests.Architecture;

/// <summary>
/// Core holds the game rules and must stay independent of the UI and the database,
/// so it can be tested and reused without either.
/// </summary>
public class CoreDependencyTests
{
    private static readonly string[] ForbiddenPrefixes =
    [
        "PresentationCore",
        "PresentationFramework",
        "WindowsBase",
        "Microsoft.EntityFrameworkCore",
        "IntoTheDepths.Data",
        "IntoTheDepths.Wpf",
    ];

    [Fact]
    public void Core_does_not_reference_ui_or_persistence_assemblies()
    {
        var referenced = Assembly.Load("IntoTheDepths.Core")
            .GetReferencedAssemblies()
            .Select(a => a.Name ?? string.Empty);

        referenced.Should().NotContain(name =>
            ForbiddenPrefixes.Any(prefix => name.StartsWith(prefix, StringComparison.Ordinal)));
    }
}
