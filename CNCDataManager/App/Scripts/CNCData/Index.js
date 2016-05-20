
$(function () {
    var clickhandler = function (object) {
        headid = $(object).attr("id");
        idnum = headid.substring(12, 13);
        bodyid = "#dsec-body-" + idnum;
        alert(bodyid);
        $(object).toggleClass("desc-header-open");
        $("#dsec-body-" + idnum).animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    };
    //伺服电机部分
    $("#desc-header-1").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-1").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //伺服驱动器部分
    $("#desc-header-2").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-2").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //数控系统
    $("#desc-header-3").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-3").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //滚动轴承
    $("#desc-header-4").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-4").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //联轴器
    $("#desc-header-5").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-5").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //导轨
    $("#desc-header-6").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-6").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //滚珠丝杠螺母副
    $("#desc-header-7").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-7").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //回转工作台
    $("#desc-header-8").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-8").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //齿轮
    $("#desc-header-9").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-9").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //涡轮蜗杆
    $("#desc-header-10").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-10").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    //带传动
    $("#desc-header-11").click(function () {
        $(this).toggleClass("desc-header-open");
        $("#desc-body-11").animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    });
    
    //侧边导航
    $("#nav-icon-motor")
});