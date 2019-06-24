using System;
//thêm 2 thư viện mới
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopBanChuot.Models
{
    [MetadataTypeAttribute(typeof(SANPHAMMetaData))]
    public partial class SANPHAM
    {
        internal sealed class SANPHAMMetaData
        {

            [DisplayName("Mã sản phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public int MaSP { get; set; }
            [DisplayName("Tên sản phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TenSP { get; set; }
            [DisplayName("Giá")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Range(0,100000000)]
            public Nullable<int> Gia { get; set; }
            [DisplayName("Giảm giá")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Range(0, 100000000)]
            public Nullable<int> GiamGia { get; set; }
            [DisplayName("Lượt xem")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Range(0, 100000000)]
            public Nullable<int> LuotXem { get; set; }
            [DisplayName("Ảnh 1")]
            public string Anh1 { get; set; }
            [DisplayName("Ảnh 2")]
            public string Anh2 { get; set; }
            [DisplayName("Ảnh 3")]
            public string Anh3 { get; set; }
            [DisplayName("Mô tả 1")]
            public string MoTa1 { get; set; }
            [DisplayName("Mô tả 2")]
            public string MoTa2 { get; set; }
            [DisplayName("Mô tả 3")]
            public string MoTa3 { get; set; }
            [DisplayName("Mô tả 4")]
            public string MoTa4 { get; set; }
            [DisplayName("Mô tả 5")]
            public string MoTa5 { get; set; }
            [DisplayName("Số lượng")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Range(0, 10000)]
            public Nullable<int> SoLuong { get; set; }
            [DisplayName("Mã loại sản phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<int> MaLoaiSP { get; set; }
            [DisplayName("Mã thương hiệu")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<int> MaTH { get; set; }
            [DisplayName("Mã xuất xứ")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<int> MaXX { get; set; }
            [DisplayName("Mới")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public Nullable<int> Moi { get; set; }

        }
    }
}