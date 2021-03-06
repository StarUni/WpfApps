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
    /// QuestionPanel.xaml 的交互逻辑
    /// </summary>
    public partial class QuestionPanel : UserControl
    {
        public QuestionPanel()
        {
            InitializeComponent();
        }

        public string TopicContent
        {
            get { return (string)GetValue(TopicContentProperty); }
            set { SetValue(TopicContentProperty, value); }
        }

        public static readonly DependencyProperty TopicContentProperty =
            DependencyProperty.Register("TopicContent", typeof(string), typeof(QuestionPanel));

        public string TopicAnswer
        {
            get { return (string)GetValue(TopicAnswerProperty); }
            set { SetValue(TopicAnswerProperty, value); }
        }
        public static readonly DependencyProperty TopicAnswerProperty =
            DependencyProperty.Register("TopicAnswer", typeof(string), typeof(QuestionPanel));
    }
}
