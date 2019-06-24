using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanChuot.Models
{
    public class ItemGioHang
    {
        ShopBanChuotEntities db = new ShopBanChuotEntities();
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string AnhSP { get; set; }
        public int SoLuong { get; set; } // số lượng sản phẩm muốn mua
        public int DonGia { get; set; } // tiền của sản phẩm khi mua
        public int ThanhTien { get{return SoLuong*DonGia;}}

        public ItemGioHang(int masanpham)
        {
            SANPHAM SP = db.SANPHAMs.Single(n=>n.MaSP == masanpham);
            this.MaSP = masanpham;
            this.TenSP = SP.TenSP;
            this.AnhSP = SP.Anh1;
            this.DonGia = int.Parse(SP.GiamGia.ToString());
            this.SoLuong = 1;

        }

    }
}