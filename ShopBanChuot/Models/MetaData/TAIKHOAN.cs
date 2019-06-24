using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//thêm 2 thư viện mới
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ShopBanChuot.Models
{
    [MetadataTypeAttribute(typeof(TAIKHOANMetaData))]
    public partial class TAIKHOAN
    {
        internal sealed class TAIKHOANMetaData
        {
            [DisplayName("Tên tài khoản")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]            
            public string TenTaiKhoan { get; set; }
            [DisplayName("Mật khẩu")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string MatKhau { get; set; }
            [DisplayName("Tên khách hàng")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TenKhachHang { get; set; }
            [DisplayName("Giới tính")]
            public string GioiTinh { get; set; }
            [DisplayName("Số điện thoại")]

            public string SDT { get; set; }
            [DisplayName("Email")]
            public string Email { get; set; }
            [DisplayName("Địa chỉ")]
            public string DiaChi { get; set; }

        }

    }
}