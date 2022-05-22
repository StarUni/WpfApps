using ExamManageSystem.DoMain.AppEngine;
using MahApps.Metro.Controls;

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
    }
}
