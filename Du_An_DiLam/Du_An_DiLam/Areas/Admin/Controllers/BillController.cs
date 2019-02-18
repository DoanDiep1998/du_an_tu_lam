using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.DataModel;
using DataBase.Repository;
using Du_An_DiLam.Models;
using Newtonsoft.Json;

namespace Du_An_DiLam.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        private Repository<Bill>_bill = new Repository<Bill>();
        private Repository<BillDetail> _billdetail = new Repository<BillDetail>();
        // GET: Admin/Bill
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult getAll( int? page, int? pageSize) {
            if (page==null)
            {
                page = 1;
            }
            if (pageSize==null)
            {
                pageSize = 8;
            }
          var data  = _bill.Getall().OrderByDescending(x => x.CreateDate).Topagelist((int)page,(int)pageSize);
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult HistoryBillDetail(string id)
        {
            var data = _billdetail.Getall().Select(x => new BillDetail
            {
                BillId = x.BillId,
                Price = x.Price,
                Total = x.Total,
                Product = new Product
                {
                    ProductName = x.Product.ProductName,
                    PictureShow = x.Product.PictureShow
                }

            }).Where(x => x.BillId == id);
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public string UpdateBill(string id) {
            var data = _bill.Find(id);
            try
            {
                if (data != null)
                {
                    data.Status =true;
                    _bill.Edit(data);
                    return "success";
            }
                else
                {
                    return "error";
                }
            }
            catch (Exception)
            {

                return "error";
            }
           
        }
    }
}