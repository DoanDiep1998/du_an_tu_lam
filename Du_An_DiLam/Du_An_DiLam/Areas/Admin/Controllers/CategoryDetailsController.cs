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
using DataBase.Repository;
using Newtonsoft.Json;
using Du_An_DiLam.Models;

namespace Du_An_DiLam.Areas.Admin.Controllers
{
    public class CategoryDetailsController : Controller
    {
        private Repository<CategoryDetail> _CategoryDetai = new Repository<CategoryDetail>();
        private Repository<Category> _category = new Repository<Category>();
        // GET: Admin/CategoryDetails
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetAll(int? page, int? pageSize) {
            if (page== null)
            {
                page = 1;
            }
            if (pageSize==null)
            {
                pageSize = 3;
            }
            var data = _CategoryDetai.Getall().OrderByDescending(x=>x.CategoryDetailId).Topagelist((int)page,(int)pageSize);
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCategory()
        {
            var data = _category.Getall();
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public string Create(CategoryDetail category)
        {

            category.CategoryDetailId = Guid.NewGuid() + DateTime.Now.ToString("ddMMyyyy - hhmmss");
            category.CreateDate = DateTime.Now;
            _CategoryDetai.Add(category);

            return "success";
        }
        public string Edit(CategoryDetail category) {
            category.CreateDate = DateTime.Now;
            _CategoryDetai.Edit(category);
            return "success";
        }
        public ActionResult Details(string id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
           var detail= _CategoryDetai.Find(id);
            return View(detail);

        }
        public string Delete (string Id)
        {
            try
            {
                _CategoryDetai.Delete(Id);
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }



        }



    }
}
