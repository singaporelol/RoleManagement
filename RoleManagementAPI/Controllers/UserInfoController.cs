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
using Action = RoleManagement.Model.Action;

namespace RoleManagementWebAPI.Controllers
{
    public class UserInfoController : ApiController
    {
        UserInfoService userInfoService = new UserInfoService();
        //getUserAuth
        [HttpGet]
        [Route("api/GetUserAuth")]
        public IHttpActionResult GetUserAuth(string name)
        {
            //验证用户是否存在
            UserInfo userinfo = userInfoService.GetEntities(u => u.UserName == name).ToList()[0];
            if (userinfo == null)
            {
                return Ok(new
                {
                    code = 0,
                    data = ""
                });
            }
            //拿到用户的所有权限，菜单等
            UserAction user=userInfoService.GetAllAction(userinfo);
            var dataObj = new
            {
                code = 1,
                userMenu = JsonConvert.SerializeObject(user.MenuList,Formatting.None, new JsonSerializerSettings {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling =PreserveReferencesHandling.None }),
                userActionModule = JsonConvert.SerializeObject(user.ActionModuleList, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.None
                }),
                userinfo = new
                {
                    userinfo.UserName,
                    userinfo.Password,
                }

            };

            return Ok(dataObj);
        }

        public IHttpActionResult Get(int id)
        {
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
                }
            };
           
            return Ok(dataObj);
        }
        public IHttpActionResult Get()
        {

            var k = userInfoService.GetEntities(u=>u.Id>0).Select(m=> new {m.UserName,m.Id});
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
