using ExamManageSystem.Models;
using GalaSoft.MvvmLight;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManageSystem.DoMain.AppEngine
{
    public class AppData : ObservableObject
    {
        public static AppData Instance = new Lazy<AppData>(() => new AppData()).Value;

        public MainWindow MainWindow { get; set; }

        public string SystemName => ConfigurationManager.AppSettings["SystemName"];

        public DataDictionary DataDictionary
        {
            get
            {
                return new DataDictionary();
            }
            set
            {
                DataDictionary = value;
                RaisePropertyChanged("DataDictionary");
            }
        }
        public UserInfo UserInfo
        {
            get
            {
                return new UserInfo();
            }
            set
            {
                UserInfo = value;
                RaisePropertyChanged("UserInfo");
            }
        }
        public ExamPaper ExamPaper
        {
            get
            {
                return new ExamPaper();
            }
            set
            {
                ExamPaper = value;
                RaisePropertyChanged("ExamPaper");
            }
        }

        public RoleInfo RoleInfo
        {
            get
            {
                return new RoleInfo();
            }
            set
            {
                RoleInfo = value;
                RaisePropertyChanged("RoleInfo");
            }
        }

        public Questions Questions
        {
            get
            {
                return new Questions();
            }
            set
            {
                Questions = value;
                RaisePropertyChanged("Questions");
            }
        }

        public WrongQuestions WrongQuestions
        {
            get
            {
                return new WrongQuestions();
            }
            set
            {
                WrongQuestions = value;
                RaisePropertyChanged("WrongQuestions");
            }
        }

    }
}
