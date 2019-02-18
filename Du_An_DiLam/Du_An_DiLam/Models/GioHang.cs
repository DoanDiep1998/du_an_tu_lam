using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataBase;
using DataBase.Repository;
using Data.DataModel;

namespace Du_An_DiLam.Models
{
    public class Gio_hang
    {
        Repository<Product> _product = new Repository<Product>();
        public string iMa_sp { get; set; }
        public string sTenSp { get; set; }
        public string sHinhanh { get; set; }
        public float fDongia { get; set; }
        public int iSoluong { get; set; }
        public float iThanhtien
        {
            get { return iSoluong * fDongia; }
            set { iThanhtien = value; }
        }

        public Gio_hang(string Ma_sp)
        {
            iMa_sp = Ma_sp;
            Product sp = _product.SingleOf(x => x.ProductId == iMa_sp);
            sTenSp = sp.ProductName;
            sHinhanh = sp.PictureShow;
            if (sp.Price > sp.PriceSale ||sp.PriceSale ==0)
            {
                fDongia = sp.Price;
            }
            else
            {
                fDongia = sp.PriceSale;
            }
            iSoluong = 1;
        }
    }
}