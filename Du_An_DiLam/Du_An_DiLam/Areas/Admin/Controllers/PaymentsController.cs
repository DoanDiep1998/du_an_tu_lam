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
    public class PaymentsController : Controller
    {
        private Repository<Payment> _payment = new Repository<Payment>();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll(string txtSearch, string txtSelect, int? page, int? pageSize) {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 2;
            }
           // tìm kiếm theo tên
            if (txtSearch != null && txtSelect == "Name")
            {
                var dataSearch = _payment.Getall().Where(x => x.PaymentName.Contains(txtSearch)).Topagelist((int)page, (int)pageSize);
                var jsonSearchName = JsonConvert.SerializeObject(dataSearch, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(jsonSearchName, JsonRequestBehavior.AllowGet);
            }
            var data =   _payment.Getall().Topagelist((int)page, (int)pageSize);
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(json,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get_By_Id(string id) {
            var data = _payment.Find(id);
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

           Payment payment= _payment.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);

        }
          
        [HttpPost]
        public string Create(Payment payment)
        {
            payment.CreateDate = DateTime.Now;
            payment.PaymentId = "p" + Guid.NewGuid() + DateTime.Now.ToString("ddMMyyyy"); 
            try
            {
                _payment.Add(payment);
                return "success";

            }
            catch (Exception)
            {
                return "error";
                throw;
            }
          
        }

        public string Edit(Payment payment)
        {
            payment.CreateDate = DateTime.Now;
            if (payment.PaymentId == null)
            {
                return "error";
            }
          
           
            else {
                try
                {
                    _payment.Edit(payment);
                    return "success";
                }
                catch (Exception)
                {

                    return "error";
                }
               
            }

            
        }      
        public string Delete(string id)
        {
            if (id == null)
            {
                return "error";
            }
            Payment payment = _payment.Find(id);
            if (payment == null)
            {
                return "error";
            }
            _payment.Delete(id);
            return "success";
        }
        
    }
}
