using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Du_An_DiLam.Models
{
    public static class CustomExtension
    {
        /// <summary>
        /// phân trang
        /// </summary>
        /// <typeparam name="Tentity"></typeparam>
        /// <param name="collection"> kiểu dữ liệu</param>
        /// <param name="page">trang</param>
        /// <param name="pagesize">kích thước trang</param>
        /// <returns></returns>
        public static PageData<Tentity> Topagelist<Tentity>(this IEnumerable<Tentity> collection, int page, int pagesize) where Tentity:class {
            //chia dữ liệu từng trang
            var pagecout = collection.Count() / pagesize;
            if (collection.Count()%pagesize !=0)
            {
                pagecout++;
            }
            //Lấy dữ liệu trong collection theo số trang và kích cỡ trang
            var data = collection.Skip(pagesize * (page - 1)).Take(pagesize);
            return new PageData<Tentity> { CurrentPage = page, Data = data, PageOfNumber = pagecout };
        }

    }
}