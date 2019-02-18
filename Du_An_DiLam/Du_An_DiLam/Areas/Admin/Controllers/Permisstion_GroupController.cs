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

namespace Du_An_DiLam.Areas.Admin.Controllers
{
    public class Permisstion_GroupController : Controller
    {
        private MenShopDbContext db = new MenShopDbContext();

        // GET: Admin/Permisstion_Group
        public ActionResult Index()
        {
            var permisstion_Groups = db.Permisstion_Groups.Include(p => p.Business);
            return View(permisstion_Groups.ToList());
        }

        // GET: Admin/Permisstion_Group/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisstion_Group permisstion_Group = db.Permisstion_Groups.Find(id);
            if (permisstion_Group == null)
            {
                return HttpNotFound();
            }
            return View(permisstion_Group);
        }

        // GET: Admin/Permisstion_Group/Create
        public ActionResult Create()
        {
            ViewBag.BusinessId = new SelectList(db.businesses, "BusinessId", "BusinessName");
            return View();
        }

        // POST: Admin/Permisstion_Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      

        
      
    }
}
