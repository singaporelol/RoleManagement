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
        public List<ActionModule> GetUserActionModule(UserInfo userinfo)
        {
            List<ActionModule> listActionModule = new List<ActionModule>();
            //userinfo.Role.Action.Where(u => u.ActionType == "module").FirstOrDefault();
            return listActionModule;
        }
        public List<Menu> GetUserMenu(UserInfo userinfo)
        {
            //拿到用户所对应的角色
            var allRole = userinfo.Role;
            //拿到角色所对应的权限
            var allAction = from r in allRole
                            select r.Action;
            List<Menu> AllMenu = new List<Menu>();
            //foreach (var item in allAction)
            //{

            //}
            //    .Where(u => u.ActionType == "menu").FirstOrDefault().Menu.OrderBy(v => v.ParentId).ToList();
            //List<Menu> rootList = LoadUserMenu(menu, 0);
            List<Menu> rootList = new List<Menu>();
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
        
        /// <summary>
        /// 递归加载菜单
        /// </summary>
        /// <param name="menu">List集合</param>
        /// <param name="Id">父级ID</param>
        /// <returns></returns>
        public List<Menu> LoadUserMenu(List<Menu> menu, int pId)
        {
            List<Menu> rootList = new List<Menu>();
            List<Menu> rootMenu = menu.Where(u => u.ParentId == pId).ToList();
            foreach (var item in rootMenu)
            {
                rootList.Add(new Menu
                {
                    Title = item.Title,
                    Id = item.Id,
                    Url = item.Url,
                    ChildMenu = LoadUserMenu(menu, item.Id)
                });

            }
            return rootList;
        }

    }
}
