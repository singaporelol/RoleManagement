using RoleManagement.EFDAL;
using RoleManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoleManagement.Service
{
    public class ActionService: BaseService<Model.Action>
    {
        public override void getCurrentDal()
        {
            GetCurrentDal = new ActionDal();
        }
    }
}
