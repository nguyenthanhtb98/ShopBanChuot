using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanChuot.Models;
namespace ShopBanChuot.Controllers
{
    public class SlidebarController : Controller
    {
        //
        // GET: /Slidebar/
        ShopBanChuotEntities db = new ShopBanChuotEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoaiSanPhamPartial()
        {
            return View(db.LOAISANPHAMs.ToList());
        }
        public ActionResult ThuongHieuPartial()
        {
            return View(db.THUONGHIEUx.ToList());
        }
        public ActionResult XuatXuPartial()
        {
            return View(db.XUATXUs.ToList());
        }

	}
}