using Avalonia;
using Avalonia.Headless;
using Avalonia.ReactiveUI;
using Chess;

[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]

namespace Chess;

public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
        .UseHeadless(new AvaloniaHeadlessPlatformOptions())
        .UseReactiveUI();
}