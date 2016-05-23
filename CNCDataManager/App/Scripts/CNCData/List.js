$.ready(function () {
    //表格列的选择功能
    //var colClickHandler = function(colName, icon, col)
    //{

    //}
    angular.element("#cncdata-table-col-1").c
    $("#cncdata-table-col-1").click(function () {
        alert("a");
        if ($(this).hasClass("cncdata-table-col-checked")) {
            alert("a");
            //取消选中
            $(this).removeClass("cncdata-table-col-checked");//对div的操作
            $("#cncdata-table-col-1 >span:first-child").removeClass("glyphicon-check")
                                                       .addClass("glyphicon-unchecked");//对图标操作
            $(".cncdata-table-col-1").css({ display: 'none' });//对列操作
        }
        else {
            //增加选中
            $(this).addClass("cncdata-table-col-checked");//对div的操作
            $("#cncdata-table-col-1 >span:first-child").addClass("glyphicon-check")
                                                       .removeClass("glyphicon-unchecked");//对图标操作
            $(".cncdata-table-col-1").css({ display: 'auto' });//对列操作
        }
    });
});