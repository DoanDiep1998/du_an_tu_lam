using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.DataModel;
using DataBase.Repository;
using Du_An_DiLam.Models;

namespace Du_An_DiLam.Areas.Admin.Controllers
{
    
    public class LoginController : Controller
    {
        private Repository<User> _user = new Repository<User>();
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( string user, string password)
        {
            string PassMd5 = Common.EncryptMD5(user + password);
            try
            {
             var use = _user.FirstOf(x => x.UserName == user && x.Password ==PassMd5 && x.Allowed ==true  );
                if (use !=null)
                {
                    Session["UserId"] = use.UserId;
                    Session["UserName"] = use.UserName;
                    Session["FullName"] = use.FullName;
                    Session["Gender"] = use.Gender;
                    Session["Email"] = use.Email;
                    Session["Phone"] = use.Phone;
                    Session["Avatar"] = use.Avatar;
                    Session["IsAdmin"] = use.IsAdmin;
                    return RedirectToAction("Index","Home");
                }
                ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền đăng nhập!";
            }
            catch (Exception)
            {

                ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền đăng nhập!";
            }
            return View();
        }
    }
}