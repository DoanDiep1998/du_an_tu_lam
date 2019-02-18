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
    public class ProductsController : Controller
    {

        private Repository<Product> _product = new Repository<Product>();
        private Repository<CategoryDetail> _categoryD = new Repository<CategoryDetail>();
        private Repository<Supplier> _supplier = new Repository<Supplier>();
        private Repository<BillDetail> _billdetail = new Repository<BillDetail>();


        public ActionResult Index()
        {
            ViewBag.CategoryDetailId = new SelectList(_categoryD.Getall().Where(x=>x.Show==true), "CategoryDetailId", "CategoryDetailName");
            ViewBag.SupplierId = new SelectList(_supplier.Getall().Where(x=>x.Show==true), "SupplierId", "SupplierName");

            return View();
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult GetAll(string txtSearch, string txtSelect, int? page, int? pageSize, string txtStatus)
       {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 3;
            }
            var data = _product.Getall().OrderByDescending(x => x.CreateDate).Topagelist((int)page, (int)pageSize);
            if (txtStatus!="")
            {
                switch (txtSelect)
                {
                    case "Name":

                        data = _product.Getall().Where(x => x.ProductName.Contains(txtSearch) && x.Show.Equals(bool.Parse(txtStatus))).Topagelist((int)page, (int)pageSize); ;
                        break;
                    case "Price":
                        if (txtSearch == "")// nếu không nhập thì trả ra thường
                        {
                            data = _product.Getall().Topagelist((int)page, (int)pageSize);
                        }
                        data = _product.Getall().Where(x => x.Price.Equals(int.Parse(txtSearch)) && x.Show.Equals(bool.Parse(txtStatus))).Topagelist((int)page, (int)pageSize);
                        break;

                }
            }
            else
            {
                switch (txtSelect)
                {
                    case "Name":

                        data = _product.Getall().Where(x => x.ProductName.Contains(txtSearch)).Topagelist((int)page, (int)pageSize); ;
                        break;
                    case "Price":
                        if (txtSearch=="")// nếu không nhập thì trả ra thường
                        {
                            data = _product.Getall().Topagelist((int)page, (int)pageSize);
                        }
                        data = _product.Getall().Where(x => x.Price.Equals(int.Parse(txtSearch))).Topagelist((int)page, (int)pageSize);
                        break;

                }
            }
            // chuyển sang kiểu dữ liệu json
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(json, JsonRequestBehavior.AllowGet);


        }

        public string Create(Product product, HttpPostedFileBase picture)
        {
            product.ProductId = "P" + Guid.NewGuid() + DateTime.Now.ToString("ddMMyyyy");
            product.CreateDate = DateTime.Now;
            string pictures = "";
            string pictureShow = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                // lấy ra từng file
                picture = Request.Files[i];
                // lấy tên file
                string fileName = picture.FileName;
                // lưu file
                picture.SaveAs(Server.MapPath(@"~/Content/FileUpload/") + fileName);
                pictures += "/Content/FileUpload/" + fileName + ";";
                pictureShow = "/Content/FileUpload/" + fileName;

            }
            //add nội dung
            product.PictureShow = pictureShow;
            product.Picture = pictures;
            try
            {
                _product.Add(product);
                return "success";
            }
            catch (Exception)
            {
                return "error";
            }           
        }
        public ActionResult Get_By_Id(string id)
        {
            var data = _product.Find(id);
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public string Edit(Product product, HttpPostedFileBase picture)
        {


            product.CreateDate = DateTime.Now;
            string pictures = "";
            for (int i = 0; i < Request.Files.Count; i++)
            {
                // lấy ra từng file
                picture = Request.Files[i];
                // lấy tên file
                string fileName = picture.FileName;
                // lưu file
                picture.SaveAs(Server.MapPath(@"~/Content/FileUpload/") + fileName);
                pictures += "/Content/FileUpload/" + fileName + ";";

            }

            product.Picture = pictures;
            if (ModelState.IsValid)
            {
                _product.Edit(product);

                return "success";
            }


            return "error";
        }
      public string Delete(string id)
    {
        try
        {
                var databill = _billdetail.Getall().Where(x => x.ProductId == id);
                if (databill !=null)
                {
                    return "bill";
                }
                else
                {
                    _product.Delete(id);
                    return "success";
                }
           
        }
        catch (Exception)
        {

            return "error";
        }

    }

    }
}

       
        

       
    

