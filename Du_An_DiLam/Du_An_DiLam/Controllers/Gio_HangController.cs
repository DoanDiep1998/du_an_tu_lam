using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase.Repository;
using Data.DataModel;
using Du_An_DiLam.Models;

namespace Du_An_DiLam.Controllers
{
    public class Gio_HangController : Controller
    {
        Repository<Product> _product = new Repository<Product>();
        Repository<Payment> _paymet = new Repository<Payment>();
        Repository<Customer> _customer = new Repository<Customer>();
        Repository<Transportation> _Tsti = new Repository<Transportation>();
        Repository<Bill> _bill = new Repository<Bill>();
        Repository<BillDetail> _billDetail = new Repository<BillDetail>();
        public ActionResult Index()
        {
            ViewBag.PaymentId = new SelectList(_paymet.Getall().Where(x => x.Show == true), "PaymentId", "PaymentName");
            ViewBag.TransportationId = new SelectList(_Tsti.Getall().Where(x => x.Show == true), "TransportationId", "TransportationName");
            return View();
        }
        public string Dat_hang( Dat_Hang dh) {
            if (Session["CustomerId"] != null)
            {
                try
                {
                    Bill bill = new Bill();
                    Customer cus = (Customer)Session["customer"];
                    bill.CustomerId = cus.CustomerId;
                    bill.BillId = "B" + Guid.NewGuid() + DateTime.Now.ToString("ddMMyy");
                    bill.CreateDate = DateTime.Now;
                    bill.CustomerName = dh.CustomerName;
                    bill.TotalMoney = dh.TotalMoney;
                    bill.Email = dh.Email;
                    bill.Phone = dh.Phone;
                    bill.Address = dh.Address;
                    bill.Status = false;
                    bill.PaymentId = dh.Payment;
                    bill.TransportationId = dh.Transport;
                    if (dh.Comment == null)
                    {
                        bill.Comment = "trống!";
                    }
                    else {
                        bill.Comment = dh.Comment;
                    }
                    _bill.Add(bill);
                    foreach (var item in dh.products)
                    {
                        BillDetail billDetail = new BillDetail();
                        billDetail.BillId = bill.BillId;
                        billDetail.BillDetailId =Guid.NewGuid().ToString();
                        billDetail.ProductId = item.id;
                        billDetail.Price = item.Price;
                        billDetail.Total = item.quantitysp;
                        _billDetail.Add(billDetail);
                    }
                    
                    return "success";
                }
                catch (Exception)
                {

                    return"error";
                }
            }
            return "err";
        }

       

      
        //[HttpPost]
        //public ActionResult Dat_hang(Bill Hoa_don)
        //{
        //    var row = "";
           

        //    List<Gio_hang> gh = Lay_gio_hang();
        //    Customer kh = (Customer)Session["id"]; 
        //    Hoa_don.CustomerId = kh.CustomerId;
        //    Hoa_don.CreateDate = DateTime.Now;
        //    Hoa_don.Status = false;
        //    Hoa_don.TotalMoney = Tongtien();
        //    _bill.Add(Hoa_don);
        //    foreach (var item in gh)
        //    {
        //        BillDetail ct = new BillDetail();
        //        ct.BillId = Hoa_don.BillId;
        //        ct.ProductId = item.iMa_sp;
        //        ct.Total = item.iSoluong;
        //        ct.Price = item.fDongia;
        //        _billDetail.Add(ct);
        //    }
            

        //    row += "Cảm ơn bạn đã mua hàng tại shop chúng tôi! <br />";
        //    row += "Tên người nhận:" + Hoa_don.CustomerName + "<br />";
        //    row += "Ngày mua:" + Hoa_don.CreateDate + "<br />";
        //    row += "Tổng tiền:" + Hoa_don.TotalMoney + "<sup>đ</sup><br />";

        //    Common.Sendmail("" + Session["email"] + "", "haphong247@gmail.com", "doanngocdiep1998", "Xác nhận đơn hàng từ Men Shop ", "" + row + "");
           
        //    Session["gio_hang"] = null;
        //    return RedirectToAction("Index", "Home");

        //}

    }
}