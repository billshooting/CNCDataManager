
$(function () {
    $(window).scroll(function () {
        if ($(window).scrollTop() < 10) {
            $("#navbar").css({ background: 'none' });
        }
        else {
            $("#navbar").css({ background: '#555' });
        }
    });
});