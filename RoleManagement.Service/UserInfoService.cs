using RoleManagement.EFDAL;
using RoleManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Action = RoleManagement.Model.Action;

namespace RoleManagement.Service
{
    public class UserInfoService : BaseService<UserInfo>
    {
        public override void getCurrentDal()
        {
            GetCurrentDal = new UserInfoDal();
        }
        public List<Action> GetUserMenu(string username)
        {
            UserInfo userinfo = GetCurrentDal.GetEntities(u => u.UserName == username).FirstOrDefault();
            //循环遍历加载菜单
            List<Action> rootList = LoadUserMenu(userinfo,0);
            return rootList;
            
            #region 取消2级菜单
            //List<Action> rootList = new List<Action>();
            //foreach (var item in action)
            //{
            //    if (item.ParentId == 0)
            //    {
            //        rootList.Add(new Action
            //        {
            //            ActionName = item.ActionName,
            //            Id = item.Id,
            //            IsMenu = item.IsMenu,
            //            Url = item.Url,
            //            ParentId = item.ParentId,
            //            ChildMenu = new List<Model.Action>()
            //        });
            //    }
            //}
            //foreach (var item in rootList)
            //{
            //    IEnumerable<Action> actionList = action.Where(u => u.ParentId == item.Id);
            //    if (actionList.FirstOrDefault() == null) continue;
            //    foreach (var child in actionList)
            //    {
            //        item.ChildMenu.Add(new Action
            //        {
            //            ActionName = child.ActionName,
            //            Id = child.Id,
            //            IsMenu = child.IsMenu,
            //            Url = child.Url,
            //            ParentId = child.ParentId,
            //            ChildMenu = new List<Model.Action>()
            //        });
            //    }
            //} 
            #endregion

        }
        //递归循环加载菜单
        public List<Action> LoadUserMenu(UserInfo userinfo, int Id)
        {
            List<Action> rootList = new List<Action>();
            IEnumerable<Action> action = userinfo.Role.Action.Where(u => u.IsMenu == true && u.ParentId==Id);
            foreach (var item in action)
            {
                rootList.Add(new Action
                {
                    ActionName = item.ActionName,
                    Id = item.Id,
                    IsMenu = item.IsMenu,
                    Url = item.Url,
                    ParentId = item.ParentId,
                    ChildMenu = LoadUserMenu(userinfo,item.Id)
                });

            }
            return rootList;
        }

    }
}
