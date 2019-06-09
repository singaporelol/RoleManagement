using RoleManagement.Model;
using RoleManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleManagement.Utils
{
    public class InitializeDatabase
    {
        public InitializeDatabase()
        {
            //InitializeMenu();
            //InitializeActionModule();
            //InitializeAction();
            //InitializeRole();
            InitializeUserInfo();
        }
        public void InitializeUserInfo()
        {
            UserInfoService userInfoService = new UserInfoService();
            RoleService roleService = new RoleService();
            UserInfo userinfo = userInfoService.Add(new UserInfo
            {
                UserName = "admin",
                Password = "123",
            });
            //UserInfo userinfo = userInfoService.GetEntities(u => u.Id == 1).FirstOrDefault();
            roleService.GetEntities(u => u.RoleName == "系统管理员").ToList().ForEach(m=>m.UserInfo.Add(userinfo));
            
        }
        public void InitializeRole()
        {
            RoleService roleService = new RoleService();
            ActionService actionService = new ActionService();
            
            Role role=roleService.Add(new Role
            {
                RoleName = "系统管理员",
            });
            //关联角色和权限类型（Menu和模块）
            actionService.GetEntities(u => u.Id > 0).ToList().ForEach(m => m.Role.Add(role));

        }

        public void InitializeAction()
        {
            ActionService actionService = new ActionService();
            Model.Action action=actionService.Add(new Model.Action
            {
                ActionType = "menu"
            });
            //关联Menu菜单和权限
            MenuService menuService = new MenuService();
            menuService.GetEntities(u => u.Id > 0).ToList().ForEach(m => m.Action.Add(action));
            Model.Action module = actionService.Add(new Model.Action
            {
                ActionType = "module"
            });
            //关联ActionModule表和Action表
            ActionModuleService actionModuleService = new ActionModuleService();
            actionModuleService.GetEntities(u => u.Id > 0).ToList().ForEach(m => m.Action.Add(module));
        }
        public void InitializeActionModule()
        {
            ActionModuleService actionModuleService = new ActionModuleService();
            List<ActionModule> actionModuleLIst = new List<ActionModule>();
            actionModuleService.Add(new ActionModule
            {

                ParentId = 0,
                Name = "系统",
                Url = "/system",
            });
            int pId = actionModuleService.GetEntities(u => u.Name == "系统").FirstOrDefault().Id;
            actionModuleService.Add(new ActionModule
            {
                ParentId = pId,
                Name = "系统设置",
                Url = "/systemsetting"
            });
            actionModuleService.Add(new ActionModule
            {
                ParentId = pId,
                Name = "权限管理",
                Url = "/action"
            });
            actionModuleService.Add(new ActionModule
            {
                ParentId = pId,
                Name = "用户管理",
                Url = "/user"
            });
            int systemeId = actionModuleService.GetEntities(u => u.Name == "系统设置").FirstOrDefault().Id;
            actionModuleLIst.Add(new ActionModule
            {
                ParentId = systemeId,
                Name = "菜单管理",
                Url = "/menu"
            });
            int cId = actionModuleService.GetEntities(u => u.Name == "权限管理").FirstOrDefault().Id;
            actionModuleLIst.Add(new ActionModule
            {

                ParentId = cId,
                Name = "功能管理",
                Url = "/function",
            });
            actionModuleLIst.Add(new ActionModule
            {

                ParentId = cId,
                Name = "角色管理",
                Url = "/role",
            });
            actionModuleLIst.Add(new ActionModule
            {

                ParentId = cId,
                Name = "角色权限管理",
                Url = "/roleauth",
            });
            actionModuleLIst.Add(new ActionModule
            {

                ParentId = cId,
                Name = "角色用户管理",
                Url = "/roleuser",
            });
            actionModuleLIst.Add(new ActionModule
            {

                ParentId = cId,
                Name = "用户角色管理",
                Url = "/userrole",
            });
            int userId = actionModuleService.GetEntities(u => u.Name == "用户管理").FirstOrDefault().Id;
            actionModuleLIst.Add(new ActionModule
            {

                ParentId = userId,
                Name = "用户管理",
                Url = "/usermanage",
            });
            actionModuleService.AddRange(actionModuleLIst);
        }
        public void InitializeMenu()
        {
            MenuService menuService = new MenuService();
            List<Menu> menuList = new List<Menu>();
            menuList.Add(new Menu
            {
                ParentId = 0,
                Title = "权限管理",
                Url="/action"
            });
            menuList.Add(new Menu
            {
                ParentId = 0,
                Title = "系统设置",
                Url="/system"
            });
            menuList.Add(new Menu
            {
                ParentId = 0,
                Title = "用户管理",
                Url="/user"
            });
            menuService.AddRange(menuList);
            List<Menu> childMenuList = new List<Menu>();
            int systemId=menuService.GetEntities(u => u.Title == "系统设置" && u.ParentId==0).FirstOrDefault().Id;
            childMenuList.Add(new Menu
            {
                ParentId = systemId,
                Title = "菜单管理",
                Url="/menu"
            });
            int menuId = menuService.GetEntities(u => u.Title == "用户管理" && u.ParentId==0).FirstOrDefault().Id;
            childMenuList.Add(new Menu
            {
                ParentId = menuId,
                Title = "用户管理",
                Url="/user"
            });
            int actionId = menuService.GetEntities(u => u.Title == "权限管理" && u.ParentId==0).FirstOrDefault().Id;
            childMenuList.Add(new Menu
            {
                ParentId = actionId,
                Title = "权限管理",
                Url="/action"
            });
            childMenuList.Add(new Menu
            {
                ParentId = actionId,
                Title = "角色管理",
                Url="/role"
            });
            childMenuList.Add(new Menu
            {
                ParentId = actionId,
                Title = "角色权限管理",
                Url="/roleaction"
            });
            childMenuList.Add(new Menu
            {
                ParentId = actionId,
                Title = "角色用户管理",
                Url="/roleuser"
            });
            childMenuList.Add(new Menu
            {
                ParentId = actionId,
                Title = "用户角色管理",
                Url="/userrole"
            });
            menuService.AddRange(childMenuList);
        }
        
    }
}
