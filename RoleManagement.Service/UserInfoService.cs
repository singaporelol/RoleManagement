using RoleManagement.EFDAL;
using RoleManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoleManagement.Service
{
    public class UserInfoService : BaseService<UserInfo>
    {
        public override void getCurrentDal()
        {
            GetCurrentDal = new UserInfoDal();
        }
    }
}
