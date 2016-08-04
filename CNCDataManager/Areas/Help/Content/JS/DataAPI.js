$(function () {
    var toggleBody = function (head) {
        var headId = '#' + $(head).attr("id");
        var bodyId = headId + "-body";
        var icon = headId + " >span";

        var iconClass = $(icon).attr("class").toString();
        if (iconClass.indexOf("glyphicon-menu-down") > 0)
        {
            setTimeout(function () {
                $(icon).removeClass("glyphicon-menu-down").addClass("glyphicon-menu-right");
            }, 500);
        }
        else {
            $(icon).removeClass("glyphicon-menu-right").addClass("glyphicon-menu-down");
        }
        $(bodyId).animate({ height: 'toggle' }, 500);
    };

    $(".document-list-head").click(function () {
        toggleBody(this);
    });
});