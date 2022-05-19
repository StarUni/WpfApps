using ExamManageSystem.UserControls.Components;
using GalaSoft.MvvmLight.Command;
using Models.BussinessProvider;
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

namespace ExamManageSystem.UserControls.Controls
{
    /// <summary>
    /// NewPaperView.xaml 的交互逻辑
    /// </summary>
    public partial class NewPaperView : UserControl
    {
        public QuestionsProvider _questionsProvider { get; set; }
        public ExamPaperProvider _examPaperProvider { get; set; }

        public NewPaperView()
        {
            InitializeComponent();
        }

        //public RelayCommand UcLoadedCommand => new RelayCommand(() =>
        //{ });

        public int FBNum
        {
            get { return (int)GetValue(FBNumProperty); }
            set { SetValue(FBNumProperty, value); }
        }
        public static readonly DependencyProperty FBNumProperty =
            DependencyProperty.Register("FBNum", typeof(int), typeof(NewPaperView));

        public int MCNum
        {
            get { return (int)GetValue(MCNumProperty); }
            set { SetValue(MCNumProperty, value); }
        }
        public static readonly DependencyProperty MCNumProperty =
            DependencyProperty.Register("MCNum", typeof(int), typeof(NewPaperView));

        public int MACNum
        {
            get { return (int)GetValue(MACNumProperty); }
            set { SetValue(MACNumProperty, value); }
        }
        public static readonly DependencyProperty MACNumProperty =
            DependencyProperty.Register("MACNum", typeof(int), typeof(NewPaperView));

        public int TFNum
        {
            get { return (int)GetValue(TFNumProperty); }
            set { SetValue(TFNumProperty, value); }
        }
        public static readonly DependencyProperty TFNumProperty =
            DependencyProperty.Register("TFNum", typeof(int), typeof(NewPaperView));

        public int SQNum
        {
            get { return (int)GetValue(SQNumProperty); }
            set { SetValue(SQNumProperty, value); }
        }
        public static readonly DependencyProperty SQNumProperty =
            DependencyProperty.Register("SQNum", typeof(int), typeof(NewPaperView));

        public RelayCommand generatePaperCommand => new RelayCommand(() =>
        {
            if (_questionsProvider is null)
            {
                _questionsProvider = new QuestionsProvider();
            }

            if (_examPaperProvider is null)
            {
                _examPaperProvider = new ExamPaperProvider();
            }
            var sp = ((StackPanel)this.FindName("paperPnl"));
            sp.Children.Clear();

            if (FBNum > 0)
            {
                var fbs = _questionsProvider.GetList(x => x.QuestionType.Equals("FB"));
                if (fbs.Count > 0)
                {
                    for (int i = 0; i < FBNum; i++)
                    {
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        var index = r.Next(0, fbs.Count);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = fbs[index].Content,
                        };
                        sp.Children.Add(qp);
                    }
                }
                else
                {
                    MessageBox.Show("当前无填空类型的题！");
                }
            }

            if (MACNum > 0)
            {
                var macs = _questionsProvider.GetList(x => x.QuestionType.Equals("MAC"));
                if (macs.Count > 0)
                {
                    for (int i = 0; i < MACNum; i++)
                    {
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        var index = r.Next(0, macs.Count);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = $"{macs[index].Content}\n{macs[index].Options}",
                        };
                        sp.Children.Add(qp);
                    }
                }
                else
                {
                    MessageBox.Show("当前无多选类型的题！");
                }
            }

            if (MCNum > 0)
            {
                var mcs = _questionsProvider.GetList(x => x.QuestionType.Equals("MC"));
                if (mcs.Count > 0)
                {
                    for (int i = 0; i < MCNum; i++)
                    {
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        var index = r.Next(0, mcs.Count);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = $"{mcs[index].Content}\n{mcs[index].Options}",
                        };
                        sp.Children.Add(qp);
                    }
                }
                else
                {
                    MessageBox.Show("当前无单选类型的题！");
                }
            }

            if (TFNum > 0)
            {
                var tfs = _questionsProvider.GetList(x => x.QuestionType.Equals("TF"));
                if (tfs.Count > 0)
                {
                    for (int i = 0; i < TFNum; i++)
                    {
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        var index = r.Next(0, tfs.Count);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = tfs[index].Content,
                        };
                        sp.Children.Add(qp);
                    }
                }
                else
                {
                    MessageBox.Show("当前无判断类型的题！");
                }

            }

            if (SQNum > 0)
            {
                var sqs = _questionsProvider.GetList(x => x.QuestionType.Equals("SQ"));
                if (sqs.Count > 0)
                {
                    for (int i = 0; i < SQNum; i++)
                    {
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        var index = r.Next(0, sqs.Count);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = sqs[index].Content,
                        };
                        sp.Children.Add(qp);
                    }
                }
                else
                {
                    MessageBox.Show("当前无简答类型的题！");
                }
            }
        });
    }
}
