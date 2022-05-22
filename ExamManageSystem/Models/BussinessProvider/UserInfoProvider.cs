using ExamManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BussinessProvider
{
    public class UserInfoProvider : Provider<UserInfo>
    {
        public UserInfoProvider(EMSDBContext dbContext) : base(dbContext)
        {
        }
    }
}
