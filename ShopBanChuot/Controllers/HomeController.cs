using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanChuot.Models;

namespace ShopBanChuot.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ShopBanChuotEntities db = new ShopBanChuotEntities();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var listSP = db.SANPHAMs.ToList();
            return View(listSP);
        }

        [HttpGet]
        public ActionResult SanPhamMoiPartial()
        {
            var listSP = db.SANPHAMs.Where(n => n.Moi == 1).ToList();
            return View(listSP);
        }

        [HttpGet]
        public ActionResult SanPhamNoiBatPartial()
        {
            var listSP = db.SANPHAMs.OrderByDescending(n=>n.LuotXem).Take(12).ToList(); // lấy 12 hot sản phẩm chia 3 nhóm, mỗi nhóm 4 sản phẩm
            return View(listSP);
        }

	}
}