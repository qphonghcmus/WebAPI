using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LoadUserMethod();
        }

        private void LoadUserMethod()
        {
            UserRoles.user_method_dict = new Dictionary<UserMethodSub, bool>(new UserMethodEqualityComparer());
            IList<UserMethod> userMethodList = new List<UserMethod>();
            using (var repo = FluentNHibernateHelper.GetRepository())
            {
                userMethodList = repo.GetAll<UserMethod>();
            }

            foreach (var userMethod in userMethodList)
            {
                UserRoles.user_method_dict.Add(new UserMethodSub(userMethod), true);
            }
        }
    }
}
