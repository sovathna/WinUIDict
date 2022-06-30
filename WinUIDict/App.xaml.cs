using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using System;
using WinUIDict.Pages.Definition;
using WinUIDict.Pages.Words;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDict
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {

        public static new App Current => (App)Application.Current;

        public readonly IServiceProvider Services;
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            var AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                services
                .AddDbContext<DictDbContext>()
                .AddTransient<WordsSource>()
                .AddTransient<WordsViewModel>()

                .AddTransient<DefinitionViewModel>()

            )
                //.UseSerilog((context, services, loggerConfig) =>
                //loggerConfig
                //    .Enrich.FromLogContext()
                //    .WriteTo.Debug(new RenderedCompactJsonFormatter())
                //)
                .Build();
            AppHost.RunAsync();
            Services = AppHost.Services;
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            MainWindow = new MainWindow();
            MainWindow.Activate();
        }

        public MainWindow MainWindow { get; private set; }
    }
}
