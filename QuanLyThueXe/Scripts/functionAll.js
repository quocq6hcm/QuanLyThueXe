$(document).ready(function () {
    //Function bắt buộc nhập, thêm class isEmpty vào các thẻ để kiểm tra
    $("input[type='submit'],button[type='submit']").click(function () {
        $('.isEmpty').css({ "border": "solid 1px #c2cad8" });
        $('.error-message').text("");
        var x = $('.isEmpty');
        var i = 0;
        for (var j = 0; j < x.length; j++) {
            if ($(x[j]).val().length == "" || $(x[j]).val() == null) {
                $((x[j])).css({ "border": "solid 1px red" });
                var txtName = $(x[j]).attr("data-Name");
                $((x[j])).siblings(".error-message").text(txtName + " là bắt buộc!!!");
                i++;
            }
        }
        if (i > 0) {
            return false;
        }
        else {
            return true;
        }
    });

    $(".SoLuong, input[name='SoLuongNguoi'],#GiamGia,.SoLuongCP,#GioUocTinh,.SoLuongMoi,.GiaXeMoi,input[name='SoLuongNguoiMoi'],#GiamGiaMoi,.SoLuongCPMoi")
        .off('keypress').on('keypress', function (e) {
            if (e.which == '32') {
                return false;
            }
        });

    $("#GiamGia,.SoLuongCP,.GiaXeMoi,#GiamGiaMoi,.SoLuongCPMoi")
       .off('keyup').on('keyup', function (e) {
           var x = $(this).val();
           if (x) {
               x = x.replace(".", "").replace(".", "").replace(".", "").replace(".", "").replace(".", "");
               //x = x.replace(".", "");
               //x = x.replace(".", "");
               x = parseFloat(x);
               $(this).val(formatNumber(x.toString(),',','.'));
           }
       });
    //format tiền tệ
    function formatNumber(nStr, decSeperate, groupSeperate) {
        nStr += '';
        x = nStr.split(decSeperate);
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + groupSeperate + '$2');
        }
        return x1 + x2;
    };
});