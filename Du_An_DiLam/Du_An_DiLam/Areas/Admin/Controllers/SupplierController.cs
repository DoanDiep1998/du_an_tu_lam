using Data.DataModel;
using DataBase.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Du_An_DiLam.Models;
namespace Du_An_DiLam.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        private Repository<Supplier> _supplier = new Repository<Supplier>();
        private Repository<Category> _category = new Repository<Category>();
        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View();

        }
        [HttpGet]
        public ActionResult GetCategory()
        {

            var data = _category.Getall();
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAll(int? page, int? pageSize)
        {
            
            if (page==null)
                //trang mặc định là 1
                page = 1;
            

            if (pageSize ==null)
            {
                //số bản ghi trên một trang 
                pageSize = 5;
            }
             
            var data = _supplier.Getall().OrderByDescending(x=>x.SupplierId).Topagelist((int)page,(int)pageSize);
            // chuyển sang kiểu dữ liệu json
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(json, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public string Create(Supplier supplier)
        {

             var date = DateTime.Now.ToString("ddMMyyyy-hhmmss");
            var id = Guid.NewGuid();

            supplier.SupplierId = "sl"+ Guid.NewGuid() +date;
            supplier.CreateDate = DateTime.Now ;
           
                    _supplier.Add(supplier);
                  
            return "success";
        }
        public string Delete(string id)
        {
            _supplier.Delete(id);
            return "success";
        }
        [HttpPost]
        public string Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var date = DateTime.Now;
                    supplier.CreateDate = date;
                    _supplier.Edit(supplier);
                    return "success";
                }
                catch (Exception)
                {

                    return "error";
                }
               
            }
            else
            {
                return "error";
            }
            
        }
        public ActionResult Detail(string id) {
            var data = _supplier.Find(id);
            //ViewBag.PubName =  ;
            return View(data);
        }

    }
}