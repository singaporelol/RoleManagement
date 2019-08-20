using Newtonsoft.Json;
using RoleManagement.Model;
using RoleManagement.Service;
using RoleManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Action = RoleManagement.Model.Action;
using System.Collections;
using System.Web.Services;
using System.Web;
using RoleManagementAPI;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RoleManagementWebAPI.Controllers
{
    
    public class UserInfoController : ApiController
    {
        UserInfoService userInfoService = new UserInfoService();
        //getUserAuth
        [HttpGet]
        [Route("api/GetUserAuth")]
        [WebMethod(EnableSession=true)]
        [BaseAuthenticationAttribute(IsCheck =false)]
        public IHttpActionResult GetUserAuth(string username,string password)
        {
            //验证用户是否存在
            UserInfo userinfo = userInfoService.GetEntities(u => u.UserName == username && u.Password==password).ToList().FirstOrDefault();
            if (userinfo == null)
            {
                return Ok(new
                {
                    code = 0,
                    errMsg = "账号或密码错误，请重新输入"
                });
            }
            //把用户登录信息存到session中
            HttpContext.Current.Session.Add("userinfo", userinfo);
            //var session_value = HttpContext.Current.Session["abc"];
            string userLoginId = Guid.NewGuid().ToString();
            var resp = new HttpResponseMessage();
            resp.Headers.AddCookies(new CookieHeaderValue[] { new CookieHeaderValue("Authorization1", userLoginId) });
            
            //拿到用户的所有权限，菜单等
            UserAction user = userInfoService.GetAllAction(userinfo);
            var dataObj = new
            {
                code = 1,
                #region 
                //userAllAction = JsonConvert.SerializeObject(user, Formatting.None, new JsonSerializerSettings
                //{
                //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //    PreserveReferencesHandling = PreserveReferencesHandling.None
                //}),
                //userMenu = JsonConvert.SerializeObject(user.MenuList, Formatting.None, new JsonSerializerSettings
                //{
                //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //    PreserveReferencesHandling = PreserveReferencesHandling.None
                //}),
                //userActionModule = JsonConvert.SerializeObject(user.ActionModuleList, Formatting.None, new JsonSerializerSettings
                //{
                //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //    PreserveReferencesHandling = PreserveReferencesHandling.None
                //}),
                #endregion
                userinfo = new
                {
                    userinfo.UserName,
                    userinfo.Password,
                }

            };

            return Ok(dataObj);
        }

        [BaseAuthenticationAttribute(IsCheck = true)]
        [HttpGet]
        [Route("api/GetUserinfoByName")]
        public IHttpActionResult GetUserinfoByName([FromUri] string UserName)
        {
            UserInfo userinfo = userInfoService.GetEntities(u=>u.UserName==UserName).ToList().FirstOrDefault();
            
            var dataObj = new {
                code = 0,
                data = new
                {
                    exist = userinfo==null?false:true
                }
            };
            return Ok(dataObj);
        }
        [BaseAuthenticationAttribute(IsCheck = true)]
        [HttpPut]
        [Route("api/editUserForm")]
        public IHttpActionResult EditUserForm([FromBody] dynamic data)
        {
            string UserName = (String)data["UserName"].Value;
            int Id = Convert.ToInt32(data["Id"].Value);
            UserInfo userinfo = userInfoService.GetEntities(u=>u.Id==Id).FirstOrDefault();
            userinfo.UserName = UserName;
            bool result=userInfoService.Update(userinfo);
            if (result == false)
            {
                return Ok(new
                {
                    code = 0,
                    data = ""
                });
            }
            return Ok(new { code = 1 });
        }
        [HttpPost]
        [Route("api/addUserForm")]
        [BaseAuthenticationAttribute(IsCheck = true)]
        public IHttpActionResult AddUserForm([FromBody] dynamic data)
        {
            string UserName = (String)data["UserName"].Value;
            string Password = (String)data["Password"].Value;
            UserInfo userinfo = userInfoService.GetEntities(u => u.UserName==UserName).FirstOrDefault();
            if (userinfo != null)
            {
                return Ok(new
                {
                    code = 0,
                    data = ""
                });
            }
            userInfoService.Add(new UserInfo {
                UserName=UserName,
                Password=Password
            });
            return Ok(new { code = 1 });
        }
        [HttpDelete]
        [Route("api/deleteUserFormByIds")]
        [BaseAuthenticationAttribute(IsCheck = true)]
        public IHttpActionResult DeleteUserFormByIds([FromUri] string Id)
        {
            
            List<int> list=JsonConvert.DeserializeObject<List<int>>(Id);
            //userInfoService
            IQueryable<UserInfo> userinfoList=userInfoService.GetEntities(r => list.Contains(r.Id));
            bool result=userInfoService.DeleteRange(userinfoList);
            if (!result)
            {
                return Ok(new { code = 0 });
            }
            return Ok(new { code = 1 });
        }
        [BaseAuthenticationAttribute(IsCheck = true)]
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
        [BaseAuthenticationAttribute(IsCheck = true)]
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
