using ExamManageSystem.DoMain.AppEngine;
using ExamManageSystem.UserControls.Components;
using ExamManageSystem.UserControls.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace ExamManageSystem.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public string Title { get; set; } = AppData.Instance.SystemName;

        public RelayCommand LaunchGitHubSite => new RelayCommand(() =>
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

        public RelayCommand<Menubutton> MenuBtnCommand => new RelayCommand<Menubutton>((mbtn) =>
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