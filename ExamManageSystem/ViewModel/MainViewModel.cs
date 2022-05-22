using ExamManageSystem.DoMain.AppEngine;
using ExamManageSystem.UserControls.Components;
using ExamManageSystem.UserControls.Controls;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;

namespace ExamManageSystem.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            
        }

        public string Title { get; set; } = AppData.Instance.SystemName;

        public static RelayCommand LaunchGitHubSite => new RelayCommand(() =>
        {
            System.Diagnostics.Process.Start("MsEdge.exe", "https://www.baidu.com");
        });

        public RelayCommand<Window> PowerOffCommand => new RelayCommand<Window>((mainWindow) =>
        {
            mainWindow.Close();
        });

        //public RelayCommand<RadioButton> RadioBtnCommand => new RelayCommand<RadioButton>((rbtn) =>
        //{
        //    if (string.IsNullOrEmpty(rbtn.Content.ToString())) return;
        //    switch (rbtn.Content.ToString())
        //    {
        //        case "Home":
        //            AppData.Instance.MainWindow.controlsContainer.Content = new HomeView();
        //            break;
        //        case "History":
        //            AppData.Instance.MainWindow.controlsContainer.Content = new HistoryPaperView();
        //            break;
        //        case "Manage":
        //            AppData.Instance.MainWindow.controlsContainer.Content = new ManagementView();
        //            break;
        //        default:
        //            break;
        //    }
        //});

        public static RelayCommand<Menubutton> MenuBtnCommand => new((mbtn) =>
        {
            if (string.IsNullOrEmpty(mbtn.BtnContent)) return;
            switch (mbtn.BtnContent)
            {
                case "HomePage": 
                    AppData.Instance.MainWindow.controlsContainer.Content = new HomeView(); 
                    break;
                case "NewPaper":
                    AppData.Instance.MainWindow.controlsContainer.Content = new NewPaperView();
                    break;
                case "HistoryPaper":
                    AppData.Instance.MainWindow.controlsContainer.Content = new HistoryPaperView();
                    break;
                case "WrongRecord":
                    AppData.Instance.MainWindow.controlsContainer.Content = new WrongRecordView();
                    break;
                case "Management":
                    AppData.Instance.MainWindow.controlsContainer.Content = new ManagementView();
                    break;
                default:
                    break;
            }
        });
    }
}