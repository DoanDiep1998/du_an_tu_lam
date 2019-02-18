using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.DataModel;
using DataBase.Repository;
using Du_An_DiLam.Models;
using Newtonsoft.Json;
using PagedList;

namespace Du_An_DiLam.Controllers
{
    
    public class HomeController : Controller
    {
        private Repository<Product> _product = new Repository<Product>();
        private Repository<Category> _Category = new Repository<Category>();
        private Repository<CategoryDetail> _CategoryDetail = new Repository<CategoryDetail>();
        private Repository<Supplier> _Suplier = new Repository<Supplier>();
        private Repository<Banner> _Banner = new Repository<Banner>();
        private Repository<FeedBack> _feedBack = new Repository<FeedBack>();

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetSuplier()
        {
            return PartialView(_Suplier.Getall().Where(x => x.Show == true));
        }
        public PartialViewResult GetCategory()
        {
            
            return PartialView(_CategoryDetail.Getall().Where(x=>x.Show==true));
        }
        public PartialViewResult ProductByCategory(string id,int? page) {
            if (page == null)
            {
                page = 1;
            }
            //Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            int pageSize = 1;

            return PartialView(_product.Getall().Where(x=>x.CategoryDetailId ==id && x.Show== true).ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult ProductBySuplier(string id,int? page)
        {
            if (page == null)
            {
                page = 1;
            }          
            int pageNumber = (page ?? 1);

            int pageSize = 1;
            return PartialView(_product.Getall().Where(x => x.SupplierId == id && x.Show == true).ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult GetBaner()
        {
            return PartialView ( _Banner.Getall());
        }
        public PartialViewResult ProductNew()
        {
            return PartialView(_product.Getall().OrderByDescending(x=>x.CreateDate).Take(6));
        }
        public PartialViewResult GetProduct(int? page)
        {
           
                if (page == null)
                {
                    page = 1;
                }
                int pageNumber = (page ?? 1);

                int pageSize = 1;
                return PartialView(_product.Getall().ToPagedList(pageNumber, pageSize));
            
           
        }
        public PartialViewResult Search(int? page, string search)
        {
            if (page == null)
            {
                page = 1;
            }
            int pageNumber = (page ?? 1);

           
            return PartialView(_product.Getall().Where(x => x.ProductName.Contains(search)));
        }
        // ứng dụng chat sử dụng SignalR 2
        //public ActionResult Chat()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult getProductById(string id) {
            Product data = _product.Find(id);
            return View(data);
        }

        public ActionResult loadComment(int? page, int? pageSize, string id) {
            
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 3;
            }
            var data = _feedBack.Getall().Select(x => new FeedBack
            {
               
                FeedBackId = x.FeedBackId,
                Content =x.Content,
                CreateDate = x.CreateDate,
                CustomerId =x.CustomerId,
                ProductId=x.ProductId,
                Star =x.Star,
                Customer = new Customer {
                    CustomerName = x.Customer.CustomerName,
                    Avatar =x.Customer.Avatar

                }
             }).Where(x=>x.ProductId==id).OrderByDescending(x=>x.CreateDate).Topagelist((int)page, (int)pageSize);
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public string postComment(FeedBack comment) {
            if (Session["CustomerId"] == null)
            {
                return "";
            }
            else
            {
                Customer cus = (Customer)Session["customer"];
                comment.FeedBackId = "f" + Guid.NewGuid();
                comment.CustomerId = cus.CustomerId;
                comment.CreateDate = DateTime.Now;
                try
                {
                    _feedBack.Add(comment);
                    return "success";
                }
                catch (Exception)
                {

                    return "err";
                }

            }

        }


    }
}