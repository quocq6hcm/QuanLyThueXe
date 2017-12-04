$(document).ready(function () {
    _getAll();
});

function _getAll() {
    $.ajax({
        url: "/Home/LayDanhThoiGian",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

        }
    });
}