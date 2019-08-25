using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Auth
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var userName = Thread.CurrentPrincipal.Identity.Name;
            Method methodObj = new Method();

            var action = actionContext.Request.Method.Method.ToLower();
            var method = actionContext.ActionDescriptor.ActionName;

            var nParams = actionContext.Request.GetRouteData().Values.Count;

            using (var repo = FluentNHibernateHelper.GetRepository())
            {
                methodObj = repo.Where<Method>(m => m.Params == nParams && m.Name == method && m.Action == action).FirstOrDefault();
                if (methodObj != null)
                {
                    UserMethodSub ums = new UserMethodSub(userName, methodObj.Id);
                    if (UserRoles.user_method_dict.ContainsKey(ums))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}