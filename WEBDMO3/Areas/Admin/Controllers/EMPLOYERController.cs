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
    public class EMPLOYERController : BaseController
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/EMPLOYER
        public ActionResult Index()
        {
            return View(db.EMPLOYERs.ToList());
        }

        // GET: Admin/EMPLOYER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYER eMPLOYER = db.EMPLOYERs.Find(id);
            if (eMPLOYER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYER);
        }

        // GET: Admin/EMPLOYER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/EMPLOYER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fullname,address,phoneNumber")] EMPLOYER eMPLOYER)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYERs.Add(eMPLOYER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPLOYER);
        }

        // GET: Admin/EMPLOYER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYER eMPLOYER = db.EMPLOYERs.Find(id);
            if (eMPLOYER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYER);
        }

        // POST: Admin/EMPLOYER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fullname,address,phoneNumber")] EMPLOYER eMPLOYER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPLOYER);
        }

        // GET: Admin/EMPLOYER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYER eMPLOYER = db.EMPLOYERs.Find(id);
            if (eMPLOYER == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYER);
        }

        // POST: Admin/EMPLOYER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLOYER eMPLOYER = db.EMPLOYERs.Find(id);
            db.EMPLOYERs.Remove(eMPLOYER);
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
