using RoleManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleManagementWebAPI.Models
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }


    }
}