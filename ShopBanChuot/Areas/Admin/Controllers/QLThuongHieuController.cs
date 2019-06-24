using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopBanChuot.Models;

namespace ShopBanChuot.Areas.Admin.Controllers
{
    public class QLThuongHieuController : Controller
    {
        private ShopBanChuotEntities db = new ShopBanChuotEntities();

        // GET: /Admin/QLThuongHieu/
        public ActionResult Index()
        {
            return View(db.THUONGHIEUx.ToList());
        }

        // GET: /Admin/QLThuongHieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU thuonghieu = db.THUONGHIEUx.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        // GET: /Admin/QLThuongHieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/QLThuongHieu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaTH,TenTH")] THUONGHIEU thuonghieu)
        {
            if (ModelState.IsValid)
            {
                db.THUONGHIEUx.Add(thuonghieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thuonghieu);
        }

        // GET: /Admin/QLThuongHieu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU thuonghieu = db.THUONGHIEUx.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        // POST: /Admin/QLThuongHieu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaTH,TenTH")] THUONGHIEU thuonghieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuonghieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thuonghieu);
        }

        // GET: /Admin/QLThuongHieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THUONGHIEU thuonghieu = db.THUONGHIEUx.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        // POST: /Admin/QLThuongHieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            THUONGHIEU thuonghieu = db.THUONGHIEUx.Find(id);
            db.THUONGHIEUx.Remove(thuonghieu);
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
