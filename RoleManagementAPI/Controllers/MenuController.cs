using Newtonsoft.Json;
using RoleManagement.Model;
using RoleManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace RoleManagementAPI.Controllers
{
    //[BaseAuthenticationAttribute(IsCheck =true)]
    public class MenuController : ApiController
    {
        MenuService menuService = new MenuService();
        //拿到根据用户菜单表中的所有菜单
        [HttpGet]
        [Route("api/GetMenulist")]
        public IHttpActionResult GetMenulist()
        {
            List<Menu> menuList = menuService.getMenuList();

            var dataObj = new
            {
                code = 1,
                //data = JsonConvert.SerializeObject(menuList, Formatting.None, new JsonSerializerSettings
                //{
                //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //    PreserveReferencesHandling = PreserveReferencesHandling.None

                //})
                data = JsonConvert.SerializeObject(menuList)

            };
            return Ok(dataObj);

        }
        [HttpGet]
        [Route("api/setCookie")]
        public IHttpActionResult setCookie()
        {
            var resp = new HttpResponseMessage();

            var cookie = new CookieHeaderValue("session-id", "12345");
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return Ok();
        }
        [HttpGet]
        [Route("api/getCookie")]
        public IHttpActionResult getCookie()
        {
            string sessionId = "";

            //CookieHeaderValue cookie = Request.Headers.GetCookies("session-id").FirstOrDefault();
            CookieHeaderValue cookie = Request.Headers.GetCookies("session-id").FirstOrDefault();
            if (cookie != null)
            {
                sessionId = cookie["session-id"].Value;
            }
            return Ok();
        }
    }
}
