using ExamManageSystem.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Configuration;

namespace ExamManageSystem.DoMain.AppEngine
{
    public class AppData : ObservableObject
    {
        public static AppData Instance = new Lazy<AppData>(() => new AppData()).Value;

        public IConfiguration Configuration { get; } 

        public MainWindow MainWindow { get; set; }

        public string SystemName { get; set; } 

        public UserInfo UserInfo { get; set; } = new UserInfo();

        public AppData()
        {
            Configuration = new ConfigurationBuilder()
                //AppDomain.CurrentDomain.BaseDirectory是程序集基目录，所以appsettings.json,需要复制一份放在程序集目录下，
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
                .Build();
            SystemName = Configuration.GetValue<string>("SystemName");
        }
    }
}
