using ExamManageSystem.DoMain.AppEngine;
using ExamManageSystem.UserControls.Controls;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamManageSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            AppData.Instance.MainWindow = this;
        }

        ///regualr func:Checked="RadioButton_Checked"
        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (!(sender is RadioButton button)) return;
        //    if (string.IsNullOrEmpty(button.Content.ToString())) return;
        //    switch (button.Content.ToString())
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
        //}
    }
}
