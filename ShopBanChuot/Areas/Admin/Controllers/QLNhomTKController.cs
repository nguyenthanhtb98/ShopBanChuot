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
    public class QLNhomTKController : Controller
    {
        private ShopBanChuotEntities db = new ShopBanChuotEntities();

        // GET: Admin/QLNhomTK
        public ActionResult Index()
        {
            return View(db.NHOMTAIKHOANs.ToList());
        }

        // GET: Admin/QLNhomTK/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHOMTAIKHOAN nHOMTAIKHOAN = db.NHOMTAIKHOANs.Find(id);
            if (nHOMTAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(nHOMTAIKHOAN);
        }

        // GET: Admin/QLNhomTK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QLNhomTK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhomTK,TenNhomTK")] NHOMTAIKHOAN nHOMTAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.NHOMTAIKHOANs.Add(nHOMTAIKHOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHOMTAIKHOAN);
        }

        // GET: Admin/QLNhomTK/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHOMTAIKHOAN nHOMTAIKHOAN = db.NHOMTAIKHOANs.Find(id);
            if (nHOMTAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(nHOMTAIKHOAN);
        }

        // POST: Admin/QLNhomTK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhomTK,TenNhomTK")] NHOMTAIKHOAN nHOMTAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHOMTAIKHOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHOMTAIKHOAN);
        }

        // GET: Admin/QLNhomTK/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHOMTAIKHOAN nHOMTAIKHOAN = db.NHOMTAIKHOANs.Find(id);
            if (nHOMTAIKHOAN == null)
            {
                return HttpNotFound();
            }
            return View(nHOMTAIKHOAN);
        }

        // POST: Admin/QLNhomTK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //NHOMTAIKHOAN nHOMTAIKHOAN = db.NHOMTAIKHOANs.Find(id);
            
            //db.NHOMTAIKHOANs.Remove(nHOMTAIKHOAN);
            db.XoaNhomTK(id);
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
