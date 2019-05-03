using Newtonsoft.Json;
using RoleManagement.Model;
using RoleManagement.Service;
using RoleManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RoleManagementWebAPI.Controllers
{
    public class UserInfoController : ApiController
    {

        public IHttpActionResult Get(int id)
        {
            
            UserInfoService userInfoService = new UserInfoService();

            var k= userInfoService.GetEntityById(id);
            if (k == null)
            {
                return Ok(new {
                    code=0,
                    data=""
                });
            }
            var dataObj = new
            {
                code = 1,
                data=new UserInfoDTO()
                {
                    Id=k.Id,
                    UserName=k.UserName,
                    Password=k.Password,
                    RoleName=k.Role.RoleName,
                }
            };
           
            return Ok(dataObj);
        }
        public IHttpActionResult Get()
        {

            UserInfoService userInfoService = new UserInfoService();

            var k = userInfoService.GetEntities(u=>u.Id>0).Select(m=> new {m.Role.RoleName,m.UserName,m.Id});
            if (k == null)
            {
                return Ok(new
                {
                    code = 0,
                    data = ""
                });
            }
            var dataObj = new
            {
                code = 1,
                data=k.ToList()
            };

            return Ok(dataObj);
        }
    }
}
