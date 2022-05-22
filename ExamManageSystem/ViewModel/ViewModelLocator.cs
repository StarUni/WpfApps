/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:CargoManageSystem"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using ExamManageSystem.DoMain.Login;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace ExamManageSystem.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public ServiceProvider _serviceProvider;

        public ViewModelLocator()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ViewModelLocator>()
                .AddDbContext<EMSDBContext>()
                .AddScoped<MainWindow>()
                .AddScoped<LoginWindow>()
                .AddScoped<MainViewModel>()
                .AddScoped<LoginViewModel>()
                .AddScoped<HomeViewModel>()
                .AddScoped<NewPaperViewModel>();
        }

        public LoginViewModel Login
        {
            get
            {
                return _serviceProvider.GetService<LoginViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return _serviceProvider.GetService<MainViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return _serviceProvider.GetService<HomeViewModel>();
            }
        }

        public NewPaperViewModel NewPaper
        {
            get
            {
                return _serviceProvider.GetService<NewPaperViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}