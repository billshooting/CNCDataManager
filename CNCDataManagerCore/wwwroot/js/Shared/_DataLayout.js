﻿$(function () {

    //关闭加载动画
    $(".overlay-container").css({ display: 'none' });
    //关闭提示页
    $(".overlay-container >span").click(function () {
        $(".overlay-container").css({ display: 'none' });
    });

    $(window).scroll(function () {
        if ($(window).scrollTop() < 10) {
            $("#navbar").css({ background: 'none' });
            $("#back-to-top").fadeOut(500);
        }
        else {
            $("#navbar").css({ background: '#555' });
            $("#back-to-top").fadeIn(500);
        }
    });

    //点击返回顶部的功能实现
    $("#back-to-top").click(function () {
        $('body,html').animate({ scrollTop: 0 }, 300);
        return false;
    });
});