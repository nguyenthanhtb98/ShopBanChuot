
    $(".SapXep").change(function()
    {
        var val = $(this).val();
        var text = $(this).text();
        //var MaSP = "1";
        //$.post("/SanPham/ThongTinSanPham", MaSP).done(function (response, status, jqxhr) {
        //    alert("sucess");
        //})
        
       if (val == "GiaThapToiCao")
       {
           window.location.href = "/SanPham/Index?sapxep=0";
       }
       else if (val == "GiaCaoToiThap")
       {
           window.location.href = "/SanPham/Index?sapxep=1";
       }
       else if (val == "LuotXemNhieu")
       {
           window.location.href = "/SanPham/Index?sapxep=2";
       }


    });
    $(document).ready(function () {
        $(".ThemVaoGioHang").click(function(){
            alert("Đã thêm sản phẩm vào giỏ hàng");
        });
    });

    