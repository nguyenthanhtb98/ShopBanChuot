using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanChuot.Models;
using System.Web.Security;

namespace ShopBanChuot.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        ShopBanChuotEntities db = new ShopBanChuotEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(TAIKHOAN TK)
        {
            if(ModelState.IsValid)
            {
                string strTenTK = TK.TenTaiKhoan.Trim();
                TAIKHOAN TaiKhoan = db.TAIKHOANs.Find(strTenTK);
                if(TaiKhoan == null) //nếu tài khoản chưa tồn tại
                {
                    db.TAIKHOANs.Add(TK);
                    //thêm vào cơ sở dữ liệu
                    db.SaveChanges();
                    ViewBag.DangKyThanhCong = "Đăng ký thành công";
                }
                else
                {
                    ViewBag.ThongBaoTrungTK = "Tên tài khoản đã tồn tại";

                }
                return View();
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string strTenTaiKhoan = f.Get("txtTenTaiKhoan").ToString().Trim();
            string strMatKhau = f.Get("txtMatKhau").ToString().Trim();
            TAIKHOAN TK = db.TAIKHOANs.SingleOrDefault(n => n.TenTaiKhoan == strTenTaiKhoan && n.MatKhau == strMatKhau);
            if(TK!=null)
            {
                FormsAuthentication.SetAuthCookie(TK.TenTaiKhoan, false);
                Session["TaiKhoan"] = TK;
                Session["TenTaiKhoan"] = TK.TenTaiKhoan;                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Đăng nhập thất bại";
                return View();
            }
        }

        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            Session["TaiKhoan"] = null;
            Session["TenTaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
	}
}