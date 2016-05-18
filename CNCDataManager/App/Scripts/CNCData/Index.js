
$(function () {
    $("#desc-header-1").click(function () {
        $(this).removeClass("desc-header").addClass("desc-header-open");
        $("#desc-body-1").animate({ height: 'toggle' }, 1000, function () {
            $(this).removeClass("desc-body").addClass("desc-body-open");
        });
    });
});