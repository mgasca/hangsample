using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CustomComboBox
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ServiceCollection services = new ServiceCollection();
            services.AddHttpClient();
            services.AddTransient<MainWindow>();
            services.AddTransient<MainWindowViewModel>();
            services.AddSingleton<FilmService>();
            var serviceProvider = services.BuildServiceProvider();

            MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            mainWindow.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();

        }
    }
}
