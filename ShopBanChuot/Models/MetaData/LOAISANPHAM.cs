using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//thêm 2 thư viện mới
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopBanChuot.Models
{
    [MetadataTypeAttribute(typeof(LOAISANPHAMMetaData))]
    public partial class LOAISANPHAM
    {
        internal sealed class LOAISANPHAMMetaData
        {
            [DisplayName("Mã loại sản phẩm")]
            public int MaLoaiSP { get; set; }
            [DisplayName("Tên loại sản phẩm")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TenLoaiSP { get; set; }
        }

    }
}