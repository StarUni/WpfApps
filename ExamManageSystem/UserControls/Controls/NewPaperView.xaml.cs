using ExamManageSystem.DoMain.AppEngine;
using ExamManageSystem.Models;
using ExamManageSystem.UserControls.Components;
using GalaSoft.MvvmLight.Command;
using Models.BussinessProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExamManageSystem.UserControls.Controls
{
    /// <summary>
    /// NewPaperView.xaml 的交互逻辑
    /// </summary>
    public partial class NewPaperView : UserControl
    {
        //private UserInfo _userInfo = AppData.Instance.UserInfo;
        //private readonly QuestionsProvider _questionsProvider = null;
        //private readonly List<Questions> _questions = null;
        //private readonly StackPanel _stackPanel = null;

        public NewPaperView()
        {
            InitializeComponent();
            //_questionsProvider = new QuestionsProvider();
            //_questions = new List<Questions>();
            //_stackPanel = ((StackPanel)this.FindName("paperPnl"));
        }

        //public int FBNum
        //{
        //    get { return (int)GetValue(FBNumProperty); }
        //    set { SetValue(FBNumProperty, value); }
        //}
        //public static readonly DependencyProperty FBNumProperty =
        //    DependencyProperty.Register("FBNum", typeof(int), typeof(NewPaperView));

        //public int MCNum
        //{
        //    get { return (int)GetValue(MCNumProperty); }
        //    set { SetValue(MCNumProperty, value); }
        //}
        //public static readonly DependencyProperty MCNumProperty =
        //    DependencyProperty.Register("MCNum", typeof(int), typeof(NewPaperView));

        //public int MACNum
        //{
        //    get { return (int)GetValue(MACNumProperty); }
        //    set { SetValue(MACNumProperty, value); }
        //}
        //public static readonly DependencyProperty MACNumProperty =
        //    DependencyProperty.Register("MACNum", typeof(int), typeof(NewPaperView));

        //public int TFNum
        //{
        //    get { return (int)GetValue(TFNumProperty); }
        //    set { SetValue(TFNumProperty, value); }
        //}
        //public static readonly DependencyProperty TFNumProperty =
        //    DependencyProperty.Register("TFNum", typeof(int), typeof(NewPaperView));

        //public int SQNum
        //{
        //    get { return (int)GetValue(SQNumProperty); }
        //    set { SetValue(SQNumProperty, value); }
        //}
        //public static readonly DependencyProperty SQNumProperty =
        //    DependencyProperty.Register("SQNum", typeof(int), typeof(NewPaperView));
    }
}
