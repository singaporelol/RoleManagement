using RoleManagement.EFDAL;
using RoleManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace RoleManagement.Service
{
    public class UserInfoService : BaseService<UserInfo>
    {
        public override void getCurrentDal()
        {
            GetCurrentDal = new UserInfoDal();
        }
        
        public UserAction GetAllAction(UserInfo userinfo)
        {
            UserAction userAction = new UserAction();
            
            //拿到用户所对应的角色
            var allRole = userinfo.Role;
            //拿到角色所对应的权限
            var roleActionList= (from r in allRole
                            select r.Action).ToList();
            List<Menu> AllMenu = new List<Menu>();
            List<ActionModule> AllActionModule = new List<ActionModule>();
            foreach (var actionList in roleActionList)
            {
               foreach(var item in actionList)
                {
                    //加载登录用户对应的权限菜单
                    AllMenu = AllMenu.Concat(item.Menu).Distinct().OrderBy(v=>v.ParentId).ToList();
                    //加载登录用户对应的权限模块
                    AllActionModule = AllActionModule.Concat(item.ActionModule).Distinct().OrderBy(v => v.ParentId).ToList();
                }
            }
            //把菜单数组修改为树状菜单
            //userAction.MenuList = LoadUserMenu(AllMenu, 0);
            //userAction.ActionModuleList = LoadActionModuleMenu(AllActionModule, 0);
            userAction.MenuList = AllMenu;
            userAction.ActionModuleList =AllActionModule;
            return userAction;
            
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
        public List<ActionModule> LoadActionModuleMenu(List<ActionModule> actionModulemenu, int pId)
        {
            List<ActionModule> rootList = new List<ActionModule>();
            List<ActionModule> rootMenu = actionModulemenu.Where(u => u.ParentId == pId).ToList();
            foreach (var item in rootMenu)
            {
                rootList.Add(new ActionModule
                {
                    Name=item.Name,
                    Id = item.Id,
                    Url = item.Url,
                    ChildMenu = LoadActionModuleMenu(actionModulemenu, item.Id)
                });

            }
            return rootList;
        }
    }
}
