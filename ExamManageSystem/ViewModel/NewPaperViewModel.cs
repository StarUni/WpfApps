using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExamManageSystem.ViewModel
{
    public class NewPaperViewModel : ViewModelBase
    {
        public NewPaperViewModel()
        {
            GeneratePaper();
        }

        private void GeneratePaper()
        {

            MessageBox.Show("hhhhhhh");
        }
    }
}
