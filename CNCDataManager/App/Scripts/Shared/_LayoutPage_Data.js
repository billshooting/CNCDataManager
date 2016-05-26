$(function () {
    //侧边导航固定
    $(window).scroll(function () {
        if ($(window).scrollTop() > 280) {
            $("#cncdata-side-bar").addClass("cncdata-side-bar-fixed");
            var clientWidth = $(window).width();
            if(clientWidth >= 1200)
            {
                var left = ($(window).innerWidth() - 1170) / 2 + 1170 * 5 / 6 + 15;
                $("#cncdata-side-bar").css({ left: left + "px" });
            }
            else if(clientWidth >= 992 && clientWidth < 1200)
            {
                var left = ($(window).innerWidth() - 970) / 2 + 970 * 5 / 6 + 15;
                $("#cncdata-side-bar").css({ left: left + "px" });
            }
            else if(clientWidth >= 768 && clientWidth < 992)
            {
                var left = ($(window).innerWidth() - 750) / 2 + 750 * 5 / 6 + 15;
                $("#cncdata-side-bar").css({ left: left + "px" });
            }
            else {
                $("#cncdata-side-bar").css({ left: "auto", right: "0" });
            }
        }
        else {
            $("#cncdata-side-bar").removeClass("cncdata-side-bar-fixed")
                                  .css({ left: "auto" });
        }
    });

    var toggleNavBar = function (icon, body) {
        var classname = icon.attr("class").toString();
        if (classname.indexOf("plus") > 0) {
            icon.removeClass("glyphicon-plus").addClass("glyphicon-minus");
        }
        else {
            icon.removeClass("glyphicon-minus").addClass("glyphicon-plus");
        }
        body.animate({ height: 'toggle' }, 300, function () {
            $(this).addClass("side-nav-head-2");
        });
    };

    var toggleSecondNavBar = function (icon, body) {
        var classname = icon.attr("class").toString();
        if (classname.indexOf("plus") > 0) {
            icon.removeClass("glyphicon-plus").addClass("glyphicon-minus");
        }
        else {
            icon.removeClass("glyphicon-minus").addClass("glyphicon-plus");
        }
        body.animate({ height: 'toggle' }, 300, function () {
            $(this).addClass("side-nav-head-3");
        });
    };

    //侧边导航
    //电机部分
    $("#nav-icon-motor").click(function () {
        toggleNavBar($(this), $("#nav-motor-ul"));
    });
    //驱动部分
    $("#nav-icon-driver").click(function () {
        toggleNavBar($(this), $("#nav-driver-ul"));
    });
    //数控系统部分
    $("#nav-icon-system").click(function () {
        toggleNavBar($(this), $("#nav-system-ul"));
    });
    //机械部件部分
    $("#nav-icon-mech").click(function () {
        toggleNavBar($(this), $("#nav-mech-ul"));
    });

    $("#nav-icon-mech-coupling").click(function () {
        toggleSecondNavBar($(this), $("#nav-mech-coupling-ul"));
    });

    $("#nav-icon-mech-bearing").click(function () {
        toggleSecondNavBar($(this), $("#nav-mech-bearing-ul"));
    });

    $("#nav-icon-mech-guide").click(function () {
        toggleSecondNavBar($(this), $("#nav-mech-guide-ul"));
    });

    $("#nav-icon-mech-screw").click(function () {
        toggleSecondNavBar($(this), $("#nav-mech-screw-ul"));
    });

    $("#nav-icon-mech-table").click(function () {
        toggleSecondNavBar($(this), $("#nav-mech-table-ul"));
    });

    $("#nav-icon-mech-gear").click(function () {
        toggleSecondNavBar($(this), $("#nav-mech-gear-ul"));
    });

    $("#nav-icon-mech-worm").click(function () {
        toggleSecondNavBar($(this), $("#nav-mech-worm-ul"));
    });

    $("#nav-icon-mech-belt").click(function () {
        toggleSecondNavBar($(this), $("#nav-mech-belt-ul"));
    });

    //关闭加载动画
    $(".overlay-container").css({ display: 'none' });
    //关闭提示页
    $(".overlay-container >span").click(function () {
        $(".overlay-container").css({ display: 'none' });
    });
});