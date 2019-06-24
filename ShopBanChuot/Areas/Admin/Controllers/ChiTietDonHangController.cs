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
    public class ChiTietDonHangController : Controller
    {
        private ShopBanChuotEntities db = new ShopBanChuotEntities();

        // GET: /Admin/ChiTietDonHang/
        public ActionResult Index()
        {
            var chitietdonhangs = db.CHITIETDONHANGs.Include(c => c.DONHANG).Include(c => c.SANPHAM);
            return View(chitietdonhangs.ToList());
        }

        // GET: /Admin/ChiTietDonHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONHANG chitietdonhang = db.CHITIETDONHANGs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // GET: /Admin/ChiTietDonHang/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DONHANGs, "MaDH", "TenTaiKhoan");
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP");
            return View();
        }

        // POST: /Admin/ChiTietDonHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaCTDH,MaSP,SoLuong,DonGia,MaDH")] CHITIETDONHANG chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETDONHANGs.Add(chitietdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DONHANGs, "MaDH", "TenTaiKhoan", chitietdonhang.MaDH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", chitietdonhang.MaSP);
            return View(chitietdonhang);
        }

        // GET: /Admin/ChiTietDonHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONHANG chitietdonhang = db.CHITIETDONHANGs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DONHANGs, "MaDH", "TenTaiKhoan", chitietdonhang.MaDH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", chitietdonhang.MaSP);
            return View(chitietdonhang);
        }

        // POST: /Admin/ChiTietDonHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaCTDH,MaSP,SoLuong,DonGia,MaDH")] CHITIETDONHANG chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietdonhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DONHANGs, "MaDH", "TenTaiKhoan", chitietdonhang.MaDH);
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", chitietdonhang.MaSP);
            return View(chitietdonhang);
        }

        // GET: /Admin/ChiTietDonHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONHANG chitietdonhang = db.CHITIETDONHANGs.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // POST: /Admin/ChiTietDonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETDONHANG chitietdonhang = db.CHITIETDONHANGs.Find(id);
            db.CHITIETDONHANGs.Remove(chitietdonhang);
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
