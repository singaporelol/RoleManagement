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
            //InitializeRole();
            //InitializeUserInfo();
            //InitializeMenu();
            InitializeActionModule();
        }
        public void InitializeActionModule()
        {

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
        public void InitializeRole()
        {
            RoleService roleService = new RoleService();
            List<Role> list = new List<Role>();
            list.Add(new Role
            {
                RoleName = "系统管理员"
            });
            list.Add(new Role
            {
                RoleName = "管理员"
            });
            roleService.AddRange(list);
        }
    }
}
