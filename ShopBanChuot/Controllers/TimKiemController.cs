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
    public class TimKiemController : Controller
    {
        ShopBanChuotEntities db = new ShopBanChuotEntities();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int page = 1)
        {
            string TuKhoa = f.Get("txtTimKiem").ToString().Trim();
            ViewBag.TuKhoa = TuKhoa; //lưu lại từ khóa khi sang trang
            List<SANPHAM> listKetQuaTimKiem = db.SANPHAMs.Where(n => n.TenSP.Contains(TuKhoa)).ToList();
            //phân trang
            int pageSize = 9;
            if(listKetQuaTimKiem.Count ==0)
            {
                ViewBag.ThongBaoKQTK = "Không tìm thấy kết quả nào cho '"+TuKhoa +"'";
                return View(db.SANPHAMs.OrderBy(n=>n.Gia).ToPagedList(page,pageSize));
            }
            else
            {
                ViewBag.ThongBaoKQTK = "Tìm thấy " + listKetQuaTimKiem.Count + " kết quả phù hợp cho '"+TuKhoa+"'";
                return View(listKetQuaTimKiem.OrderBy(n=>n.Gia).ToPagedList(page,pageSize));
            }

        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(string TuKhoa, int page = 1)
        {
            List<SANPHAM> listKetQuaTimKiem = db.SANPHAMs.Where(n => n.TenSP.Contains(TuKhoa)).ToList();
            //phân trang
            int pageSize = 9;
            if (listKetQuaTimKiem.Count == 0)
            {
                ViewBag.ThongBaoKQTK = "Không tìm thấy kết quả nào cho '" + TuKhoa + "'";
                return View(db.SANPHAMs.OrderBy(n => n.Gia).ToPagedList(page, pageSize));
            }
            else
            {
                ViewBag.ThongBaoKQTK = "Tìm thấy " + listKetQuaTimKiem.Count + " kết quả phù hợp cho '" + TuKhoa + "'";
                return View(listKetQuaTimKiem.OrderBy(n => n.Gia).ToPagedList(page, pageSize));
            }

        }
	}
}