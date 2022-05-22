using ExamManageSystem.Models;
using Microsoft.Extensions.Configuration;
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

        public string SystemName = "V2.1";//Configuration["SystemName"]

        public UserInfo UserInfo { get; set; } = new UserInfo();

        //public AppData(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
    }
}
