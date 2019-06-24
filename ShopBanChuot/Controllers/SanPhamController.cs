using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanChuot.Models;
using PagedList;
using PagedList.Mvc;
namespace ShopBanChuot.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        ShopBanChuotEntities db = new ShopBanChuotEntities();
        /// <summary>
        /// hiển thị tất cả sản phẩm
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
            int PageSize = 9; // số sản phẩm trên một trang
            var listSP = db.SANPHAMs.OrderBy(n=>n.Gia).ToPagedList(page, PageSize);
            ViewBag.TongSoLuongSP = db.SANPHAMs.ToList().Count();
            return View(listSP);
        }

        public ActionResult ThongTinSanPham(int MaSP)
        {
            SANPHAM SP = db.SANPHAMs.SingleOrDefault(n => n.MaSP == MaSP);
            if (SP == null)
            {
                //trả về trang báo lỗi
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.LoaiSP = db.LOAISANPHAMs.Single(n => n.MaLoaiSP == SP.MaLoaiSP).TenLoaiSP;
            ViewBag.ThuongHieu = db.THUONGHIEUx.Single(n => n.MaTH == SP.MaTH).TenTH;
            ViewBag.XuatXu = db.XUATXUs.Single(n => n.MaXX == SP.MaXX).TenXX;
            return View(SP);
        }
        // sản phẩm theo loại sản phẩm
        public ActionResult SanPhamTheoLoaiSanPham(int MaLoaiSP, int page = 1)
        {
            int PageSize = 9; // số sản phẩm trên một trang
            var listSP = db.SANPHAMs.Where(n => n.MaLoaiSP == MaLoaiSP).OrderBy(n => n.Gia).ToPagedList(page, PageSize);
            if (listSP == null)
            {
                ViewBag.Chuot = "Không có sản phẩm nào";
            }
            ViewBag.TongSoLuongSP = db.SANPHAMs.ToList().Count();
            return View("Index", listSP);
        }
        // sản phẩm theo thương hiệu
        public ActionResult SanPhamTheoThuongHieu(int MaTH, int page = 1)
        {
            int PageSize = 9; // số sản phẩm trên một trang
            var listSP = db.SANPHAMs.Where(n => n.MaTH == MaTH).OrderBy(n => n.Gia).ToPagedList(page, PageSize);
            if(listSP == null)
            {
                ViewBag.Chuot = "Không có sản phẩm nào";
            }
            ViewBag.TongSoLuongSP = db.SANPHAMs.ToList().Count();
            return View("Index",listSP);
        }
        // sản phẩm theo xuất xứ
        public ActionResult SanPhamTheoXuatXu(int MaXX, int page = 1)
        {
            int PageSize = 9; // số sản phẩm trên một trang
            var listSP = db.SANPHAMs.Where(n => n.MaXX == MaXX).OrderBy(n => n.Gia).ToPagedList(page, PageSize);
            if (listSP == null)
            {
                ViewBag.Chuot = "Không có sản phẩm nào";
            }
            ViewBag.TongSoLuongSP = db.SANPHAMs.ToList().Count();
            return View("Index", listSP);
        }

        //Sản phẩm liên quan của sản phẩm
        public ActionResult SanPhamLienQuanPartial(int MaSP)
        {
            SANPHAM SP = db.SANPHAMs.SingleOrDefault(n => n.MaSP == MaSP);
            List<SANPHAM> listSanPhamLienQuan = new List<SANPHAM>();
            listSanPhamLienQuan = db.SANPHAMs.Where(n => n.MaLoaiSP == SP.MaLoaiSP).Take(3).ToList();
            return View(listSanPhamLienQuan);
        }
	}


}