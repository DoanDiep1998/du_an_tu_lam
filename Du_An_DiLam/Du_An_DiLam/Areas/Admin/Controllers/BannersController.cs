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
    public class BannersController : Controller
    {
        private Repository<Banner> _banner = new Repository<Banner>();
        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll(string txtSearch, string txtSelect,int? page,int? pageSize) {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize== null)
            {
                pageSize = 2;
            }
                //tìm kiếm theo tên
                if (txtSearch != null && txtSelect == "Name")
                {
                    var dataSearch = _banner.Getall().Where(x => x.BannerName.Contains(txtSearch)).Topagelist((int)page,(int)pageSize);
                    var jsonSearchName = JsonConvert.SerializeObject(dataSearch, Formatting.None, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return Json(jsonSearchName, JsonRequestBehavior.AllowGet);
                }
                //tìm kiếm nội dung
                if (txtSearch != null && txtSelect == "Content")
                {
                    var dataSearch = _banner.Getall().Where(x => x.Content.Contains(txtSearch)).Topagelist((int)page, (int)pageSize);
                    var jsonSearchName = JsonConvert.SerializeObject(dataSearch, Formatting.None, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    return Json(jsonSearchName, JsonRequestBehavior.AllowGet);
                }

                var data = _banner.Getall().OrderByDescending(x=>x.CreateDate).Topagelist((int)page, (int)pageSize);
                // chuyển sang kiểu dữ liệu json
                var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                return Json(json, JsonRequestBehavior.AllowGet);

            
        }
        public string Create(Banner banner ,HttpPostedFileBase fileUpload) {
            banner.CreateDate = DateTime.Now;
            banner.BannerId = "b"+ Guid.NewGuid() + DateTime.Now.ToString("ddMMyyyy-hhmmss");
            if (fileUpload !=null && fileUpload.ContentLength>0)
            {
                // LẤY TÊN FILE
                var file = fileUpload.FileName;
                // lưu vào tệp 
                fileUpload.SaveAs(Server.MapPath(@"~/Content/FileUpload/") + file);
                // lưu vào cơ sở dữ liệu
                banner.Picture = "/Content/FileUpload/" + file;
                _banner.Add(banner);
                return "success";
            }                                   
            return "error";              
        }
        public string Delete(string id)
        {
         var data = _banner.Find(id);
            if (data!= null)
            {
                _banner.Delete(id);
                return "success";
            }
            else
            {
                return "error";
            }

        }
        public ActionResult Get_By_Id(string id) {                    
                var data = _banner.Find(id);
                var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(json, JsonRequestBehavior.AllowGet);                     
        }
        public ActionResult Details(string id) {
            var data = _banner.Find(id);            

            return View(data);
        }
        public string Edit(Banner banner, HttpPostedFileBase fileUpload) {
            if (fileUpload != null && fileUpload.ContentLength > 0) {
                var file = fileUpload.FileName;
                fileUpload.SaveAs(Server.MapPath(@"~/Content/FileUpload/") + file);
                banner.Picture = "/Content/FileUpload/" + file;
                banner.CreateDate = DateTime.Now;
                if (!ModelState.IsValid)
                {
                    try
                    {
                        _banner.Edit(banner);
                        return "success";
                    }
                    catch (Exception)
                    {

                        return "error";
                    }
                }

                return "error";
            }
            else
            {
                return "error";
            }
            

        }

    }
}