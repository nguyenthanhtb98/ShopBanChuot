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
    [Authorize(Roles ="Admin")]
    public class QLTKController : Controller
    {
        private ShopBanChuotEntities db = new ShopBanChuotEntities();

        // GET: Admin/QLTK
        public ActionResult Index()
        {
            var tAIKHOANs = db.TAIKHOANs.Include(t => t.NHOMTAIKHOAN);
            return View(tAIKHOANs.ToList());
        }

        // GET: Admin/QLTK/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // GET: Admin/QLTK/Create
        public ActionResult Create()
        {
            ViewBag.MaNhomTK = new SelectList(db.NHOMTAIKHOANs, "MaNhomTK", "TenNhomTK");
            return View();
        }

        // POST: Admin/QLTK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenTaiKhoan,MatKhau,TenKhachHang,GioiTinh,SDT,Email,DiaChi,MaNhomTK")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.TAIKHOANs.Add(tAIKHOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhomTK = new SelectList(db.NHOMTAIKHOANs, "MaNhomTK", "TenNhomTK", tAIKHOAN.MaNhomTK);
            return View(tAIKHOAN);
        }

        // GET: Admin/QLTK/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhomTK = new SelectList(db.NHOMTAIKHOANs, "MaNhomTK", "TenNhomTK", tAIKHOAN.MaNhomTK);
            return View(tAIKHOAN);
        }

        // POST: Admin/QLTK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenTaiKhoan,MatKhau,TenKhachHang,GioiTinh,SDT,Email,DiaChi,MaNhomTK")] TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAIKHOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhomTK = new SelectList(db.NHOMTAIKHOANs, "MaNhomTK", "TenNhomTK", tAIKHOAN.MaNhomTK);
            return View(tAIKHOAN);
        }

        // GET: Admin/QLTK/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN tAIKHOAN = db.TAIKHOANs.Find(id);
            if (tAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(tAIKHOAN);
        }

        // POST: Admin/QLTK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string ten)
        {
            db.XoaTK(ten);
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
