using ExamManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BussinessProvider
{
    public class DataDictionaryProvider : Provider<DataDictionary>
    {
        public DataDictionaryProvider(EMSDBContext dbContext) : base(dbContext)
        {
        }
    }
}
