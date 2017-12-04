$(document).ready(function () {
    LayDanhSachCTHDTheoNgay();
    $("#dLichChay").change(function () {
        LayDanhSachCTHDTheoNgay();
    });

    function LayDanhSachCTHDTheoNgay() {
        var date = $("#dLichChay").val();
        $.ajax({
            url: "/Home/LichTheoNgay?ngay=" + date,
            type: "get",
            success: function (result) {
                if (!$.isEmptyObject(result)) {
                    var d = moment($("#dLichChay").val(), "DD-MM-YYYY");
                    var d1 = new Date(d);
                    var html = "";
                    html += "<table class=\"table table-striped table-hover table-bordered\" id=\"sample_editable_1\">";
                    html += "<thead>";
                    html += "<tr>";
                    html += "<th width=\"8%\">Ngày/Tháng</th>";
                    html += "<th width=\"7%\">Giờ đón</th>";
                    html += "<th>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Khách hàng &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </th>";
                    html += "<th>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Công ty cung cấp &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</th>";
                    html += "<th>Tài xế</th>";
                    html += "<th>Xe</th>";
                    html += "<th>Hướng dẫn viên</th>";
                    html += "<th>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Lộ trình  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</th>";
                    html += "<th>Số khách</th>";
                    html += "<th width=\"5%\">Ngày</th>";
                    html += "</tr>";
                    html += "</thead>";
                    html += "<tbody>";
                    $.each(result, function (key, item) {
                        html += "<tr>";
                        //html += "<td>" + moment.date($("#dLichChay").val()) + "/" + (moment.month($("#dLichChay").val()) + 1) + "</td>";
                        html += "<td>" + (d1).getDate() + "/" + (d1.getMonth() + 1) + "</td>";
                        html += "<td>" + (formatDateFromAsp(item.GioDon)).getHours() + ":" + (formatDateFromAsp(item.GioDon)).getMinutes() + "</td>";
                        html += "<td>" + item.KhachHangs.TenKH + "</td>";
                        html += "<td>";
                        if (!IsNullOrEmptyJS(item.MaCongTy)) {
                            html += "<span>" + item.CongTies.TenCongTy + "</span>";
                        }
                        else {
                            html += "<span></span>";
                        }
                        html += "</td>";
                        html += "<td>";
                        if (IsNullOrEmptyJS(item.MaTaiXe) && IsNullOrEmptyJS(item.TaiXeNgoai)) {
                            html += "<a class='label label-sm label-warning' href='/DieuPhoi/ChiTietDieuPhoiTaiXe?SoCTHopDong=" + item.SoCTHopDong + "'>Điều phối tài xế</a>";
                        }
                        else if (!IsNullOrEmptyJS(item.TaiXeNgoai)) {
                            html += "<a class='label label-sm label-primary' href='/DieuPhoi/ChiTietDieuPhoiTaiXe?SoCTHopDong=" + item.SoCTHopDong + "'> " + item.TaiXeNgoai + "</a>";
                        }
                        else if (!IsNullOrEmptyJS(item.MaTaiXe)) {
                            html += "<a class='label label-sm label-primary' href='/DieuPhoi/ChiTietDieuPhoiTaiXe?SoCTHopDong=" + item.SoCTHopDong + "'>" + item.TaiXes.HoTen + " </br> &nbsp;&nbsp;&nbsp;&nbsp;" + item.TaiXes.SDT + "&nbsp;&nbsp;&nbsp;</a>";
                        }
                        html += "</td>";
                        html += "<td>";
                        if (IsNullOrEmptyJS(item.MaXe) && IsNullOrEmptyJS(item.BienSoXe)) {
                            html += "<a class='label label-sm label-warning' href='/DieuPhoi/ChiTietDieuPhoiXe?SoCTHopDong=" + item.SoCTHopDong + "'> Điều phối xe</a>";
                        }
                        else if (!IsNullOrEmptyJS(item.BienSoXe)) {
                            html += "<a class='label label-sm label-primary' href='/DieuPhoi/ChiTietDieuPhoiXe?SoCTHopDong=" + item.SoCTHopDong + "'> " + item.LoaiXes.TenLoaiXe + " + " + item.BienSoXe + "</a>";
                        }
                        else if (!IsNullOrEmptyJS(item.MaXe)) {
                            html += "<a class='label label-sm label-primary' href='/DieuPhoi/ChiTietDieuPhoiXe?SoCTHopDong=" + item.SoCTHopDong + "'> " + item.LoaiXes.TenLoaiXe + " + " + item.Xes.BienSo + "</a>";
                        }
                        html += "</td>";
                        if (!IsNullOrEmptyJS(item.HuongDanVien)) {
                            html += "<td>" + item.HuongDanVien + "</td>";
                        }
                        else {
                            html += "<td></td>";
                        }
                        html += "<td>" + item.LoTrinhs.TenLoTrinh + "</td>";
                        html += "<td>" + item.SoLuongNguoi + "</td>";
                        html += "<td>" + (formatDateFromAsp(item.NgayDi)).getDate() + " - " + (formatDateFromAsp(item.NgayVe)).getDate() + "</td>";
                        html += "</tr>";
                    });
                    html += "</tbody>";
                    html += "</table>";
                    $("#lichChayTheoNgay").html(html);

                    // Định dạng lại table mẫu của template
                    var TableDatatablesEditable = function () {
                        var e = function () {
                            function e(e, t) {
                                for (var n = e.fnGetData(t),
                                    a = $(">td", t),
                                    l = 0,
                                    r = a.length; r > l; l++)
                                    e.fnUpdate(n[l], t, l, !1);
                                e.fnDraw()
                            }
                            function t(e, t) {
                                var n = e.fnGetData(t), a = $(">td", t);
                                a[1].innerHTML = '<input type="text" class="form-control input-small" value="' + n[1] + '">',
                                a[2].innerHTML = '<input type="text" class="form-control input-small" value="' + n[2] + '">',
                                a[3].innerHTML = '<input type="text" class="form-control input-small" value="' + n[3] + '">',
                                a[4].innerHTML = '<a class="edit" href="CapNhat">Lýu</a>',
                                a[5].innerHTML = '<a class="cancel" href="">Cancel</a>'
                            }
                            function n(e, t) {
                                var n = $("input", t);
                                e.fnUpdate(n[0].value, t, 0, !1),
                                e.fnUpdate(n[1].value, t, 1, !1),
                                e.fnUpdate(n[2].value, t, 2, !1),
                                e.fnUpdate(n[3].value, t, 3, !1),
                                e.fnUpdate('<a class="edit" href="">Edit</a>', t, 4, !1),
                                e.fnUpdate('<a class="delete" href="">Delete</a>', t, 5, !1),
                                e.fnDraw()
                            }
                            var a = $("#sample_editable_1"),
                                l = a.dataTable({
                                    lengthMenu: [[5, 15, 20, -1], [5, 15, 20, "All"]],
                                    pageLength: -1,
                                    language: { lengthMenu: "_MENU_" },
                                    columnDefs: [{ orderable: !0, targets: [0] },
                                    { searchable: !0, targets: [0] }],
                                    order: [[0, "asc"]]
                                }),
                            r = ($("#sample_editable_1_wrapper"), null), o = !1;
                        };
                        return { init: function () { e() } }
                    }();
                    jQuery(document).ready(function () { TableDatatablesEditable.init() });
                }
                else
                {
                    var html = "";
                    html += "<table class=\"table table-striped table-hover table-bordered\" id=\"sample_editable_1\">";
                    html += "<thead>";
                    html += "<tr>";
                    html += "<th>Ngày/Tháng</th>";
                    html += "<th>Giờ đón</th>";
                    html += "<th>Khách hàng</th>";
                    html += "<th>Công ty cung cấp</th>";
                    html += "<th>Tài xế</th>";
                    html += "<th>Xe</th>";
                    html += "<th>Hướng dẫn viên</th>";
                    html += "<th>Lộ trình</th>";
                    html += "<th>Số khách</th>";
                    html += "<th>Ngày</th>";
                    html += "</tr>";
                    html += "</thead>";
                    html += "<tbody>";
                    $.each(result, function (key, item) {
                        html += "<tr>";
                        //html += "<td>" + moment.date($("#dLichChay").val()) + "/" + (moment.month($("#dLichChay").val()) + 1) + "</td>";
                        //html += "<td>" + (d1).getDate() + "/" + (d1.getMonth() + 1) + "</td>";
                        //html += "<td>" + (formatDateFromAsp(item.GioDon)).getHours() + ":" + (formatDateFromAsp(item.GioDon)).getMinutes() + "</td>";
                        //html += "<td>" + item.KhachHangs.TenKH + "</td>";
                        //html += "<td>";
                        //if (!IsNullOrEmptyJS(item.MaCongTy)) {
                        //    html += "<span>" + item.CongTies.TenCongTy + "</span>";
                        //}
                        //else {
                        //    html += "<span></span>";
                        //}
                        //html += "</td>";
                        //html += "<td>";
                        //if (IsNullOrEmptyJS(item.MaTaiXe) && IsNullOrEmptyJS(item.TaiXeNgoai)) {
                        //    html += "<a class='label label-sm label-warning' href='/DieuPhoi/ChiTietDieuPhoiTaiXe?SoCTHopDong=" + item.SoCTHopDong + "'>Điều phối tài xế</a>";
                        //}
                        //else if (!IsNullOrEmptyJS(item.TaiXeNgoai)) {
                        //    html += "<a class='label label-sm label-primary' href='/DieuPhoi/ChiTietDieuPhoiTaiXe?SoCTHopDong=" + item.SoCTHopDong + "'> " + item.TaiXeNgoai + "</a>";
                        //}
                        //else if (!IsNullOrEmptyJS(item.MaTaiXe)) {
                        //    html += "<a class='label label-sm label-primary' href='/DieuPhoi/ChiTietDieuPhoiTaiXe?SoCTHopDong=" + item.SoCTHopDong + "'>" + item.TaiXes.HoTen + " + " + item.TaiXes.SDT + "</a>";
                        //}
                        //html += "</td>";
                        //html += "<td>";
                        //if (IsNullOrEmptyJS(item.MaXe) && IsNullOrEmptyJS(item.BienSoXe)) {
                        //    html += "<a class='label label-sm label-warning' href='/DieuPhoi/ChiTietDieuPhoiXe?SoCTHopDong=" + item.SoCTHopDong + "'> Điều phối xe</a>";
                        //}
                        //else if (!IsNullOrEmptyJS(item.BienSoXe)) {
                        //    html += "<a class='label label-sm label-primary' href='/DieuPhoi/ChiTietDieuPhoiXe?SoCTHopDong=" + item.SoCTHopDong + "'> " + item.LoaiXes.TenLoaiXe + " + " + item.BienSoXe + "</a>";
                        //}
                        //else if (!IsNullOrEmptyJS(item.MaXe)) {
                        //    html += "<a class='label label-sm label-primary' href='/DieuPhoi/ChiTietDieuPhoiXe?SoCTHopDong=" + item.SoCTHopDong + "'> " + item.LoaiXes.TenLoaiXe + " + " + item.Xes.BienSo + "</a>";
                        //}
                        //html += "</td>";
                        //if (!IsNullOrEmptyJS(item.HuongDanVien)) {
                        //    html += "<td>" + item.HuongDanVien + "</td>";
                        //}
                        //else {
                        //    html += "<td></td>";
                        //}
                        //html += "<td>" + item.LoTrinhs.TenLoTrinh + "</td>";
                        //html += "<td>" + item.SoLuongNguoi + "</td>";
                        //html += "<td>" + (formatDateFromAsp(item.NgayDi)).getDate() + " - " + (formatDateFromAsp(item.NgayVe)).getDate() + "</td>";
                        html += "</tr>";
                    });
                    html += "</tbody>";
                    html += "</table>";
                    $("#lichChayTheoNgay").html(html);
                }
            }
        });
    }
    //<p>" + item.DiaDiemDon + "</p>


    //Hàm chuyển đổi ngày từ json
    function formatDateFromAsp(val) {
        var re = /-?\d+/;
        var m = re.exec(val);
        var d = new Date(parseInt(m[0]));
        return d;
    }
    //Kiểm tra chuối rỗng hoặc 
    function IsNullOrEmptyJS(str) {
        return (!str || 0 == str.length);
    }
    // parse a date in yyyy-mm-dd format
    function parseDate(input) {
        var parts = input.match(/(\d+)/g);
        // new Date(year, month [, date [, hours[, minutes[, seconds[, ms]]]]])
        return new Date(parts[0], parts[1] - 1, parts[2]); // months are 0-based
    }
})