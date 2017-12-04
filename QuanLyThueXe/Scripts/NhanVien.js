$(document).ready(function () {
    AnHienThongTinLoaiTaiXe();
    $("#searchLoaiNV").change(function () {
        searchDSNhanVien();
    });
    $('.dropLoaiNhanVien').change(function () {
        AnHienThongTinLoaiTaiXe();
    });
    function AnHienThongTinLoaiTaiXe()
    {
        var vl = $('.dropLoaiNhanVien').val();
        if (vl == "LNV2") {
            $('.divBangLai').show();
        }
        else {
            $('.divBangLai').hide();
        }
    }
    function searchDSNhanVien() {
        var Maloainv = $("#searchLoaiNV").val();
        var chuoi = "";
        $.ajax({
            url: "/NhanVien/TimNhanVienTheoLoaiNV?MaLoaiNV=" + Maloainv,
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            type: "get",
            success: function (data) {
                if (data.data) {
                    for (var i = 0; i < data.length; i++) {
                        chuoi += "<tr>";
                        chuoi += "<td> <a href='/NhanVien/Details?manv=" + data[i].MaNV + ">'" + data[i].MaLoaiNV + "</a></td>";
                        chuoi += "<td>" + data[i].HoTen + "</td>";
                        chuoi += "<td>" + data[i].Email + "</td>";
                        chuoi += "<td>" + data[i].SDT + "</td>";
                        chuoi += "<td>";
                        chuoi += "<span>";
                        if (data[i].Status == "0") {
                            chuoi += "Đang chờ";
                        }
                        else if (data[i].Status == "1") {
                            chuoi += "Đang chạy";
                        }
                        else {
                            chuoi += "Không chạy";
                        }
                        chuoi += "</span>";
                        chuoi += "</td>";
                        chuoi += "</tr>";
                    }
                    $("#sample_editable_1 tbody").html(chuoi);
                    console.log("Done!");
                }
                else {
                    console.log("false!");
                }
            }
        });
    }
});
