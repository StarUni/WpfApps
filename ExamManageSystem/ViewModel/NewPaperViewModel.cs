using ExamManageSystem.DoMain.AppEngine;
using ExamManageSystem.Models;
using ExamManageSystem.UserControls.Components;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Models;
using Models.BussinessProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExamManageSystem.ViewModel
{
    public class NewPaperViewModel : ObservableObject
    {
        private readonly QuestionsProvider _questionsProvider = null;
        private readonly List<Questions> _questions = null;
        private StackPanel _stackPanel = null;

        public int FBNum { get; set; }
        public int MCNum { get; set; }
        public int MACNum { get; set; }
        public int TFNum { get; set; }
        public int SQNum { get; set; }
        public int CCNum { get; set; }

        public NewPaperViewModel(EMSDBContext context)
        {
            _questionsProvider = new QuestionsProvider(context);
            _questions = new List<Questions>();
        }

        public RelayCommand<UserControl> GeneratePaperCommand => new RelayCommand<UserControl>(async (uc) =>
        {
            var papername = $"{DateTime.Now:yyyy-MM-dd_HH:mm:ss}_{AppData.Instance.UserInfo.UserName}";
            _stackPanel = uc.FindName("paperPnl") as StackPanel;
            _stackPanel.Children.Clear();
            if (FBNum > 0)
            {
                var fbs = _questionsProvider.GetList(x => x.QuestionType.Equals("FB"));
                if (fbs.Count > 0)
                {
                    for (int i = 0; i < FBNum; i++)
                    {
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        var index = r.Next(0, fbs.Count);
                        _questions.Add(fbs[index]);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = fbs[index].Content,
                        };
                        _stackPanel.Children.Add(qp);
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
                        _questions.Add(macs[index]);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = $"{macs[index].Content}\n{macs[index].Options}",
                        };
                        _stackPanel.Children.Add(qp);
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
                        _questions.Add(mcs[index]);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = $"{mcs[index].Content}\n{mcs[index].Options}",
                        };
                        _stackPanel.Children.Add(qp);
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
                        _questions.Add(tfs[index]);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = tfs[index].Content,
                        };
                        _stackPanel.Children.Add(qp);
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
                        _questions.Add(sqs[index]);
                        QuestionPanel qp = new QuestionPanel
                        {
                            TopicContent = sqs[index].Content,
                        };
                        _stackPanel.Children.Add(qp);
                    }
                }
                else
                {
                    MessageBox.Show("当前无简答类型的题！");
                }
            }

            await Task.Run(() =>
            {
                foreach (var item in _questions)
                {
                    item.PaperName = papername;
                    _ = _questionsProvider.Update(item);
                }
            });
        });

        public RelayCommand DisplayAnswerCommand => new RelayCommand(() =>
        {
            if (_stackPanel is null || _questions is null)
            {
                MessageBox.Show("请先生成试卷！");
                return;
            }
            foreach (var item in _stackPanel.Children)
            {
                if (item is QuestionPanel)
                {
                    QuestionPanel qp = item as QuestionPanel;
                    if (!qp.TopicContent.Contains('\n'))
                    {
                        qp.TopicAnswer = _questions.Where(x => x.Content.Equals(qp.TopicContent)).Select(a => a.Answer).First();
                    }
                    else
                    {
                        var topicContent = qp.TopicContent.Split('\n')[0];
                        qp.TopicAnswer = _questions.Where(x => x.Content.Equals(topicContent)).Select(a => a.Answer).First();
                    }

                }
            }
        });
    }
}
