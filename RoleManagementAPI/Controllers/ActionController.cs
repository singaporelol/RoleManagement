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
using Action = RoleManagement.Model.Action;
using Newtonsoft.Json;

namespace RoleManagementWebAPI.Controllers
{
    public class ActionController : ApiController
    {
        ActionService actionService = new ActionService();
        public IHttpActionResult Get()
        {
            //var k = actionService.GetEntities(u => u.Id > 0).Select(m => new { m.Id, m.ActionName, m.Url });
            var k = actionService.GetEntities(u => u.Id > 0).Select(m => new { m.Id });
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
        [Route("api/addAction")]
        public IHttpActionResult Post([FromBody] dynamic data)
        {
            //JsonSerializer serializer = new JsonSerializer();

            Action action = actionService.Add(new Action()
            {
                //ActionName = data["ActionName"].Value,
                //Url = data["Url"].Value,
                
            });
            //把权限给系统管理员
            RoleService roleservice = new RoleService();
            var role= roleservice.GetEntities(u => u.Id == 1).FirstOrDefault();
            role.Action.Add(action);
            roleservice.Update(role);
            if (action == null)
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