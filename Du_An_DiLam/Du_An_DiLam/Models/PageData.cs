using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Du_An_DiLam.Models
{
    public class PageData <Tentity> where Tentity:class 
    {
        /// <summary>
        /// trang hiện tại
        /// </summary>
      
        public int CurrentPage{ get; set; }
       /// <summary>
       /// Tổng số trang
       /// </summary>
        public int PageOfNumber { get; set; }
        /// <summary>
        /// dữ liệu một trang
        /// </summary>
        public IEnumerable<Tentity> Data { get; set; }
    }
}