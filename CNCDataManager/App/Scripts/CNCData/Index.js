//CNCData/Index.js
$(function () {
    var toggleDescBody = function (head, body, icon) {
        head.toggleClass("desc-header-open");
        body.animate({ height: 'toggle' }, 500, function () {
            $(this).addClass("desc-body-open");
        });
        var classname = icon.attr("class").toString();
        if(classname.indexOf("glyphicon-menu-down") > 0)
        {
            setTimeout(function () {
                icon.removeClass('glyphicon-menu-down').addClass('glyphicon-menu-right');
            }, 500);
        }
        else
        {
            icon.removeClass('glyphicon-menu-right').addClass("glyphicon-menu-down");
        }
    };

    //伺服电机部分
    $("#desc-header-1").click(function () {
        toggleDescBody($(this), $("#desc-body-1"), $("#desc-header-1 >span"));
    });
    //伺服驱动器部分
    $("#desc-header-2").click(function () {
        toggleDescBody($(this), $("#desc-body-2"), $("#desc-header-2 >span"));
    });
    //数控系统
    $("#desc-header-3").click(function () {
        toggleDescBody($(this), $("#desc-body-3"), $("#desc-header-3 >span"));
    });
    //滚动轴承
    $("#desc-header-4").click(function () {
        toggleDescBody($(this), $("#desc-body-4"), $("#desc-header-4 >span"));
    });
    //联轴器
    $("#desc-header-5").click(function () {
        toggleDescBody($(this), $("#desc-body-5"), $("#desc-header-5 >span"));
    });
    //导轨
    $("#desc-header-6").click(function () {
        toggleDescBody($(this), $("#desc-body-6"), $("#desc-header-6 >span"));
    });
    //滚珠丝杠螺母副
    $("#desc-header-7").click(function () {
        toggleDescBody($(this), $("#desc-body-7"), $("#desc-header-7 >span"));
    });
    //回转工作台
    $("#desc-header-8").click(function () {
        toggleDescBody($(this), $("#desc-body-8"), $("#desc-header-8 >span"));
    });
    //齿轮
    $("#desc-header-9").click(function () {
        toggleDescBody($(this), $("#desc-body-9"), $("#desc-header-9 >span"));
    });
    //涡轮蜗杆
    $("#desc-header-10").click(function () {
        toggleDescBody($(this), $("#desc-body-10"), $("#desc-header-10 >span"));
    });
    //带传动
    $("#desc-header-11").click(function () {
        toggleDescBody($(this), $("#desc-body-11"), $("#desc-header-11 >span"));
    });
    
});