using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using ZonyLrcTools.Common.Infrastructure.DependencyInject;
using ZonyLrcTools.Common.Infrastructure.Network;
using ZonyLrcTools.Desktop.ViewModels;
using ZonyLrcTools.Desktop.Views;

namespace ZonyLrcTools.Desktop;

public class App : Application
{
    public new static App Current => (App)Application.Current!;
    public IServiceProvider Services { get; } = ConfigureServices();

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.BeginAutoDependencyInject<Program>();
        services.BeginAutoDependencyInject<IWarpHttpClient>();
        services.ConfigureConfiguration();
        services.ConfigureToolService();

        return services.BuildServiceProvider();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new HomeViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}