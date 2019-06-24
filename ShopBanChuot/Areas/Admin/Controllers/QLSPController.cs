using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopBanChuot.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
namespace ShopBanChuot.Areas.Admin.Controllers
{
    public class QLSPController : Controller
    {

        ShopBanChuotEntities db = new ShopBanChuotEntities();

        // GET: /QLSP/
        public ActionResult Index(int page = 1)
        {
            int pagesize = 9; //1 trang có 9 cuốn
            return View(db.SANPHAMs.OrderBy(n => n.TenSP).ToPagedList(page, pagesize));
        }
        // GET: /QLSP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: /QLSP/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiSP = new SelectList(db.LOAISANPHAMs, "MaLoaiSP", "TenLoaiSP");
            ViewBag.MaTH = new SelectList(db.THUONGHIEUx, "MaTH", "TenTH");
            ViewBag.MaXX = new SelectList(db.XUATXUs, "MaXX", "TenXX");
            return View();
        }

        // POST: /QLSP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(SANPHAM sanpham, HttpPostedFileBase fileUpload1, HttpPostedFileBase fileUpload2, HttpPostedFileBase fileUpload3)
        {
            ViewBag.MaLoaiSP = new SelectList(db.LOAISANPHAMs, "MaLoaiSP", "TenLoaiSP");
            ViewBag.MaTH = new SelectList(db.THUONGHIEUx, "MaTH", "TenTH");
            ViewBag.MaXX = new SelectList(db.XUATXUs, "MaXX", "TenXX");
            if (fileUpload1 == null)
            {
                ViewBag.ThongBaoAnh1 = "Chưa chọn ảnh";
                return View();
            }

            if (fileUpload2 == null)
            {
                ViewBag.ThongBaoAnh2 = "Chưa chọn ảnh";
                return View();
            }
            if (fileUpload3 == null)
            {
                ViewBag.ThongBaoAnh3 = "Chưa chọn ảnh";
                return View();
            }
            if (ModelState.IsValid)
            {

                // lưu tên của file
                var filename1 = Path.GetFileName(fileUpload1.FileName);
                var filename2 = Path.GetFileName(fileUpload2.FileName);
                var filename3 = Path.GetFileName(fileUpload3.FileName);
                // lưu đường dẫn của file
                var path1 = Path.Combine(Server.MapPath("~/Content/Images"), filename1);
                var path2 = Path.Combine(Server.MapPath("~/Content/Images"), filename2);
                var path3 = Path.Combine(Server.MapPath("~/Content/Images"), filename3);
                //kiểm tra hình ảnh đã tồn tại hay chưa
                if (System.IO.File.Exists(path1))
                {
                    ViewBag.ThongBaoAnh1 = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload1.SaveAs(path1);
                }
                if (System.IO.File.Exists(path2))
                {
                    ViewBag.ThongBaoAnh2 = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload1.SaveAs(path2);
                }
                if (System.IO.File.Exists(path3))
                {
                    ViewBag.ThongBaoAnh3 = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload1.SaveAs(path3);
                }
                //thêm vào cơ sở dữ liệu
                    sanpham.Anh1 = path1;
                    sanpham.Anh2 = path2;
                    sanpham.Anh2 = path3;
                    db.SANPHAMs.Add(sanpham);
                    db.SaveChanges();
            }
            return View("Index", "QLSP", new { page = 1 });
        }

        // GET: /QLSP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSP = new SelectList(db.LOAISANPHAMs, "MaLoaiSP", "TenLoaiSP", sanpham.MaLoaiSP);
            ViewBag.MaTH = new SelectList(db.THUONGHIEUx, "MaTH", "TenTH", sanpham.MaTH);
            ViewBag.MaXX = new SelectList(db.XUATXUs, "MaXX", "TenXX", sanpham.MaXX);
            return View(sanpham);
        }

        // POST: /QLSP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include="MaSP,TenSP,Gia,GiamGia,LuotXem,Anh1,Anh2,Anh3,MoTa1,MoTa2,MoTa3,MoTa4,MoTa5,SoLuong,MaLoaiSP,MaTH,MaXX,Moi")] SANPHAM sanpham)
        {
            if (ModelState.IsValid)
            {
                //Tạo thay đổi sản phẩm trong model sau đó lưu lại
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSP = new SelectList(db.LOAISANPHAMs, "MaLoaiSP", "TenLoaiSP", sanpham.MaLoaiSP);
            ViewBag.MaTH = new SelectList(db.THUONGHIEUx, "MaTH", "TenTH", sanpham.MaTH);
            ViewBag.MaXX = new SelectList(db.XUATXUs, "MaXX", "TenXX", sanpham.MaXX);
            return View(sanpham);
        }

        // GET: /QLSP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: /QLSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sanpham = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sanpham);
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
