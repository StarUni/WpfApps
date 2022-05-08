using CargoManageSystem.Models;
using GalaSoft.MvvmLight;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManageSystem.DoMain.AppEngine
{
    public class AppData : ObservableObject
    {
        public static AppData Instance = new Lazy<AppData>(() => new AppData()).Value;

        public string SystemName 
        {
            get
            {
                return ConfigurationManager.AppSettings["SystemName"];
            }
        }

        public Member CurrentUser
        {
            get
            {
                return new Member();
            }
            set
            {
                CurrentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }
    }
}
