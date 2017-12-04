$(document).ready(function () {
    searchlstKhachHang();
    $("#dropKH").change(function () {
        searchlstKhachHang();
    });

    $("#khachHangBangGia").change(function () {
        LayDanhSachLoTrinhTheoMaKH();
    });

    //$("#SoKM").keypess(function () {
    //    //var numberCheck = /^[0-9]+$/;
    //    var x = $(this).val();
    //    //if (!x.match(numberCheck)) {
    //    //    $(this).sibling("error-number").text();
    //    //}
    //});

    function searchlstKhachHang() {
        var valKhachHang = $("#dropKH").val();
        $.ajax({
            url: "/BangGia/LayDanhSachBangGiaTheoMaKhachHang?maKhangHang=" + valKhachHang,
            type: "get",
            success: function (result) {
                if (!$.isEmptyObject(result)) {
                    var html = "";
                    html += "<table class=\"table table-striped table-hover table-bordered\" id=\"sample_editable_1\">";
                    html += "<thead>";
                    html += "<tr>";
                    html += "<th style=\"display:none\"> STT </th>";
                    html += "<th> Lộ trình </th>";
                    html += "<th> Khách hàng </th>";
                    html += "<th> Loại Xe</th>";
                    html += "<th> Thời gian </th>";
                    html += "<th> Số KM </th>";
                    html += "<th> Giá </th>";
                    html += "</tr>";
                    html += "</thead>";
                    html += "<tbody id=\"searchKH\">";
                    $.each(result, function (key, item) {
                        html += "<tr>";
                        html += "<td style=\"display:none;\"><span>" + item.LoaiXes.STT + "</span></td>";
                        html += "<td><a href='/BangGia/ChiTietGia?mabg=" + item.MaBangGia + "'>" + item.LoTrinhs.TenLoTrinh + "</a></td>";
                        html += "<td><span>" + item.KhachHangs.TenKH + "</span></td>";
                        html += "<td><span><span style=\"visibility:hidden\">" + item.LoaiXes.STT + "</span>" + item.LoaiXes.TenLoaiXe + "</span></td>";
                        html += "<td><span>" + item.ThoiGian + "</span></td>";
                        html += "<td><span>" + item.SoKM + "</span></td>";
                        html += "<td><span>" + item.Gia + "</span></td>";
                        html += "</tr>";
                    });
                    html += "</tbody>";
                    html += "</table>";
                    $("#bangGiaTable").html(html);
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

                            $("#sample_editable_1_new").click(function (e) {
                                if (e.preventDefault(), o && r) {
                                    if (!confirm("Previose row not saved. Do you want to save it ?"))
                                        return l.fnDeleteRow(r),
                                      r = null,
                                            void (o = !1);
                                    n(l, r),
                                    $(r).find("td:first").html("Untitled"),
                                      r = null,
                                      o = !1
                                }
                                var a = l.fnAddData(["", "", "", "", "", ""]),
                                    i = l.fnGetNodes(a[0]); t(l, i), r = i, o = !0
                            }),
                            a.on("click", ".delete", function (e) {
                                if (e.preventDefault(), 0 != confirm("Are you sure to delete this row ?")) {
                                    var t = $(this).parents("tr")[0]; l.fnDeleteRow(t),
                                    alert("Deleted! Do not forget to do some ajax to sync with backend :)")
                                }
                            }),
                            a.on("click", ".cancel", function (t) {
                                t.preventDefault(), o ? (l.fnDeleteRow(r), r = null, o = !1) : (e(l, r),
                                    r = null)
                            }),
                            a.on("click", ".edit", function (a) {
                                a.preventDefault(); var o = $(this).parents("tr")[0];
                                null !== r && r != o ? (e(l, r), t(l, o),
                                r = o) : r == o && "Lýu" == this.innerHTML ? (n(l, r),
                                r = null,
                                alert("Updated! Do not forget to do some ajax to sync with backend :)")) : (t(l, o), r = o)
                            })
                        };
                        return { init: function () { e() } }
                    }();
                    jQuery(document).ready(function () { TableDatatablesEditable.init() });
                    ////////////
                }
                else
                {
                    var html = "";
                    html += "<table class=\"table table-striped table-hover table-bordered\" id=\"sample_editable_1\">";
                    html += "<thead>";
                    html += "<tr>";
                    html += "<th style=\"display:none\"> STT </th>";
                    html += "<th> Lộ trình </th>";
                    html += "<th> Khách hàng </th>";
                    html += "<th> Loại Xe</th>";
                    html += "<th> Thời gian </th>";
                    html += "<th> Số KM </th>";
                    html += "<th> Giá </th>";
                    html += "</tr>";
                    html += "</thead>";
                    html += "<tbody id=\"searchKH\">";
                    $.each(result, function (key, item) {
                        html += "<tr>";
                        //html += "<td style=\"display:none;\"><span>" + item.LoaiXes.STT + "</span></td>";
                        //html += "<td><a href='/BangGia/ChiTietGia?mabg=" + item.MaBangGia + "'>" + item.LoTrinhs.TenLoTrinh + "</a></td>";
                        //html += "<td><span>" + item.KhachHangs.TenKH + "</span></td>";
                        //html += "<td><span><span style=\"visibility:hidden\">" + item.LoaiXes.STT + "</span>" + item.LoaiXes.TenLoaiXe + "</span></td>";
                        //html += "<td><span>" + item.ThoiGian + "</span></td>";
                        //html += "<td><span>" + item.SoKM + "</span></td>";
                        //html += "<td><span>" + item.Gia + "</span></td>";
                        html += "</tr>";
                    });
                    html += "</tbody>";
                    html += "</table>";
                    $("#bangGiaTable").html(html);
                }
            }
        });
    }

    function LayDanhSachLoTrinhTheoMaKH() {
        var makh = $("#khachHangBangGia").val();
        $.ajax({
            url: "/BangGia/LayLoTrinhTheoMaKH?maKhangHang=" + makh,
            type: "get",
            success: function (result) {
                var html = "";
                //html+="<select id=\"loTrinhBangGia\" name=\"MaLoTrinh\" class=\"bs-select form-control isEmpty\" data-live-search=\"true\" data-size=\"8\">";
                $.each(result, function (key, item) {
                    html += '<option value=' + item.MaLoTrinh + '>' + item.TenLoTrinh + '</option>';
                });
                //html += "</select>";
                $("#lotrinhBG").html(html);
            }
        })
    }


});