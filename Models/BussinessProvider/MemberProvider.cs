using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BussinessProvider
{
    public class MemberProvider : Provider<Member>
    {
        public CargoDBEntities CargoDBEntities
        {
            get
            {

                return base.dbContext = (new CargoDBEntities());
            }
        }
    }
}
