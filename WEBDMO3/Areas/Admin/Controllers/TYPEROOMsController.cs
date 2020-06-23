using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace WEBDMO3.Areas.Admin.Controllers
{
    public class TYPEROOMsController : BaseController
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/TYPEROOMs
        public ActionResult Index()
        {
            return View(db.TYPEROOMs.ToList());
        }

        // GET: Admin/TYPEROOMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPEROOM tYPEROOM = db.TYPEROOMs.Find(id);
            if (tYPEROOM == null)
            {
                return HttpNotFound();
            }
            return View(tYPEROOM);
        }

        // GET: Admin/TYPEROOMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TYPEROOMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] TYPEROOM tYPEROOM)
        {
            if (ModelState.IsValid)
            {
                db.TYPEROOMs.Add(tYPEROOM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tYPEROOM);
        }

        // GET: Admin/TYPEROOMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPEROOM tYPEROOM = db.TYPEROOMs.Find(id);
            if (tYPEROOM == null)
            {
                return HttpNotFound();
            }
            return View(tYPEROOM);
        }

        // POST: Admin/TYPEROOMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] TYPEROOM tYPEROOM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tYPEROOM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tYPEROOM);
        }

        // GET: Admin/TYPEROOMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPEROOM tYPEROOM = db.TYPEROOMs.Find(id);
            if (tYPEROOM == null)
            {
                return HttpNotFound();
            }
            return View(tYPEROOM);
        }

        // POST: Admin/TYPEROOMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TYPEROOM tYPEROOM = db.TYPEROOMs.Find(id);
            db.TYPEROOMs.Remove(tYPEROOM);
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
