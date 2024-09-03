using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mini_market_Managerment_Systerm.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Mini_market_Managerment_Systerm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<MainWindow>();
            serviceCollection.AddScoped<minimarketdbContext>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
            ServiceProvider.GetRequiredService<MainWindow>().Show();
        }
    }

}
