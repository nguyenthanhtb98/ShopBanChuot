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
    [Authorize(Roles = "Admin")]
    public class QLLoaiSPController : Controller
    {
        private ShopBanChuotEntities db = new ShopBanChuotEntities();

        // GET: /Admin/QLLoaiSP/
        public ActionResult Index()
        {
            return View(db.LOAISANPHAMs.ToList());
        }

        // GET: /Admin/QLLoaiSP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM loaisanpham = db.LOAISANPHAMs.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        // GET: /Admin/QLLoaiSP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/QLLoaiSP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaLoaiSP,TenLoaiSP")] LOAISANPHAM loaisanpham)
        {
            if (ModelState.IsValid)
            {
                db.LOAISANPHAMs.Add(loaisanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaisanpham);
        }

        // GET: /Admin/QLLoaiSP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM loaisanpham = db.LOAISANPHAMs.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        // POST: /Admin/QLLoaiSP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaLoaiSP,TenLoaiSP")] LOAISANPHAM loaisanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaisanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaisanpham);
        }

        // GET: /Admin/QLLoaiSP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM loaisanpham = db.LOAISANPHAMs.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        // POST: /Admin/QLLoaiSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.XoaLoaiSP(id);
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
