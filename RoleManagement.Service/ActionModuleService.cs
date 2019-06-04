using RoleManagement.EFDAL;
using RoleManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleManagement.Service
{
   public class ActionModuleService:BaseService<ActionModule>
    {
        public override void getCurrentDal()
        {
            GetCurrentDal = new ActionModuleDal();
        }
    }
}
