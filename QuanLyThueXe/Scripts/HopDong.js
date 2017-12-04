$(document).ready(function () {
    getThongTinKhachhang();
    LayDanhSachLoTrinhTheoMaKH();
    LayDanhSachLoaiXeMaKHVaMaLT();
    AnHienFormKhachHang();
    LaySoLuongXeCP();
    LayMaChiPhi();

    //SetMinDate()
    //{

    //}
    $("#country_list").change(function () {
        LayDanhSachLoaiXeMaKHVaMaLT();
        LayListMaLoaiXe();
        LaySoLuongXe();
        $('div#add-routing').children("div").remove();
    });
    $(".Loaixe_list").change(function () {
        LaySoLuongXe();
        LayListMaLoaiXe();
        getBangGia();
    });

    $("#GiamGia").change(function () {
        getBangGia();
    });

    $("#khachhang_list").change(function () {
        LayDanhSachLoTrinhTheoMaKH();
        getThongTinKhachhang();
        AnHienFormKhachHang();
    });

    $(".SoLuong").change(function () {
        LaySoLuongXe();
        LayListMaLoaiXe();
        getBangGia();
    });
    $("#add").click(function () {
        var x = $('#country_list').val();
        if (x.length == "" || x == null) {
            $('#country_list').css({ "border": "solid 1px red" });
        }
        else {
            ThemChonLoaiXe();
        }
    });
    $("#NgayDi").change(function () {
        TinhNgay();
    });

    $("#NgayVe").change(function () {
        TinhNgay();
    });

    $("#GioDon").change(function () {
        TinhNgay();
    });

    $('.button-next').click(function () {
        LayListTenLoaiXe();
    });
    $('.button-next').click(function () {
        LayListTenLoaiXeMoi();
    });

    $("#tab-home").click(function () {
        $("#menu1").hide();
        $("#home").show();
        $("#TuyenDuongMoi").hide();
        $("#TuyenDuongMacDinh").show();
        //$("#btnTuyenDuongMoi").hide();
        //$("#btnTuyenDuongMacDinh").show();
    });
    $("#tab-menu1").click(function () {
        $("#home").hide();
        $("#menu1").show();
        $("#TuyenDuongMoi").show();
        $("#TuyenDuongMacDinh").hide();
        //$("#btnTuyenDuongMacDinh").hide();
        //$("#btnTuyenDuongMoi").show();
    });
    //$(".delete-add").on('click', function () {
    //    //var x = $(this).attr('id');
    //    //$('div.' + x + '').remove();
    //    LaySoLuongXe();
    //    LayListMaLoaiXe();
    //    getBangGia();
    //    $('div#add-routing').children("div").remove();
    //})

    function getBangGia() {
        var maKhachHang = $('#khachhang_list').val();
        var maLotrinh = $('#country_list').val();
        var maLoaiXe = $('#LoaiXe').val();
        var giamGia = $('#GiamGia').val();
        var soluong = $('#SoLuong').val() == null ? 0 : $('#SoLuong').val();
        var iNgayLech = $('#country_list option:selected').data('thoigiantuyendi');
        var strMaChiPhi = $('#ChiPhi').val();
        var strSoLuongCP = $('#SoLuongCP').val();
        $.ajax({
            url: "/HopDong/GetBangGia?maLoTrinh=" + maLotrinh + "&maLoaiXe=" + maLoaiXe + "&soluong=" + soluong + "&maKhachHang=" + maKhachHang + "&giamGia=" + giamGia + "&strMaChiPhi=" + strMaChiPhi + "&strSoLuongCP=" + strSoLuongCP + "&iNgayLech=" + iNgayLech,
            type: "get",
            success: function (data) {
                if (!$.isEmptyObject(data.data)) {
                    $('#BangGia').show();
                    $('#BangGia').find('input[name="ThoiGian"]').val(data.data.ThoiGian);
                    if (data.data.SoKM) {
                        $('#BangGia').find('input[name="SoKM"]').val(data.data.SoKM + ' KM');
                    }
                    else {
                        $('#BangGia').find('input[name="SoKM"]').val('Chưa cập nhật');
                    }
                    $('#BangGia').find('input[name="SoTienConLai"]').val(formatNumber(data.data.Gia, ',', '.'));
                    $('#BangGia').find('input[name="GiaNiemYet"]').val(formatNumber(data.niemyet.Gia, ',', '.'));
                    console.log("Done!");
                }
                else {
                    console.log("false!");
                    $('#BangGia').hide();
                }
            }
        });
    }

    function LaySoLuongXe() {
        var soluong = [];
        $(".SoLuong").each(function () {
            soluong.push($(this).val());
        });
        var sl = "";
        for (i = 0; i < soluong.length; i++) {
            if (i > 0) {
                sl += ",";
            }
            sl += soluong[i];
        }
        $('#SoLuong').val(sl);
    }
    function LayListMaLoaiXe() {
        var selected = [];
        $(".Loaixe_list option:selected").each(function () {
            selected.push($(this).val());
        });
        var LoaiXe = "";
        for (i = 0; i < selected.length; i++) {
            if (i > 0) {
                LoaiXe += ",";
            }
            LoaiXe += selected[i];
        }
        $('#LoaiXe').val(LoaiXe);
    }
    function LayListTenLoaiXe() {
        var tenloaixe = [];
        $(".Loaixe_list option:selected").each(function () {
            tenloaixe.push($(this).text());
        });
        var soluongxe = [];
        $(".SoLuong").each(function () {
            soluongxe.push($(this).val());
        });

        var html = '';
        for (i = 0; i < tenloaixe.length; i++) {
            if (i > 0) {
                html += '</br>';
            }
            html += '<p class="form-control-static">' + tenloaixe[i] + '(' + soluongxe[i] + ' chiếc)</p>';
        }
        $('.loaiXeDisplay').html(html);
    }
    function LayListTenLoaiXeMoi() {
        var tenloaixe = [];
        $(".MaLoaiXeMoi option:selected").each(function () {
            tenloaixe.push($(this).text());
        });
        var soluongxe = [];
        $(".SoLuongMoi").each(function () {
            soluongxe.push($(this).val());
        });

        var html = '';
        for (i = 0; i < tenloaixe.length; i++) {
            if (i > 0) {
                html += '</br>';
            }
            html += '<p class="form-control-static">' + tenloaixe[i] + '(' + soluongxe[i] + ' chiếc)</p>';
        }
        $('.loaiXeMoiDisplay').html(html);
    }
    function getThongTinKhachhang() {
        var makh = $("#khachhang_list").val();
        $.ajax({
            url: "/KhachHang/GetThongTinKH?maKhachHang=" + makh,
            type: "get",
            success: function (data) {
                if (data.data) {
                    $('#KhachHang-ThanThiet').find('input[name="TenKH"]').val(data.data.TenKH);
                    $('#KhachHang-ThanThiet').find('input[name="SDT"]').val(data.data.SDT);
                    $('#KhachHang-ThanThiet').find('input[name="Email"]').val(data.data.Email);
                    $('#KhachHang-ThanThiet').find('input[name="DiaChiKH"]').val(data.data.DiaChiKH);
                }
            }
        });
    }

    function LayDanhSachLoTrinhTheoMaKH() {
        var makh = $("#khachhang_list").val();
        $.ajax({
            url: "/HopDong/LayDanhSachLoTrinhTheoMaKhachHangTrongBangGia?maKhachHang=" + makh,
            type: "get",
            success: function (result) {
                if (result != null || result != "") {
                    var html = "";
                    html += '<select id="country_list" name="MaLoTrinh" class="form-control select2 select2-hidden-accessible" tabindex="-1" aria-hidden="true">'
                    html += '<option></option>';
                    html += '<option value="">Select...</option>';
                    $.each(result, function (key, item) {
                        html += '<option data-thoigiantuyendi=' + item.ThoiGian + ' value=' + item.LoTrinhs.MaLoTrinh + '>' + item.LoTrinhs.TenLoTrinh + ' ( ' + item.ThoiGian + ' giờ )' + '</option>';
                    });
                    html += '</select>';
                    $('#dropKhachHang').html(html);
                    App.isAngularJsApp() === !1 && jQuery(document).ready(function () {
                        ComponentsSelect2.init()
                    });
                    $("#country_list").change(function () {
                        LayDanhSachLoaiXeMaKHVaMaLT();
                        LayListMaLoaiXe();
                        LaySoLuongXe();
                        TinhNgay();
                        $('#BangGia').hide();
                        $('div#add-routing').children("div").remove();
                    });
                }
            }
        });
    }
    var i = 0;
    //-------------------------Thêm Loại xe và số lượng---------------------------------
    function ThemChonLoaiXe() {
        var maKhachHang = $('#khachhang_list').val();
        var maLotrinh = $('#country_list').val();
        $.ajax({
            url: "/HopDong/LayDanhSachLoaiXeMaKHVaMaLT?maKhachHang=" + maKhachHang + "&maLotrinh=" + maLotrinh,
            type: "get",
            success: function (result) {
                var html = "";
                html += '<div class="form-group add-' + i + '">';
                html += '<label class="control-label col-md-2">';
                html += 'Loại xe';
                html += '<span class="required" aria-required="true"> * </span>';
                html += '</label>';
                html += '<div class="col-md-4">';
                html += '<select name="MaLoaiXe' + i + '" class="Loaixe_list bs-select form-control bs-select-hidde isEmpty" data-name="Loại xe" tabindex="-1" aria-hidden="true">';
                html += '<optgroup label="">';
                html += '<option></option>';
                $.each(result, function (key, item) {
                    html += '<option value=' + item.LoaiXes.MaLoaiXe + '>' + item.LoaiXes.TenLoaiXe + '</option>';
                });
                html += '</optgroup>';
                html += '</select>';
                html += '</div>';
                html += '<label class="control-label col-md-2">';
                html += 'Số lượng xe';
                html += '<span class="required" aria-required="true"> * </span>';
                html += '</label>';
                html += '<div class="col-md-2">';
                html += '<input type="number" min="1" class="form-control SoLuong" name="SLuong' + i + '" value="1">';
                html += '</div>';
                html += '<div class="col-md-2">';
                html += '<button type="button" class="btn grey-mint delete-add" id="add-' + i + '" >Xóa</button>';
                html += '</div>';
                html += '</div>';
                $('#add-routing').append(html);
                i++;
                $(".delete-add").on('click', function () {
                    //var x = $(this).attr('id');
                    //$('div.' + x + '').remove();
                    $('div#add-routing').children("div").remove();
                    LaySoLuongXe();
                    LayListMaLoaiXe();
                    getBangGia();
                });
                $(".Loaixe_list").change(function () {
                    LaySoLuongXe();
                    LayListMaLoaiXe();
                    LayListTenLoaiXe();
                    getBangGia();
                });
                $(".SoLuong").change(function () {
                    LaySoLuongXe();
                    LayListMaLoaiXe();
                    getBangGia();
                });
                App.isAngularJsApp() === !1 && jQuery(document).ready(function () {
                    ComponentsBootstrapSelect.init()
                });
                LayListTenLoaiXe();
                LaySoLuongXe();
                LayListMaLoaiXe();
                getBangGia();
            }
        })
    }
    function LayDanhSachLoaiXeMaKHVaMaLT() {
        var maKhachHang = $('#khachhang_list').val();
        var maLotrinh = $('#country_list').val();
        $.ajax({
            url: "/HopDong/LayDanhSachLoaiXeMaKHVaMaLT?maKhachHang=" + maKhachHang + "&maLotrinh=" + maLotrinh,
            type: "get",
            success: function (result) {
                var html = "";
                html += "<select name='MaLoaiXe' class='Loaixe_list bs-select form-control bs-select-hidde' tabindex='-1' aria-hidden='true'>";
                html += '<option></option>';
                $.each(result, function (key, item) {
                    html += '<option value=' + item.LoaiXes.MaLoaiXe + '>' + item.LoaiXes.TenLoaiXe + '</option>';
                });
                html += "</select>";
                $('#DropLoaiXe').html(html);
                var ComponentsBootstrapSelect = function () {
                    var n = function () {
                        $(".bs-select").selectpicker({
                            iconBase: "fa", tickIcon: "fa-check"
                        })
                    }; return { init: function () { n() } }
                }(); App.isAngularJsApp() === !1 && jQuery(document).ready(function () {
                    ComponentsBootstrapSelect.init()
                });
                //jQuery(document).ready(function () { FormWizard.init() });
                $(".Loaixe_list").change(function () {
                    LayListTenLoaiXe();
                    LaySoLuongXe();
                    LayListMaLoaiXe();
                    getBangGia();
                });
            }
        })
    }
    function AnHienFormKhachHang() {
        var maKhachHang = $('#khachhang_list').val();
        if (maKhachHang == 'Detra') {
            $('#Info-KhachHang').show();
            $('#detail-khachhang').show();
        }
        else {
            $('#Info-KhachHang').hide();
            $('#detail-khachhang').hide();
        }
    }

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

    function TinhNgay() {
        var strNgayDi = $("#NgayDi").val() + ' ' + $("#GioDon").val();
        var NgayDi = moment(strNgayDi, 'D/M/YYYY HH:mm');
        var iNgayLech = $('#country_list option:selected').data('thoigiantuyendi');
        var NgayVe = moment(NgayDi).add(parseInt(iNgayLech, "10"), 'hours').format("D/M/YYYY HH:mm");
        if (NgayVe.toString() != "Invalid date") {
            $("input[name='NgayVe']").val(NgayVe);
        }
        //var x = nv.diff(nd, 'days');
        //if (x) {
        //    $('#BangGia').find('input[name="ThoiGian"]').val(x + ' Ngày');
        //    $("#iNgayLech").val(x);
        //} else {
        //    $('#BangGia').find('input[name="ThoiGian"]').val(1 + ' Ngày');
        //    $("#iNgayLech").val(1);
        //}
    }

    //---------------------------CHI PHÍ PHÁT SINH------------------------//
    $("#add-CP").click(function () {
        ThemChonCPPS();
    })
    $(".ChiPhiList").change(function () {
        var x = $(this).data('cp');
        var gia = $('option:selected', this).data('gia');
        $('#cp-' + x).val(formatNumber(gia, ',', '.'));
        LaySoLuongXeCP();
        LayMaChiPhi();
        getBangGia();
    });
    $(".SoLuongCP").change(function () {
        var x = $(this).data('cp');
        var gia = $('option:selected', this).data('gia');
        $('#cp-' + x).val(formatNumber(gia, ',', '.'));
        LaySoLuongXeCP();
        LayMaChiPhi();
        getBangGia();
    });
    var i = 1;
    function ThemChonCPPS() {
        $.ajax({
            url: "/HopDong/LayDanhSachCPPS",
            type: "get",
            success: function (result) {
                var html = "";
                html += '<div class="form-group add-' + i + '">';
                html += '<label class="control-label col-md-2">';
                html += 'Loại chi phí';
                html += '<span class="required" aria-required="true"> * </span>';
                html += '</label>';
                html += '<div class="col-md-4">';
                html += '<select name="MaChiPhi" class="ChiPhiList bs-select form-control bs-select-hidde" tabindex="-1" aria-hidden="true" data-cp=' + i + '>';
                html += '<optgroup label="">';
                html += '<option>Chọn phí phát sinh</option>';
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
                html += '<input type="text" class="form-control SoLuongCP" name="SLuong" value="" id="cp-' + i + '">';
                html += '</div>';
                html += '<div class="col-md-2">';
                html += '<button type="button" class="btn grey-mint delete-addCPPS" id="add-' + i + '" >Xóa</button>';
                html += '</div>';
                html += '</div>';
                $('#add-CPPS').append(html);
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


                $(".delete-addCPPS").on('click', function () {
                    var x = $(this).attr('id');
                    $('div.' + x + '').remove();
                    LaySoLuongXeCP();
                    LayMaChiPhi();
                    getBangGia();
                });
                $(".ChiPhiList").change(function () {

                    var x = $(this).data('cp');
                    var gia = $('option:selected', this).data('gia');
                    $('#cp-' + x).val(formatNumber(gia, ',', '.'));
                    LaySoLuongXeCP();
                    LayMaChiPhi();
                    getBangGia();
                });
                $(".SoLuongCP").change(function () {
                    var x = $(this).data('cp');
                    var gia = $('option:selected', this).data('gia');
                    $('#cp-' + x).val(formatNumber(gia, ',', '.'));
                    LaySoLuongXeCP();
                    LayMaChiPhi();
                    getBangGia();
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
                LaySoLuongXeCP();
                LayMaChiPhi();
                getBangGia();

            }
        })
    }

    function LaySoLuongXeCP() {
        var soluong = [];
        $(".SoLuongCP").each(function () {
            soluong.push($(this).val());
        });
        var sl = "";
        for (i = 0; i < soluong.length; i++) {
            if (i > 0) {
                sl += ",";
            }
            sl += soluong[i];
        }
        $('#SoLuongCP').val(sl);
    }

    function LayMaChiPhi() {
        var selected = [];
        $(".ChiPhiList option:selected").each(function () {
            selected.push($(this).val());
        });
        var ChiPhi = "";
        for (i = 0; i < selected.length; i++) {
            if (i > 0) {
                ChiPhi += ",";
            }
            ChiPhi += selected[i];
        }
        $('#ChiPhi').val(ChiPhi);
    }
});
