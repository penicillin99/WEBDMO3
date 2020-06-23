﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace WEBDMO3.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/Home
        public ActionResult Index(string price,string location, string typeRoom, int page = 1, int pageSize = 10)
        {
            RoomDAO dao = new RoomDAO();
            int price_int = 0;
            if (!string.IsNullOrEmpty(price))
            {
                price_int = Convert.ToInt32(price);
            }
            
            var model = dao.GetRoomByTitle(price_int, location,typeRoom,page, pageSize);
            ViewBag.Price = price;
            ViewBag.Location = location;
            ViewBag.TypeRoom = typeRoom;
            return View(model);
        }



        // GET: Admin/Home/Details/5
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

        // GET: Admin/Home/Create
        public ActionResult Create()
        {
            ViewBag.idEmployer = new SelectList(db.EMPLOYERs, "id", "fullname");
            ViewBag.idRoom = new SelectList(db.TYPEROOMs, "id", "name");
            return View();
        }

        // POST: Admin/Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
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

        // GET: Admin/Home/Edit/5
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

        // POST: Admin/Home/Edit/5
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

        // GET: Admin/Home/Delete/5
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

        // POST: Admin/Home/Delete/5
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
