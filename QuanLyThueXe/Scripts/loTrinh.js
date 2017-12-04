$(document).ready(function () {
    //$(".chinhsua").click(function () {
    //    var x = $(this).attr("data-malt");
    //    $.ajax({
    //        url: "/LoTrinh/ChinhSuaLoTrinh?MaLT=" + x,
    //        type: "get",
    //        dataType: "html",
    //        success: function (data) {
    //            $("#DSLT").html(data);
    //        }
    //    })
    //});
    var giaTriText = "";
    $('.btnLuuLT').click(function () {
        var maLT = $(this).parents().siblings(".txtMaLoTrinh").html();
        var tenLT = $(this).parents().siblings(".txtTenLoTrinh").html();
        var data = {
            MaLoTrinh: maLT,
            TenLoTrinh: tenLT,
        }
        $.ajax({
            url: '/LoTrinh/ChinhSuaLoTrinhJson',
            type: "get",
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            data: data,
            success: function (data) {
            }
        });
        $(".txtTenLoTrinh").css({ "border": "solid 1px #e7ecf1" });
        $(".btnLuuLT").css({ "display": "none" });
    });

    $(".txtTenLoTrinh").click(function () {
        giaTriText = $(this).text();
        $(".txtTenLoTrinh").css({ "border": "solid 1px #e7ecf1" });
        $(".btnLuuLT").css({ "display": "none" });
        $(".btnHuyLT").css({ "display": "none" });
        $(".btnXoaLT").css({ "display": "inline-block" });
        $(this).css({ "border": "solid 1px red" });
        $(this).siblings().children().find(".btnLuuLT").css({ "display": "inline-block" });
        //$(this).siblings().children().find(".btnXoaLT").css({ "display": "none" });
        $(this).siblings().children().find(".btnHuyLT").css({ "display": "inline-block" });
    });

    $('.btnHuyLT').click(function () {
        $(".txtTenLoTrinh").css({ "border": "solid 1px #e7ecf1" });
        $(".btnLuuLT").css({ "display": "none" });
        $(".btnHuyLT").css({ "display": "none" });
        $(".btnXoaLT").css({ "display": "inline-block" });
        var MaLT = $(this).attr("data-maLT");
        $(this).parents().find("td." + MaLT).text(giaTriText);
    });

    $(".btnXoaLT").click(function () {
        var MaLT = $(this).attr("data-maLT");
        var cfm = confirm("Bạn muốn xóa lộ trình này?");
        if (cfm) {
            //$.ajax({
            //    url: '/LoTrinh/XoaLT?MaLT=' + MaLT,
            //    type: "get",
            //    success: function (data) {
            //        $("tr." + MaLT).fadeOut();
            //    }
            //});
            return true;
        }
        return false;
    });

    //$('#ThemLoTrinh').click(function () {

    //});

    function LoadLoTrinh() {
        $.ajax({
            url: '/LoTrinh/LoadLoTrinh',
            type: 'get',
            success: function (result) {
                var html = "";
                $.each(result, function (key, item) {
                    html += "<tr>";
                    html += "<td>" + item.STT + "</td>";
                    html += "<td class=\"txtMaLoTrinh\">" + item.MaLoTrinh + "</td>";
                    html += "<td contenteditable=\"true\" name=\"TenLoTrinh\" class=\"txtTenLoTrinh\">" + item.TenLoTrinh + "</td>";
                    html += "<td>";
                    if (item.MaKH == null) {
                        html += "<span></span>";
                    }
                    else {
                        html += "<span>" + item.KhachHangs.TenKH + "</span>";
                    }
                    html += "</td>";
                    html += "<td>";
                    html += "<span class=\"col-md-6\"><input type=\"submit\" value=\"Lưu\" class=\"btn btn-danger btnLuuLT\" style=\"display:none;\" /></span>";
                    html += "<span class=\"col-md-6\"><button class=\"btn btn-default btnXoaLT\" data-maLT='" + item.MaLoTrinh + "'>Xóa</button></span>";
                    html += "</td>";
                    html += "</tr>";
                    $("#listLoTrinh").html(html);
                });

                $('.btnLuuLT').click(function () {
                    var maLT = $(this).parents().siblings(".txtMaLoTrinh").html();
                    var tenLT = $(this).parents().siblings(".txtTenLoTrinh").html();
                    var data = {
                        MaLoTrinh: maLT,
                        TenLoTrinh: tenLT,
                    }
                    $.ajax({
                        url: '/LoTrinh/ChinhSuaLoTrinhJson',
                        type: "get",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        data: data,
                        success: function (data) {
                        }
                    });
                    $(".txtTenLoTrinh").css({ "border": "solid 1px #e7ecf1" });
                    $(".btnLuuLT").css({ "display": "none" });
                });

                $(".txtTenLoTrinh").click(function () {
                    $(".txtTenLoTrinh").css({ "border": "solid 1px #e7ecf1" });
                    $(".btnLuuLT").css({ "display": "none" });
                    $(this).css({ "border": "solid 1px red" });
                    $(this).siblings().children().find(".btnLuuLT").css({ "display": "inline-block" });
                });

                $(".btnXoaLT").click(function () {
                    var MaLT = $(this).attr("data-maLT");
                    $.ajax({
                        url: '/LoTrinh/XoaLT?MaLT=' + MaLT,
                        type: "get",
                        success: function (data) {
                        }
                    });
                });
            }
        });
    }
});