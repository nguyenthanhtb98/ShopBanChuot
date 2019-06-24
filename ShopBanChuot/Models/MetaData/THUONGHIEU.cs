using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//thêm 2 thư viện mới
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ShopBanChuot.Models
{
    [MetadataTypeAttribute(typeof(THUONGHIEUMetaData))]
    public partial class THUONGHIEU
    {
        internal sealed class THUONGHIEUMetaData
        {
            [DisplayName("Mã thương hiệu")]
            public int MaTH { get; set; }

            [DisplayName("Tên thương hiệu")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TenTH { get; set; }
        }

    }
}