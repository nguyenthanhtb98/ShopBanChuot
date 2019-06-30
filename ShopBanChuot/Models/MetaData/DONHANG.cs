using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//thêm 2 thư viện mới
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ShopBanChuot.Models
{
    public partial class DONHANG
    {
        [MetadataTypeAttribute(typeof(DONHANGMetaData))]
        internal sealed class DONHANGMetaData
        {
            [DisplayName("Mã đơn hàng")]
            public int MaDH { get; set; }
            [DisplayName("Tên tài khoản")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TenTaiKhoan { get; set; }
            [DisplayName("Ngày đặt hàng")]
            public Nullable<System.DateTime> NgayDatHang { get; set; }
            [DisplayName("Ngày giao hàng")]
            public Nullable<System.DateTime> NgayGiaoHang { get; set; }
            [DisplayName("Trạng thái")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Range(0, 1)]
            public Nullable<int> TrangThai { get; set; }

        }

    }
}