using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Du_An_DiLam.Areas.Admin.Controllers
{
    public class WarningController : Controller
    {
        // GET: Admin/Warning
        protected void Show(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "thanhcong")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "loi")
            {
                TempData["AlertType"] = "alert-danger";
            }
            else if (type == "canhbao")
            {
                TempData["AlertType"] = "alert-warning";
            }
        }
        public ActionResult test() {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            if (actionName!=null)
            {
                return View();
            }
            return View();
        }
    }
}