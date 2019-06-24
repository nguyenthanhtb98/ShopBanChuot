using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//thêm 2 thư viện mới
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ShopBanChuot.Models
{
    public partial class CHITIETDONHANG
    {
        [MetadataTypeAttribute(typeof(CHITIETDONHANGMetaData))]
        internal sealed class CHITIETDONHANGMetaData
        {
            [DisplayName("Mã chi tiết đơn hàng")]
            public int MaCTDH { get; set; }
            [DisplayName("Mã sản phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<int> MaSP { get; set; }
            [DisplayName("Số lượng")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<int> SoLuong { get; set; }
            [DisplayName("Đơn giá")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<int> DonGia { get; set; }
            [DisplayName("Mã đơn hàng")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<int> MaDH { get; set; }
        }

    }
}