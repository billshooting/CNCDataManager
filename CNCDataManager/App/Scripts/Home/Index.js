
var deg = 0, rotateIntval;
function startRotate(img) {
    deg += 5;
    img.css({ transform: "rotateY(" + deg + "deg)" });
    //img.css({ webkitTransform: "rotateY(" + deg + "deg)" });
    //img.css({ OTransform: "rotateY(" + deg + "deg)" });
    //img.css({ MozTransform: "rotateY(" + deg + "deg)" });
    if (deg == 360) {
        clearInterval(rotateIntval);
        deg = 0;
    }
}

$(function () {
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

    //实现图片翻转功能  
    $(".tech-img").mouseover(function () {
        var img = $(this);
        img.animate({ transform: "rotateY(180deg)", height: "+=25" }, 1000).animate({ height: "-=25" }, 1000);
        //clearInterval(rotateIntval);
        //rotateIntval = setInterval(startRotate(img), 50);
    });
});
