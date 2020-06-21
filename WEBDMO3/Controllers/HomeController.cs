using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace WEBDMO3.Controllers
{
    public class HomeController : Controller
    {
        private WebDbContext db = new WebDbContext();

        // GET: Home
        public ActionResult Index()
        {
            var rOOMs = db.ROOMs.Include(r => r.EMPLOYER).Include(r => r.TYPEROOM);
            return View(rOOMs.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM rOOM = db.ROOMs.Find(id);
            if (rOOM == null)
            {
                return HttpNotFound();
            }
            return View(rOOM);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.idEmployer = new SelectList(db.EMPLOYERs, "id", "fullname");
            ViewBag.idRoom = new SelectList(db.TYPEROOMs, "id", "name");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,address,image_link,idRoom,price,funcion_1,funcion_2,content,personMax,acreage,allowPet,idEmployer,status,createdate,cratedBy")] ROOM rOOM)
        {
            if (ModelState.IsValid)
            {
                db.ROOMs.Add(rOOM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmployer = new SelectList(db.EMPLOYERs, "id", "fullname", rOOM.idEmployer);
            ViewBag.idRoom = new SelectList(db.TYPEROOMs, "id", "name", rOOM.idRoom);
            return View(rOOM);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM rOOM = db.ROOMs.Find(id);
            if (rOOM == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmployer = new SelectList(db.EMPLOYERs, "id", "fullname", rOOM.idEmployer);
            ViewBag.idRoom = new SelectList(db.TYPEROOMs, "id", "name", rOOM.idRoom);
            return View(rOOM);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,address,image_link,idRoom,price,funcion_1,funcion_2,content,personMax,acreage,allowPet,idEmployer,status,createdate,cratedBy")] ROOM rOOM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOOM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmployer = new SelectList(db.EMPLOYERs, "id", "fullname", rOOM.idEmployer);
            ViewBag.idRoom = new SelectList(db.TYPEROOMs, "id", "name", rOOM.idRoom);
            return View(rOOM);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM rOOM = db.ROOMs.Find(id);
            if (rOOM == null)
            {
                return HttpNotFound();
            }
            return View(rOOM);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ROOM rOOM = db.ROOMs.Find(id);
            db.ROOMs.Remove(rOOM);
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
