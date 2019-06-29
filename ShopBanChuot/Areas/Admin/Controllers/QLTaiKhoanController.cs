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
    public class QLTaiKhoanController : Controller
    {
        private ShopBanChuotEntities db = new ShopBanChuotEntities();

        // GET: /Admin/QLTaiKhoan/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.TAIKHOANs.ToList());
        }

        // GET: /Admin/QLTaiKhoan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN taikhoan = db.TAIKHOANs.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // GET: /Admin/QLTaiKhoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/QLTaiKhoan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TenTaiKhoan,MatKhau,TenKhachHang,GioiTinh,SDT,Email,DiaChi")] TAIKHOAN taikhoan)
        {
            TAIKHOAN TK = db.TAIKHOANs.Find(taikhoan.TenTaiKhoan);
            if(TK!= null)
            {
                ViewBag.ThongBaoTenTK = "Tên tài khoản đã tồn tại";
                return View();
            }
            if (ModelState.IsValid)
            {
                db.TAIKHOANs.Add(taikhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taikhoan);
        }

        // GET: /Admin/QLTaiKhoan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN taikhoan = db.TAIKHOANs.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // POST: /Admin/QLTaiKhoan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TenTaiKhoan,MatKhau,TenKhachHang,GioiTinh,SDT,Email,DiaChi")] TAIKHOAN taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taikhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taikhoan);
        }

        // GET: /Admin/QLTaiKhoan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIKHOAN taikhoan = db.TAIKHOANs.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // POST: /Admin/QLTaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAIKHOAN taikhoan = db.TAIKHOANs.Find(id);
            db.TAIKHOANs.Remove(taikhoan);
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
