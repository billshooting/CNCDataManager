$(function () {
    $('#sideMenu').BootSideMenu({
        side: "right",
        autoClose: true
    });

    $("#side-finish").click(function () {
    	var selectionResult={
            CNCType:getObject("CNCType"),
            NCSytem:getObject("CNCSystem"),
            FeedSystemZ:getFeedSystem("Z"),
        };
        if(selectionResult.CNCType.support=="C")
        {
            selectionResult.FeedSystemXY=getFeedSystem("XY");
        }
        else if(selectionResult.CNCType.support=="X")
        {
            selectionResult.FeedSystemX=getFeedSystem("X");
            selectionResult.FeedSystemY=getFeedSystem("Y");
        }
        $.post("/Report/Index", selectionResult, function (data) {
            let docWindow = window.open("", "预览");
            docWindow.document.write(data);
        });
        $("#finishModal").modal("hide");
    });

    $("#side-restart").click(function(){
    	localStorage.clear();
    	location.href="/Selection/Selection/Index#/CNCType";
    	$("#restartModal").modal("hide");
    	location.reload();
    });

    function getObject(key){
        return JSON.parse(localStorage.getItem(key));
    }

    function getFeedSystem(axis){
        var feedSystem={
            Guide:getObject(axis+"Guide"),
            Ballscrew:getObject(axis+"Ballscrew"),
            Bearings:getObject(axis+"Bearings"),
            Coupling:getObject(axis+"Coupling"),
            ServoMotor:getObject(axis+"Motor"),
            Driver:getObject(axis+"Driver"),
        }
        return feedSystem;
    }
});