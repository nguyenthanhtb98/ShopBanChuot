using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//thêm 2 thư viện mới
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ShopBanChuot.Models
{
    [MetadataTypeAttribute(typeof(XUATXUMetaData))]
    public partial class XUATXU
    {
        internal sealed class XUATXUMetaData
        {
            [DisplayName("Mã xuất xứ")]
            public int MaXX { get; set; }

            [DisplayName("Tên xuất xứ")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            public string TenXX { get; set; }
        }

    }
}