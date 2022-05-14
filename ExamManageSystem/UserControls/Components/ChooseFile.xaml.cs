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
    /// ContentTextBlock.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseFile : UserControl
    {
        public ChooseFile()
        {
            InitializeComponent();
        }

        public string TextChar
        {
            get { return (string)GetValue(TextCharProperty); }
            set { SetValue(TextCharProperty, value); }
        }
        public static readonly DependencyProperty TextCharProperty =
            DependencyProperty.Register("TextChar", typeof(string), typeof(ChooseFile));

        public ICommand ContentTextBlockCommand
        {
            get
            {
                return (ICommand)GetValue(ContentTextBlockCommandProperty);
            }
            set
            {
                SetValue(ContentTextBlockCommandProperty, value);
            }
        }
        public static readonly DependencyProperty ContentTextBlockCommandProperty =
           DependencyProperty.Register("ContentTextBlockCommand", typeof(ICommand), typeof(ChooseFile),
               new UIPropertyMetadata(null));

        /// <summary>
        /// unuse code
        /// </summary>
        public object ContentTextBlockCommandParam
        {
            get
            {
                return (object)GetValue(ContentTextBlockCommandParamProperty);
            }
            set
            {
                SetValue(ContentTextBlockCommandParamProperty, value);
            }
        }
        public static readonly DependencyProperty ContentTextBlockCommandParamProperty =
           DependencyProperty.Register("ContentTextBlockCommandParam", typeof(object), typeof(ChooseFile),
               new UIPropertyMetadata(null));
    }
}
