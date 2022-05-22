using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.IconPacks;

namespace ExamManageSystem.UserControls.Components
{
    /// <summary>
    /// Menubutton.xaml 的交互逻辑
    /// </summary>
    public partial class Menubutton : UserControl
    {
        public Menubutton()
        {
            InitializeComponent();
        }

        public PackIconMaterialKind Icon
        {
            get { return (PackIconMaterialKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PackIconMaterialKind), typeof(Menubutton));

        public string BtnContent
        {
            get { return (string)GetValue(BtnContentProperty); }
            set { SetValue(BtnContentProperty, value); }
        }
        public static readonly DependencyProperty BtnContentProperty =
            DependencyProperty.Register("BtnContent", typeof(string), typeof(Menubutton));

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(Menubutton));

        public ICommand MenuButtonCommand
        {
            get
            {
                return (ICommand)GetValue(MenuButtonCommandProperty);
            }
            set
            {
                SetValue(MenuButtonCommandProperty, value);
            }
        }
        public static readonly DependencyProperty MenuButtonCommandProperty =
           DependencyProperty.Register("MenuButtonCommand", typeof(ICommand), typeof(Menubutton), 
               new UIPropertyMetadata(null));

        public object MenuButtonCommandParam
        {
            get
            {
                return (object)GetValue(MenuButtonCommandParamProperty);
            }
            set
            {
                SetValue(MenuButtonCommandParamProperty, value);
            }
        }
        public static readonly DependencyProperty MenuButtonCommandParamProperty =
           DependencyProperty.Register("MenuButtonCommandParam", typeof(object), typeof(Menubutton),
               new UIPropertyMetadata(null));

        //ClickedSeriesCommand.Execute(csvm);
    }
}
