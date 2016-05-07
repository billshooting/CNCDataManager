
$(function () {
    $(window).scroll(function () {
        if ($(window).scrollTop() < 10) {
            $("#navbar").animate({ background: 'none' });
        }
        else {
            $("#navbar").animate({ background: 'black' });
        }
    });
});