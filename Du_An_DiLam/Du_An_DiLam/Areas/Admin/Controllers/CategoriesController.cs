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
using Du_An_DiLam.Models;
using Newtonsoft.Json;

namespace Du_An_DiLam.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private Repository<Category> _category = new Repository<Category>();

       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll(string txtSearch, string txtSelect, int? page, int? pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 2;
            }
            //tìm kiếm theo tên
            if (txtSearch != null && txtSelect == "Name")
            {
                var dataSearch = _category.Getall().Where(x => x.CategoryName.Contains(txtSearch)).Topagelist((int)page, (int)pageSize);
                var jsonSearchName = JsonConvert.SerializeObject(dataSearch, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jsonSearchName, JsonRequestBehavior.AllowGet);
            }
            
            

            var data = _category.Getall().Topagelist((int)page, (int)pageSize);
            // chuyển sang kiểu dữ liệu json
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(json, JsonRequestBehavior.AllowGet);


        }
        public string Create(Category category) {
            category.CategoryId = "c" + Guid.NewGuid() + DateTime.Now.ToString("ddMMyyyy");
            category.CreateDate = DateTime.Now;
            try
            {
                _category.Add(category);
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }
        }
        public ActionResult Get_By_Id(string id) {
            if (id ==null)
            {
                return HttpNotFound();
            }
            var data = _category.Find(id);
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = _category.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return HttpNotFound();
        }




        public string  Edit( Category category)
        {
            category.CreateDate = DateTime.Now;
            try
            {
                _category.Edit(category);
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }

        }             
       public string Delete(string id)
        {
            if (id== null)
            {
                return "nullId";
            }
            try
            {
                _category.Delete(id);
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }
        }

      
       
    
    }
}
