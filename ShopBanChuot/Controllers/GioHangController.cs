using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanChuot.Models;
namespace ShopBanChuot.Controllers
{
    public class GioHangController : Controller
    {
        //lấy giỏ hàng
        public List<ItemGioHang> LayGioHang()
        {
            List<ItemGioHang> listItemGioHang = Session["GioHang"] as List<ItemGioHang>;
            if(listItemGioHang == null)
            {
                //nếu giỏ hàng chưa tồn tại thì tạo 1 session lưu giỏ hàng
                listItemGioHang = new List<ItemGioHang>();
                Session["GioHang"] = listItemGioHang;
            }
            return listItemGioHang;
        }
        //thêm sản phẩm vào giỏ hàng
        public ActionResult ThemItemGioHang(int MaSP,string strUrl, FormCollection f)
        {
            //Lấy ra session GioHang
            List<ItemGioHang> listItemGioHang = LayGioHang();
            ItemGioHang item = listItemGioHang.Find(n => n.MaSP == MaSP);
            //lấy số lượng mà người dùng nhập vào:
            int SoLuong =1;
            if(f.Get("txtSoLuong")!=null)
            {
                try
                {
                    SoLuong = Convert.ToInt32(f.Get("txtSoLuong").ToString());
                    if (SoLuong < 1) SoLuong = 1;
                }
                catch { SoLuong = 1; }

            }

            if(item == null) // nếu sản phẩm chưa tồn tại trong giỏ hàng
            {
                item = new ItemGioHang(MaSP);
                item.SoLuong = SoLuong;
                listItemGioHang.Add(item);
            }
            else
            {
                item.SoLuong = SoLuong; // có sản phẩm rồi
            }
            return Redirect(strUrl);
        }

        //Sửa Item giỏ hàng

        [HttpGet]
        public ActionResult SuaItemGioHang(int MaSP)
        {
            List<ItemGioHang> listItemGioHang = LayGioHang();
            ViewBag.TongTien = TongTien();
            return View(listItemGioHang);
        }
   
        [HttpPost]
        public ActionResult SuaItemGioHang(int MaSP, FormCollection f)
        {
            //Lấy ra session GioHang
            List<ItemGioHang> listItemGioHang = LayGioHang();
            ItemGioHang item = listItemGioHang.SingleOrDefault(n=>n.MaSP == MaSP); // lấy item cần sửa trong giỏ hàng
            item.SoLuong = int.Parse(f.Get("txtSoLuong"));
            return RedirectToAction("GioHang", "GioHang");
        }
        // Xóa item giỏ hàng
        [HttpGet]
        public ActionResult XoaItemGioHang(int MaSP)
        {
            //Lấy ra session GioHang
            List<ItemGioHang> listItemGioHang = LayGioHang();
            ItemGioHang item = listItemGioHang.SingleOrDefault(n=>n.MaSP == MaSP); // lấy item cần xóa trong giỏ hàng
            listItemGioHang.Remove(item); // xóa khỏi danh sách giỏ hàng
            return RedirectToAction("GioHang", "GioHang");
        }
        // view của giỏ hàng
        public ActionResult GioHang()
        {
            List<ItemGioHang> listItemGioHang = LayGioHang();
            ViewBag.TongTien = TongTien();
            return View(listItemGioHang);
        }
        //tính tổng tiền
        public int TongTien()
        {
            //Lấy ra session GioHang
            List<ItemGioHang> listItemGioHang = LayGioHang();
            int s = 0; // tổng tiền
            foreach (var item in listItemGioHang)
	        {
		        s = item.ThanhTien + s;
	        }
            return s;
        }

        public ActionResult GioHangPartial()
        {
            List<ItemGioHang> listItemGioHang = LayGioHang();
            ViewBag.SoLuong = listItemGioHang.Count();
            return PartialView();
        }

        //xây dựng chức năng đặt hàng
        public ActionResult DatHang()
        {
            
            ShopBanChuotEntities db = new ShopBanChuotEntities();
            //nếu người dùng chưa đăng nhập
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            //kiểm tra tình trạng giỏ hàng nếu giỏ hàng trống trả về trang chủ
            List<ItemGioHang> listItemGioHang = LayGioHang();
            if(listItemGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            // nếu giỏ hàng có ít nhất 1 sản phẩm
            DONHANG DH = new DONHANG(); // tạo 1 đơn hàng mới
            TAIKHOAN TK = (TAIKHOAN)Session["TaiKhoan"]; //lấy thông tin tài khoản đang lưu trong phiên tài khoản
            DH.NgayDatHang = DateTime.Now;
            DH.TenTaiKhoan = TK.TenTaiKhoan;
            db.DONHANGs.Add(DH);
            foreach (var item in listItemGioHang)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.MaDH = DH.MaDH;
                ctdh.MaSP = item.MaSP;
                ctdh.SoLuong = item.SoLuong;
                ctdh.DonGia = item.DonGia;
                db.CHITIETDONHANGs.Add(ctdh);
            }
            db.SaveChanges();
            //đặt hàng thành công trả về thông báo thành công

            return RedirectToAction("DonHangCuaToi");
        }

        //View đặt hàng thành công
        public ActionResult DonHangCuaToi()
        {
            List<ItemGioHang> listItemGioHang = LayGioHang();
            ViewBag.TongTien = TongTien(); // lưu giá trị tính toán tiền
            return View(listItemGioHang);
        }
	}
}