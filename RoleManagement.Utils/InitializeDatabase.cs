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
            //InitializeUserInfo();
            int c = 10;
        }
        public void InitializeAction()
        {
            ActionService actionService = new ActionService();
            actionService.Add(new Model.Action
            {
                ActionType = "menu"
            });
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
            int pId= actionModuleService.GetEntities(u => u.Name == "系统").FirstOrDefault().Id;
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
            int systemeId=actionModuleService.GetEntities(u => u.Name == "系统设置").FirstOrDefault().Id;
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
            int userId=actionModuleService.GetEntities(u => u.Name == "用户管理").FirstOrDefault().Id;
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
        public void InitializeRole()
        {
            RoleService roleService = new RoleService();
            ActionService actionService = new ActionService();
            List<Role> list = new List<Role>();
            list.Add(new Role
            {
                RoleName = "系统管理员",
            });
            roleService.AddRange(list);

        }

        public void InitializeUserInfo()
        {
            UserInfoService userInfoService = new UserInfoService();
            RoleService roleService = new RoleService();
            Role role = roleService.GetEntities(u => u.RoleName == "系统管理员").FirstOrDefault();
            UserInfo userinfo = userInfoService.Add(new UserInfo
            {
                UserName = "admin",
                Password = "123",
                RoleId = role.Id
            });
        }
    }
}
