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

namespace ExamManageSystem.UserControls.Components
{
    /// <summary>
    /// Menuradiobutton.xaml 的交互逻辑
    /// </summary>
    public partial class Menuradiobutton : UserControl
    {
        public Menuradiobutton()
        {
            InitializeComponent();
        }

        public string RBtnTag
        {
            get { return (string)GetValue(RBtnTagProperty); }
            set { SetValue(RBtnTagProperty, value); }
        }
        public static readonly DependencyProperty RBtnTagProperty =
            DependencyProperty.Register("RBtnTag", typeof(string), typeof(Menuradiobutton));

        public string RBtnContent
        {
            get { return (string)GetValue(RBtnContentProperty); }
            set { SetValue(RBtnContentProperty, value); }
        }
        public static readonly DependencyProperty RBtnContentProperty =
            DependencyProperty.Register("RBtnContent", typeof(string), typeof(Menuradiobutton));

        public bool IsRBChecked
        {
            get { return (bool)GetValue(IsRBActiveProperty); }
            set { SetValue(IsRBActiveProperty, value); }
        }
        public static readonly DependencyProperty IsRBActiveProperty =
            DependencyProperty.Register("IsRBChecked", typeof(bool), typeof(Menuradiobutton));

        public ICommand MenuRadioButtonCommand
        {
            get
            {
                return (ICommand)GetValue(MenuRadioButtonCommandProperty);
            }
            set
            {
                SetValue(MenuRadioButtonCommandProperty, value);
            }
        }
        public static readonly DependencyProperty MenuRadioButtonCommandProperty =
           DependencyProperty.Register("MenuRadioButtonCommand", typeof(ICommand), typeof(Menuradiobutton),
               new UIPropertyMetadata(null));
    }
}
