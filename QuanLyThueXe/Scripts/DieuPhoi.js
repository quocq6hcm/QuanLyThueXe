$(document).ready(function () {
    ChonCongTy();
    ChonTaiXe();
    $('#ChonCongTy').change(function () {
        ChonCongTy();
    });
    $('#ChonTaiXe').change(function () {
        ChonTaiXe();
    });
    $('#lstLoaiXe').change(function () {
        LayXeTheoLoai();
    });
    function ChonCongTy() {
        var mact = $('#congty_list').val();
        if (mact == 'DETRA') {
            $('#BienSoXe').hide();
            $('#Xe').show();
        }
        else {
            $('#BienSoXe').show();
            $('#Xe').hide();
        }
    };
    function ChonTaiXe() {
        var mact = $('#taixe_list').val();
        if (mact == 'DETRA') {
            $('#TaiXeNgoai').hide();
            $('#TaiXe').show();
        }
        else {
            $('#TaiXeNgoai').show();
            $('#TaiXe').hide();
        }
    }
    function LayXeTheoLoai() {
        var maLX = $('#lstLoaiXe').val();
        $.ajax({
            url: "/DieuPhoi/LayLoaiXeTheoMaLoaiXe?MaLoaiXe=" + maLX,
            type: "get",
            success: function (result) {
                var html = "";
                html += "<option></option>";
                html += "<optgroup label=''>";
                $.each(result, function (key, item) {
                    if (item.Status == "1") {
                        html += " <option value=" + item.MaXe + ">" + item.BienSo + " (Đã xếp)</option>";
                    }
                    else {
                        html += "<option value=" + item.MaXe + ">" + item.BienSo + "</option>";
                    }
                });
                html += "</optgroup>";
                $("#xe_list").html(html);
            }
        });
    }
})
