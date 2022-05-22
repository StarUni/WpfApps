using ExamManageSystem.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using Models;
using Models.BussinessProvider;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExamManageSystem.ViewModel
{
    public class HomeViewModel : ObservableObject
    {
        private readonly QuestionsProvider _questionsProvider = null;
        private readonly DataDictionaryProvider _dataDictionaryProvider = null;

        public HomeViewModel(EMSDBContext context)
        {
            _questionsProvider = new QuestionsProvider(context);
            _dataDictionaryProvider = new DataDictionaryProvider(context);
        }

        public RelayCommand<UserControl> ChooseFileCmd => new RelayCommand<UserControl>(async (uc) => 
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "选择文件",
                Multiselect = true,
                Filter = "文件|*.*"
            };
            if (!(bool)openFileDialog.ShowDialog())
            {
                return; //被点了取消
            }
            var fn = openFileDialog.FileName;
            ((TextBox)uc.FindName("filenameTB")).Text = fn;
            
            var questionType = _dataDictionaryProvider.GetList(x => x.DataType.Equals("Question"));
            //加载Word文档
            Document document = new Document(fn);
            //document.LoadFromFile(fn);

            List<Questions> qs = new List<Questions>();
            //遍历节和段落，获取段落中的文本
            foreach (Section section in document.Sections)
            {
                Questions questions = new Questions();

                foreach (Paragraph paragraph in section.Paragraphs)
                {
                    if (string.IsNullOrEmpty(paragraph.Text) || paragraph is null) continue;
                    var qt = questionType.FirstOrDefault(x => paragraph.Text.Contains(x.DataName));
                    if (qt is null)
                    {
                        if(questions.QuestionType is null) continue;
                        if (paragraph.Text.Contains("答案"))
                        {
                            questions.Answer = paragraph.Text;
                        }
                        else
                        {
                            if (questions.QuestionType.Equals("MAC") || questions.QuestionType.Equals("MC"))
                            {
                                if (!string.IsNullOrEmpty(questions.Content))
                                {
                                    questions.Options += paragraph.Text;
                                    continue;
                                }
                            }
                            questions.Content = paragraph.Text;
                            continue;
                        }
                    }
                    else
                    {
                        if (qt.ShortCode != null)
                        {
                            if (questions.QuestionType is null || !questions.QuestionType.Equals(qt.ShortCode))
                            {
                                questions = new Questions();
                            }
                            questions.QuestionType = qt.ShortCode;
                            continue;
                        }
                    }
                    var q = new Questions();
                    q = questions;
                    qs.Add(q);
                    questions = new Questions
                    {
                        QuestionType = q.QuestionType
                    };
                }
            }
            
            await Task.Run(() => 
            {
                qs.ForEach(x => x.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));
                var num = _questionsProvider.InsertRange(qs);
                MessageBox.Show($"已成功导入{num}道试题");
            });
        });
    }
}
