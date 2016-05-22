$(function () {
    $(window).scroll(function () {
        if ($(window).scrollTop() > 300) {
            $("#cncdata-side-bar").addClass("cncdata-side-bar-fixed");
        }
        else {
            $("#cncdata-side-bar").removeClass("cncdata-side-bar-fixed");
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
});