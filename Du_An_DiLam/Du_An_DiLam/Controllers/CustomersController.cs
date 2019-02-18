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

namespace Du_An_DiLam.Controllers
{
    public class CustomersController : Controller
    {

        private Repository<Customer> _customer = new Repository<Customer>();
        private Repository<Bill> _bill = new Repository<Bill>();
        private Repository<BillDetail> _billdetail = new Repository<BillDetail>();
        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public string CheckUser(string use)
        {

            var dataUse = _customer.SingleOf(x => x.User == use);
            if (dataUse == null)
            {
                return "success";
            }
            return "errr";
        }
        [HttpPost]
        public string CheckEmail(string email)
        {
            var dataEmail = _customer.SingleOf(x => x.Email == email);
            if (dataEmail == null)
            {
                return "success";

            }
            return "errorEmail";
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public string Creates(Customer customer, HttpPostedFileBase fileUp)
        {

            customer.CustomerId = Guid.NewGuid() + DateTime.Now.ToString("ddMMyyyy");
            customer.CreateDate = DateTime.Now;



            string PassMd5 = Common.EncryptMD5(customer.User + customer.Password);

            customer.Password = PassMd5;// mã hóa mật khẩu kèm tài khoản
            if (fileUp != null && fileUp.ContentLength > 0)
            {
                // LẤY TÊN FILE
                var files = fileUp.FileName;
                // lưu vào tệp 
                fileUp.SaveAs(Server.MapPath(@"~/Content/FileUpload/") + files);
                // lưu vào cơ sở dữ liệu
                customer.Avatar = "/Content/FileUpload/" + files;

            }
            var dataEmail = _customer.SingleOf(x => x.Email == customer.Email);
            if (dataEmail != null)
            {
                return "errorEmail";

            }
            var dataUse = _customer.SingleOf(x => x.User == customer.User);
            if (dataUse != null)
            {
                return "errruse";
            }
            try
            {
                _customer.Add(customer);
                return "success";
            }
            catch (Exception)
            {

                return "error";
            }
        }
        public string Login(string use, string pass) {
            string passMd5 = Common.EncryptMD5(use + pass);
            var data = _customer.FirstOf(x => x.User == use && x.Password == passMd5);
            if (data != null)
            {
                Session["customer"] = data;
                Session["CustomerId"] = data.CustomerId;
                Session["CustomerName"] = data.CustomerName;
                Session["Email"] = data.Email;
                Session["Gender"] = data.Gender;
                Session["Birthday"] = data.Birthday;
                Session["Phone"] = data.Phone;
                Session["User"] = data.User;
                Session["Password"] = data.Password;
                Session["Avatar"] = data.Avatar;
                Session["Address"] = data.Address;
                return "success";
            }
            else
            {
                return "error";
            }

        }
        public ActionResult Logout()
        {
            Session["CustomerId"] = null;
            Session["CustomerName"] = null;
            Session["Email"] = null;
            Session["Gender"] = null;
            Session["Birthday"] = null;
            Session["Phone"] = null;
            Session["User"] = null;
            Session["Password"] = null;
            Session["Avatar"] = null;
            Session["Address"] = null;
            return RedirectToAction("Index", "Home");
        }
        // xem đơn hàng
        public ActionResult HistoryBill(string id) {
            var data = _bill.Getall().Where(x => x.CustomerId == id);
            return View(data);
        }
       
        [HttpGet]
        public ActionResult HistoryBillDetail(string id)
        {
            var data = _billdetail.Getall().Select(x => new BillDetail
            {
               BillId=x.BillId,
                Price = x.Price,
                Total = x.Total,
                Product =new Product {
                   ProductName =x.Product.ProductName,
                   PictureShow=x.Product.PictureShow
                }
               
            }).Where(x=>x.BillId==id);
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
           
            return Json(json, JsonRequestBehavior.AllowGet);
        } 
       
    }
}
