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

namespace RoleManagementWebAPI.Controllers
{
    public class ActionController : ApiController
    {
        //ActionService actionService = new ActionService();
        //public IHttpActionResult Get()
        //{
        //    var k = actionService.GetEntities(u => u.Id > 0).Select(m => new { m.Id, m.ActionName, m.ParentId, m.Url, m.IsMenu });
        //    if (k == null)
        //    {
        //        return Ok(new
        //        {
        //            code = 0,
        //            data = ""
        //        });
        //    }
        //    var dataObj = new
        //    {
        //        code = 1,
        //        data = k.ToList()
        //    };

        //    return Ok(dataObj);
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[Route("api/addAction")]
        //public IHttpActionResult Post([FromBody] dynamic data)
        //{
        //    Action action = actionService.Add(new Action()
        //    {
        //        ParentId = data["ParentId"].Value,
        //        ActionName = data["ActionName"].Value,
        //        Url=data["Url"].Value,
        //        IsMenu=data["IsMenu"].Value

        //    });
        //    if (action == null)
        //    {
        //        return Ok(new
        //        {
        //            code = 0,
        //            data = ""
        //        });
        //    }
        //    return Ok(new { code = 1 });
        //}
    }
}