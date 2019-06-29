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
    public class QLXuatXuController : Controller
    {
        ShopBanChuotEntities db = new ShopBanChuotEntities();

        // GET: /Admin/QLXuatXu/
        public ActionResult Index()
        {
            return View(db.XUATXUs.ToList());
        }

        // GET: /Admin/QLXuatXu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XUATXU xuatxu = db.XUATXUs.Find(id);
            if (xuatxu == null)
            {
                return HttpNotFound();
            }
            return View(xuatxu);
        }

        // GET: /Admin/QLXuatXu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/QLXuatXu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaXX,TenXX")] XUATXU xuatxu)
        {
            if (ModelState.IsValid)
            {
                db.XUATXUs.Add(xuatxu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(xuatxu);
        }

        // GET: /Admin/QLXuatXu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XUATXU xuatxu = db.XUATXUs.Find(id);
            if (xuatxu == null)
            {
                return HttpNotFound();
            }
            return View(xuatxu);
        }

        // POST: /Admin/QLXuatXu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaXX,TenXX")] XUATXU xuatxu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xuatxu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(xuatxu);
        }

        // GET: /Admin/QLXuatXu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XUATXU xuatxu = db.XUATXUs.Find(id);
            if (xuatxu == null)
            {
                return HttpNotFound();
            }
            return View(xuatxu);
        }

        // POST: /Admin/QLXuatXu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            XUATXU xuatxu = db.XUATXUs.Find(id);
            db.XUATXUs.Remove(xuatxu);
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
