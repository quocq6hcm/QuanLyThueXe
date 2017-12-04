$(document).ready(function () {
    LayGiaXeMoi();
    LaySoLuongXeMoi();
    LayListMaLoaiXeMoi();
    LaySoLuongXeCPMoi();
    LayMaChiPhiMoi();
    $(".MaLoaiXeMoi").change(function () {
        LayGiaXeMoi();
        LaySoLuongXeMoi();
        LayListMaLoaiXeMoi();
        getBangGiaMoi();
    });
    $(".SoLuongMoi").change(function () {
        LayGiaXeMoi();
        LaySoLuongXeMoi();
        LayListMaLoaiXeMoi();
        getBangGiaMoi();
    });
    $(".GiaXeMoi").change(function () {
        LayGiaXeMoi();
        LaySoLuongXeMoi();
        LayListMaLoaiXeMoi();
        getBangGiaMoi();
    });
    $("#GiamGiaMoi").change(function () {
        LayGiaXeMoi();
        LaySoLuongXeMoi();
        LayListMaLoaiXeMoi();
        getBangGiaMoi();
    });

    //$("#khachhang_list").change(function () {
    //    LayDanhSachLoTrinhTheoMaKH();
    //    getThongTinKhachhang();
    //    AnHienFormKhachHang();
    //});


    $("#add-moi").click(function () {
        ThemChonLoaiXeMoi();
    });

    $("#NgayDiMoi").change(function () {
        TinhNgayMoi();
    });

    $("#NgayVeMoi").change(function () {
        TinhNgayMoi();
    });

    $("#GioDonMoi").change(function () {
        TinhNgayMoi();
    });

    $("#GioUocTinh").change(function () {
        TinhNgayMoi();
        var iNgayLech = $('#GioUocTinh').val();
        $('input[name="ThoiGianMoiDisplay"]').val(iNgayLech);
    });

    $("input[name='TenLoTrinhMoi']").change(function () {
        var x = $(this).text();
        $("#TenLoTrinhMoi").text(x);
    });
    function getBangGiaMoi() {
        var obj = {
            strLoaiXeMoi: $('#strLoaiXeMoi').val(),
            StrSoLuongXeMoi: $('#StrSoLuongXeMoi').val(),
            strGiaXeMoi: $('#StrGiaXeMoi').val(),
            ThoiGianMoi: $('#ThoiGianMoi').val(),
            strMaChiPhiMoi: $('#strMaChiPhiMoi').val(),
            strSoLuongCPMoi: $('#strSoLuongCPMoi').val(),
            GiamGiaMoi: $('#GiamGiaMoi').val(),
        };
        $.ajax({
            url: "/HopDong/TuyenDuongMoi",
            type: "get",
            data: obj,
            success: function (result) {
                var data = result.data;
                if (!$.isEmptyObject(data)) {
                    $('input[name="TongTienMoi"]').val(formatNumber(data.TongTienMoi, ',', '.'));
                    //$('input[name="ThoiGianMoiDisplay"]').val(data.GioUocTinh);
                    $('input[name="GiaNiemYetMoi"]').val(formatNumber(data.GiaNiemYetMoi, ',', '.'));
                }
            }
        });
    }

    function LayGiaXeMoi() {
        var tien = [];
        $(".GiaXeMoi").each(function () {
            tien.push($(this).val());
        });
        var t = "";
        for (i = 0; i < tien.length; i++) {
            if (i > 0) {
                t += ",";
            }
            t += tien[i];
        }
        $('#StrGiaXeMoi').val(t);
    }
    function LaySoLuongXeMoi() {
        var soluong = [];
        $(".SoLuongMoi").each(function () {
            soluong.push($(this).val());
        });
        var sl = "";
        for (i = 0; i < soluong.length; i++) {
            if (i > 0) {
                sl += ",";
            }
            sl += soluong[i];
        }
        $('#StrSoLuongXeMoi').val(sl);
    }
    function LayListMaLoaiXeMoi() {
        var selected = [];
        $(".MaLoaiXeMoi option:selected").each(function () {
            selected.push($(this).val());
        });
        var LoaiXe = "";
        for (i = 0; i < selected.length; i++) {
            if (i > 0) {
                LoaiXe += ",";
            }
            LoaiXe += selected[i];
        }
        $('#strLoaiXeMoi').val(LoaiXe);
    }
    //function getThongTinKhachhang() {
    //    var makh = $("#khachhang_list").val();
    //    $.ajax({
    //        url: "/KhachHang/GetThongTinKH?maKhachHang=" + makh,
    //        type: "get",
    //        success: function (data) {
    //            if (data.data) {
    //                $('#KhachHang-ThanThiet').find('input[name="TenKH"]').val(data.data.TenKH);
    //                $('#KhachHang-ThanThiet').find('input[name="SDT"]').val(data.data.SDT);
    //                $('#KhachHang-ThanThiet').find('input[name="Email"]').val(data.data.Email);
    //                $('#KhachHang-ThanThiet').find('input[name="DiaChiKH"]').val(data.data.DiaChiKH);
    //            }
    //        }
    //    });
    //}

    //function LayDanhSachLoTrinhTheoMaKH() {
    //    var makh = $("#khachhang_list").val();
    //    $.ajax({
    //        url: "/HopDong/LayDanhSachLoTrinhTheoMaKH?maKhachHang=" + makh,
    //        type: "get",
    //        success: function (result) {
    //            if (result != null || result != "") {
    //                var html = "";
    //                html += '<option></option>';
    //                html += '<optgroup label="">';
    //                html += '<option value="">Select...</option>';
    //                $.each(result, function (key, item) {
    //                    html += '<option value=' + item.MaLoTrinh + '>' + item.TenLoTrinh + '</option>';
    //                });
    //                html += '</optgroup>';
    //                $('#country_list').html(html);
    //            }
    //        }
    //    })
    //}
    var i = 0;
    //-------------------------Thêm Loại xe và số lượng---------------------------------
    function ThemChonLoaiXeMoi() {
        $.ajax({
            url: "/HopDong/LayDanhSachLoaiXe",
            type: "get",
            success: function (result) {
                var html = "";
                html += '<div class="row add-moi' + i + '">';
                html += '<div class="col-md-12">';
                html += ' <div class="form-group col-md-6">';
                html += '<label class="control-label col-md-4">';
                html += 'Loại xe';
                html += '<span class="required" aria-required="true"> * </span>';
                html += '</label>';
                html += '<div class="col-md-8">';
                html += '<select name="MaLoaiXeMoi" class="MaLoaiXeMoi bs-select form-control bs-select-hidde" tabindex="-1" aria-hidden="true">';
                html += '<optgroup label="">';
                $.each(result.loaiXe, function (key, item) {
                    html += '<option value=' + item.MaLoaiXe + '>' + item.TenLoaiXe + '</option>';
                });
                html += '</optgroup>';
                html += '</select>';
                html += '</div>';
                html += '</div>';
                html += ' <div class="form-group col-md-6">';
                html += '<label class="control-label col-md-2">';
                html += 'Số lượng';
                html += '<span class="required" aria-required="true"> * </span>';
                html += '</label>';
                html += '<div class="col-md-2">';
                html += '<input type="text" class="form-control SoLuongMoi" name="SLuong' + i + '" value="1">';
                html += '</div>';
                html += '<label class="control-label col-md-2">';
                html += 'Giá';
                html += '<span class="required" aria-required="true"> * </span>';
                html += '</label>';
                html += '<div class="col-md-4">';
                html += '<input type="text" class="form-control GiaXeMoi" name="GiaXeMoi" value="0" tabindex="-1">';
                html += '</div>';
                html += '<div class="col-md-2">';
                html += '<button type="button" class="btn grey-mint delete-addmoi" id="add-moi' + i + '" >Xóa</button>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                $('#add-routingmoi').append(html);
                i++;
                $("#GiamGia,.SoLuongCP,.GiaXeMoi,#GiamGiaMoi,.SoLuongCPMoi")
               .off('keyup').on('keyup', function (e) {
                   var x = $(this).val();
                   if (x) {
                       x = x.replace(".", "").replace(".", "").replace(".", "").replace(".", "").replace(".", "");
                       //x = x.replace(".", "");
                       //x = x.replace(".", "");
                       x = parseFloat(x);
                       $(this).val(formatNumber(x.toString(), ',', '.'));
                   }
               });

                $(".delete-addmoi").on('click', function () {
                    //var x = $(this).attr('id');
                    //$('div.' + x + '').remove();
                    $('div#add-routingmoi').children("div").remove();
                    LayGiaXeMoi();
                    LaySoLuongXeMoi();
                    LayListMaLoaiXeMoi();
                    getBangGiaMoi();
                });
                $(".MaLoaiXeMoi").change(function () {
                    LayGiaXeMoi();
                    LaySoLuongXeMoi();
                    LayListMaLoaiXeMoi();
                    getBangGiaMoi();
                });
                $(".SoLuongMoi").change(function () {
                    LayGiaXeMoi();
                    LaySoLuongXeMoi();
                    LayListMaLoaiXeMoi();
                    getBangGiaMoi();
                });
                $(".GiaXeMoi").change(function () {
                    LayGiaXeMoi();
                    LaySoLuongXeMoi();
                    LayListMaLoaiXeMoi();
                    getBangGiaMoi();
                });
                var ComponentsBootstrapSelect = function () {
                    var n = function () {
                        $(".bs-select").selectpicker({
                            iconBase: "fa", tickIcon: "fa-check"
                        })
                    }; return { init: function () { n() } }
                }(); App.isAngularJsApp() === !1 && jQuery(document).ready(function () {
                    ComponentsBootstrapSelect.init()
                });
                LayGiaXeMoi();
                LaySoLuongXeMoi();
                LayListMaLoaiXeMoi();
                getBangGiaMoi();
            }
        })
    }
    //-------------------------End Thêm Loại xe và số lượng---------------------------------

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
    }

    function TinhNgayMoi() {
        var strNgayDi = $("#NgayDiMoi").val() + ' ' + $("#GioDonMoi").val();
        var NgayDiMoi = moment(strNgayDi, 'D/M/YYYY HH:mm');
        var iNgayLech = $('#GioUocTinh').val();
        var NgayVeMoi = moment(NgayDiMoi).add(parseInt(iNgayLech, "10"), 'hours').format("D/M/YYYY HH:mm");
        if (NgayVeMoi.toString() != "Invalid date" || ($("#NgayDiMoi").val() != "" && $("#NgayVeMoi"))) {
            $("input[name='NgayVeMoi']").val(NgayVeMoi);
        }
        //var nd = moment($("#NgayDiMoi").val(), 'D/M/YYYY');
        //var nv = moment($("#NgayVeMoi").val(), 'D/M/YYYY');
        //var x = nv.diff(nd, 'days');
        //if (x) {
        //    $('input[name="ThoiGianMoiDisplay"]').val(x + ' Ngày');
        //    $("#ThoiGianMoi").val(x);
        //}
        //else {
        //    $('input[name="ThoiGianMoiDisplay"]').val(1 + ' Ngày');
        //    $("#ThoiGianMoi").val(1);
        //}
    }

    //---------------------------CHI PHÍ PHÁT SINH------------------------//
    $("#add-CPMoi").click(function () {
        ThemChonCPPSMoi();
    })
    $(".ChiPhiListMoi").change(function () {

        var x = $(this).data('cpmoi');
        var gia = $('option:selected', this).data('gia');
        $('#cpmoi-' + x).val(formatNumber(gia, ',', '.'));

        LaySoLuongXeCPMoi();
        LayMaChiPhiMoi();
        getBangGiaMoi();
    });
    $(".SoLuongCPMoi").change(function () {

        var x = $(this).data('cpmoi');
        var gia = $('option:selected', this).data('gia');
        $('#cpmoi-' + x).val(formatNumber(gia, ',', '.'));

        LaySoLuongXeCPMoi();
        LayMaChiPhiMoi();
        getBangGiaMoi();
    });
    var i = 1;
    function ThemChonCPPSMoi() {
        $.ajax({
            url: "/HopDong/LayDanhSachCPPS",
            type: "get",
            success: function (result) {
                var html = "";
                html += '<div class="form-group addCPMoi-' + i + '">';
                html += '<label class="control-label col-md-2">';
                html += 'Loại chi phí';
                html += '<span class="required" aria-required="true"> * </span>';
                html += '</label>';
                html += '<div class="col-md-4">';
                html += '<select name="MaChiPhiMoi" class="ChiPhiListMoi bs-select form-control bs-select-hidde" tabindex="-1" aria-hidden="true" data-cpmoi="' + i + '">';
                html += '<optgroup label="">';
                html += '<option>Chọn phí phát sinh</option>'
                $.each(result, function (key, item) {
                    html += '<option value=' + item.MaChiPhi + ' data-gia=' + item.PhiPhatSinh + '>' + item.TenChiPhi + '</option>';
                });
                html += '</optgroup>';
                html += '</select>';
                html += '</div>';
                html += '<label class="control-label col-md-1">';
                html += 'Chi phí';
                html += '<span class="required" aria-required="true"> * </span>';
                html += '</label>';
                html += '<div class="col-md-2">';
                html += '<input type="text" class="form-control SoLuongCPMoi" name="SLuong" value="" id="cpmoi-' + i + '">';
                html += '</div>';
                html += '<div class="col-md-2">';
                html += '<button type="button" class="btn grey-mint delete-addCPPSMoi" id="addCPMoi-' + i + '" >Xóa</button>';
                html += '</div>';
                html += '</div>';
                $('#add-CPPSMoi').append(html);
                i++;

                $("#GiamGia,.SoLuongCP,.GiaXeMoi,#GiamGiaMoi,.SoLuongCPMoi")
               .off('keyup').on('keyup', function (e) {
                   var x = $(this).val();
                   if (x) {
                       x = x.replace(".", "").replace(".", "").replace(".", "").replace(".", "").replace(".", "");
                       //x = x.replace(".", "");
                       //x = x.replace(".", "");
                       x = parseFloat(x);
                       $(this).val(formatNumber(x.toString(), ',', '.'));
                   }
               });
                $(".delete-addCPPSMoi").on('click', function () {
                    var x = $(this).attr('id');
                    $('div.' + x + '').remove();
                    //$('div#add-CPPSMoi').children("div").remove();
                    LaySoLuongXeCPMoi();
                    LayMaChiPhiMoi();
                    getBangGiaMoi(x);
                });
                $(".ChiPhiListMoi").change(function () {

                    var x = $(this).data('cpmoi');
                    var gia = $('option:selected', this).data('gia');
                    $('#cpmoi-' + x).val(formatNumber(gia, ',', '.'));

                    LaySoLuongXeCPMoi();
                    LayMaChiPhiMoi();
                    getBangGiaMoi();
                });
                $(".SoLuongCPMoi").change(function () {

                    var x = $(this).data('cpmoi');
                    var gia = $('option:selected', this).data('gia');
                    $('#cpmoi-' + x).val(formatNumber(gia, ',', '.'));

                    LaySoLuongXeCPMoi();
                    LayMaChiPhiMoi();
                    getBangGiaMoi();
                });
                var ComponentsBootstrapSelect = function () {
                    var n = function () {
                        $(".bs-select").selectpicker({
                            iconBase: "fa", tickIcon: "fa-check"
                        })
                    }; return { init: function () { n() } }
                }(); App.isAngularJsApp() === !1 && jQuery(document).ready(function () {
                    ComponentsBootstrapSelect.init()
                });
                LaySoLuongXeCPMoi();
                LayMaChiPhiMoi();
                getBangGiaMoi();
            }
        })
    }

    function LaySoLuongXeCPMoi() {
        var soluong = [];
        $(".SoLuongCPMoi").each(function () {
            soluong.push($(this).val());
        });
        var sl = "";
        for (i = 0; i < soluong.length; i++) {
            if (i > 0) {
                sl += ",";
            }
            sl += soluong[i];
        }
        $('#strSoLuongCPMoi').val(sl);
    }

    function LayMaChiPhiMoi() {
        var selected = [];
        $(".ChiPhiListMoi option:selected").each(function () {
            selected.push($(this).val());
        });
        var ChiPhi = "";
        for (i = 0; i < selected.length; i++) {
            if (i > 0) {
                ChiPhi += ",";
            }
            ChiPhi += selected[i];
        }
        $('#strMaChiPhiMoi').val(ChiPhi);
    }
});