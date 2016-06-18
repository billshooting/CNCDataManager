
$(function () {
    var toggleDescBody = function (head, body) {
        head.toggleClass("desc-header-open");
        body.animate({ height: 'toggle' }, 600, function () {
            $(this).addClass("desc-body-open");
        });
    };

    //伺服电机部分
    $("#desc-header-1").click(function () {
        toggleDescBody($(this), $("#desc-body-1"));
    });
    //伺服驱动器部分
    $("#desc-header-2").click(function () {
        toggleDescBody($(this), $("#desc-body-2"));
    });
    //数控系统
    $("#desc-header-3").click(function () {
        toggleDescBody($(this), $("#desc-body-3"));
    });
    //滚动轴承
    $("#desc-header-4").click(function () {
        toggleDescBody($(this), $("#desc-body-4"));
    });
    //联轴器
    $("#desc-header-5").click(function () {
        toggleDescBody($(this), $("#desc-body-5"));
    });
    //导轨
    $("#desc-header-6").click(function () {
        toggleDescBody($(this), $("#desc-body-6"));
    });
    //滚珠丝杠螺母副
    $("#desc-header-7").click(function () {
        toggleDescBody($(this), $("#desc-body-7"));
    });
    //回转工作台
    $("#desc-header-8").click(function () {
        toggleDescBody($(this), $("#desc-body-8"));
    });
    //齿轮
    $("#desc-header-9").click(function () {
        toggleDescBody($(this), $("#desc-body-9"));
    });
    //涡轮蜗杆
    $("#desc-header-10").click(function () {
        toggleDescBody($(this), $("#desc-body-10"));
    });
    //带传动
    $("#desc-header-11").click(function () {
        toggleDescBody($(this), $("#desc-body-11"));
    });
    
});