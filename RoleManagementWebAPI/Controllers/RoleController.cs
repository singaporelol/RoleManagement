using Newtonsoft.Json.Linq;
using RoleManagement.Model;
using RoleManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;

namespace RoleManagementWebAPI.Controllers
{
    public class RoleController : ApiController
    {
        //[Route("api/role")] 默认的是api/controller名字
        RoleService roleService = new RoleService();
        public IHttpActionResult Get()
        {
            var k = roleService.GetEntities(u => u.Id > 0).Select(m => new { m.Id, m.RoleName });
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
                data = k.ToList()
            };

            return Ok(dataObj);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("api/addRole")]
        public IHttpActionResult Post([FromBody] dynamic data)
        {
            Role role=roleService.Add(new Role()
            {
                RoleName = (String)data["RoleName"].Value
            });
            if (role == null)
            {
                return Ok(new
                {
                    code=0,
                    data=""
                });
            }
            return Ok(new { code=1});
        }
        [Route("api/editRole")]
        public IHttpActionResult Put([FromBody] dynamic data)
        {
             bool result =roleService.Update(new Role()
            {
                RoleName = (String)data["RoleName"].Value,
                Id=Convert.ToInt32(data["Id"].Value)
            });
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
        [Route("api/deleteRole")]
        public IHttpActionResult DeleteRole([FromUri] int Id, string RoleName)
        {
            
            bool result = roleService.Delete(new Role()
            {
                RoleName = (String)RoleName,
                Id =Id
            });
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
        [Route("api/deleteRoles")]
        public IHttpActionResult DeleteRoles([FromUri] string ids)
        {
            Array idarr=ids.Substring(1, ids.Length - 2).Split(',');
            
            bool result = roleService.DeleteRange(idarr);
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
    }
}
