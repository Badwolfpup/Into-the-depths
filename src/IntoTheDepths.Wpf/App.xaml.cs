using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntoTheDepths.Wpf;

/// <summary>
/// Composition root: the only place that knows which concrete classes implement which services.
/// </summary>
public partial class App : Application
{
    private readonly IHost _host = CreateHost();

    private static IHost CreateHost()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddSingleton<MainWindow>();

        return builder.Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _host.Start();
        _host.Services.GetRequiredService<MainWindow>().Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.StopAsync(TimeSpan.FromSeconds(5)).GetAwaiter().GetResult();
        _host.Dispose();
        base.OnExit(e);
    }
}
