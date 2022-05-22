using ExamManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BussinessProvider
{
    public class QuestionsProvider : Provider<Questions>
    {
        public QuestionsProvider(EMSDBContext dbContext) : base(dbContext)
        {
        }
    }
}
