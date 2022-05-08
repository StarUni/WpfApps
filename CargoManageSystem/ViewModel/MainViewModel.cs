using CargoManageSystem.DoMain.AppEngine;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace CargoManageSystem.ViewModel
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

        public RelayCommand<RadioButton> RadioBtnCommand => new RelayCommand<RadioButton>((rbtn) =>
        {
            rbtn.IsChecked = true;
        });
    }
}