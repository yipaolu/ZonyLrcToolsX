using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using ZonyLrcTools.Common.Configuration;
using ZonyLrcTools.Common.Infrastructure.DependencyInject;
using ZonyLrcTools.Common.Infrastructure.Network;
using ZonyLrcTools.Desktop.ViewModels;
using ZonyLrcTools.Desktop.Views;

namespace ZonyLrcTools.Desktop;

public class App : Application
{
    public new static App Current => (App)Application.Current!;
    public IServiceProvider Services { get; } = ConfigureServices();

    public IOptions<GlobalOptions> GlobalOptions => Services.GetRequiredService<IOptions<GlobalOptions>>();

    private Lazy<ISerializer> _yamlSerializer = new(() => new SerializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .WithDefaultScalarStyle(ScalarStyle.DoubleQuoted)
        .Build());

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

    public void UpdateConfiguration()
    {
        var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.yaml");
        var yamlString = _yamlSerializer.Value.Serialize(GlobalOptions.Value);
        File.WriteAllText(configPath, yamlString);
    }
}