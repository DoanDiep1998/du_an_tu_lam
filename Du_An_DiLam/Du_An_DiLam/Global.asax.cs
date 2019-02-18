using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Du_An_DiLam
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start() {
            // quản trị
            Session["UserId"] = null;
            Session["UserName"] = null;
            Session["FullName"] = null;
            Session["Gender"] = null;
            Session["Email"] = null;
            Session["Phone"] = null;
            Session["Avatar"] = null;
            Session["IsAdmin"] = null;

            // người dùng
            Session["CustomerId"] = null;
            Session["CustomerName"] = null;
            Session["Email"] = null;
            Session["Gender "] = null;
            Session["Birthday "] = null;
            Session["Phone "] = null;
            Session["User "] = null;
            Session["Password "] = null;
            Session["Avatar "] = null;
            Session["Address "] = null;


        }
    }
}
