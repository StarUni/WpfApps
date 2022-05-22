using ExamManageSystem.DoMain.Login;
using ExamManageSystem.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ExamManageSystem
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var viewModelLocator = new ViewModelLocator();
            _serviceProvider = viewModelLocator._serviceProvider;
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var loginWindow = _serviceProvider.GetService<LoginWindow>();
            loginWindow.Show();
        }
    }
}
