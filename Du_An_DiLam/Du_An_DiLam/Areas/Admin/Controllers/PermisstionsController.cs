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
    public class PermisstionsController : Controller
    {
        private MenShopDbContext db = new MenShopDbContext();

        // GET: Admin/Permisstions
        public ActionResult Index()
        {
            var permisstions = db.permisstions.Include(p => p.Permisstion_Group).Include(p => p.User);
            return View(permisstions.ToList());
        }

        // GET: Admin/Permisstions/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisstion permisstion = db.permisstions.Find(id);
            if (permisstion == null)
            {
                return HttpNotFound();
            }
            return View(permisstion);
        }

        // GET: Admin/Permisstions/Create
        public ActionResult Create()
        {
            ViewBag.Permisstion_GroupId = new SelectList(db.Permisstion_Groups, "Permisstion_GroupId", "PermistionName");
            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName");
            return View();
        }

        // POST: Admin/Permisstions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermisstionId,Permisstion_GroupId,UserId")] Permisstion permisstion)
        {
            if (ModelState.IsValid)
            {
                db.permisstions.Add(permisstion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Permisstion_GroupId = new SelectList(db.Permisstion_Groups, "Permisstion_GroupId", "PermistionName", permisstion.Permisstion_GroupId);
            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName", permisstion.UserId);
            return View(permisstion);
        }

        // GET: Admin/Permisstions/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisstion permisstion = db.permisstions.Find(id);
            if (permisstion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Permisstion_GroupId = new SelectList(db.Permisstion_Groups, "Permisstion_GroupId", "PermistionName", permisstion.Permisstion_GroupId);
            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName", permisstion.UserId);
            return View(permisstion);
        }

        // POST: Admin/Permisstions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermisstionId,Permisstion_GroupId,UserId")] Permisstion permisstion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permisstion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Permisstion_GroupId = new SelectList(db.Permisstion_Groups, "Permisstion_GroupId", "PermistionName", permisstion.Permisstion_GroupId);
            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName", permisstion.UserId);
            return View(permisstion);
        }

        // GET: Admin/Permisstions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisstion permisstion = db.permisstions.Find(id);
            if (permisstion == null)
            {
                return HttpNotFound();
            }
            return View(permisstion);
        }

        // POST: Admin/Permisstions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Permisstion permisstion = db.permisstions.Find(id);
            db.permisstions.Remove(permisstion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
