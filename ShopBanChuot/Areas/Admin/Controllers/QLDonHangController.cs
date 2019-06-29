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
    public class QLDonHangController : Controller
    {
        private ShopBanChuotEntities db = new ShopBanChuotEntities();

        // GET: /Admin/QLDonHang/
        public ActionResult Index()
        {
            var donhangs = db.DONHANGs.Include(d => d.TAIKHOAN);
            return View(donhangs.ToList());
        }

        // GET: /Admin/QLDonHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG donhang = db.DONHANGs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // GET: /Admin/QLDonHang/Create
        public ActionResult Create()
        {
            ViewBag.TenTaiKhoan = new SelectList(db.TAIKHOANs, "TenTaiKhoan", "MatKhau");
            return View();
        }

        // POST: /Admin/QLDonHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaDH,TenTaiKhoan,NgayDatHang,NgayGiaoHang,TrangThai")] DONHANG donhang)
        {
            if (ModelState.IsValid)
            {
                db.DONHANGs.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TenTaiKhoan = new SelectList(db.TAIKHOANs, "TenTaiKhoan");
            return View(donhang);
        }

        // GET: /Admin/QLDonHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG donhang = db.DONHANGs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenTaiKhoan = new SelectList(db.TAIKHOANs, "TenTaiKhoan", "MatKhau", donhang.TenTaiKhoan);
            return View(donhang);
        }

        // POST: /Admin/QLDonHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaDH,TenTaiKhoan,NgayDatHang,NgayGiaoHang,TrangThai")] DONHANG donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TenTaiKhoan = new SelectList(db.TAIKHOANs, "TenTaiKhoan", "MatKhau", donhang.TenTaiKhoan);
            return View(donhang);
        }

        // GET: /Admin/QLDonHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG donhang = db.DONHANGs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // POST: /Admin/QLDonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONHANG donhang = db.DONHANGs.Find(id);
            db.DONHANGs.Remove(donhang);
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
