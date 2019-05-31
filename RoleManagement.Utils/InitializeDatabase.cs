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
