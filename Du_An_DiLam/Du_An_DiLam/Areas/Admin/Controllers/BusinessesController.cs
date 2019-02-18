using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.DataModel;
using DataBase;
using Du_An_DiLam.Areas.Admin.Models.BusinessesModel;
using Newtonsoft.Json;

namespace Du_An_DiLam.Areas.Admin.Controllers
{ //các controllers
    public class BusinessesController : Controller
    {
        private MenShopDbContext db = new MenShopDbContext();

        //lấy controler (tức là cách danh sách các bảng) cập nhập danh sách nghiệp vụ
        public string updateBusiness()
        {
           
                // nghiệp vụ xử lý lấy action và controller
                ActionController rc = new ActionController();
                List<Type> listControllerType = rc.GetController("Du_An_DiLam.Areas.Admin.Controllers");// truyền theo namespace, nếu để là controller thì sẽ lấy cả người dùng và quản trị
                 //lấy ra mã nghiệp vụ(tức mã của controller)
                List<string> listControllerOLD = db.businesses.Select(c => c.BusinessId).ToList();
                // lấy ra  các tên action
                 List<string> listPermistionOLD = db.Permisstion_Groups.Select(p => p.Permisstion_GroupId).ToList();
            
                foreach (var c in listControllerType)
                {
                    // kiểm tra nếu tồn tại trong csdl rồi thì không add nữa
                    if (!listControllerOLD.Contains(c.Name))
                    {
                        Business b = new Business()
                        {
                            BusinessId = c.Name,
                            BusinessName = "chưa có mô tả"
                        };
                        db.businesses.Add(b);
                    db.SaveChanges();
                }
                    List<string> listAction = rc.GetActions(c);
                    foreach (var p in listAction)
                    {
                        if (!listPermistionOLD.Equals(c.Name + "-" + p))
                        {
                        Permisstion_Group permisstion_Group = new Permisstion_Group()
                        {
                            Permisstion_GroupId = "p" + Guid.NewGuid(),
                                PermistionName = c.Name +"-" +p,
                                Depscription = p + "chưa có mô tả",
                                BusinessId = c.Name

                            };
                            db.Permisstion_Groups.Add(permisstion_Group);
                        db.SaveChanges();
                    }

                    }
                    

                }
                return "success";
           
           
           

        }


        public ActionResult getall() {
            var data = db.businesses.ToList();
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        public  string update(Business b )
        {
            try
            {
                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }
        }
       

      
        
    }
}
