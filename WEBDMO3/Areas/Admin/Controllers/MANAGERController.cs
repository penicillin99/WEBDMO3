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
    public class MANAGERController : BaseController
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/MANAGER
        public ActionResult Index()
        {
            return View(db.MANAGERs.ToList());
        }

        // GET: Admin/MANAGER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MANAGER mANAGER = db.MANAGERs.Find(id);
            if (mANAGER == null)
            {
                return HttpNotFound();
            }
            return View(mANAGER);
        }

        // GET: Admin/MANAGER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MANAGER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,role")] MANAGER mANAGER)
        {
            if (ModelState.IsValid)
            {
                db.MANAGERs.Add(mANAGER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mANAGER);
        }

        // GET: Admin/MANAGER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MANAGER mANAGER = db.MANAGERs.Find(id);
            if (mANAGER == null)
            {
                return HttpNotFound();
            }
            return View(mANAGER);
        }

        // POST: Admin/MANAGER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,role")] MANAGER mANAGER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mANAGER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mANAGER);
        }

        // GET: Admin/MANAGER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MANAGER mANAGER = db.MANAGERs.Find(id);
            if (mANAGER == null)
            {
                return HttpNotFound();
            }
            return View(mANAGER);
        }

        // POST: Admin/MANAGER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MANAGER mANAGER = db.MANAGERs.Find(id);
            db.MANAGERs.Remove(mANAGER);
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
