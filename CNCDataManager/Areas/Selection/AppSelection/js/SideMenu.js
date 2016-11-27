$(function () {
    $('#sideMenu').BootSideMenu({
        side: "right",
        autoClose: true
    });

    $("#side-finish").click(function () {
    	var SelectionResult={
            CNCType:getObject("CNCType"),
            CNCSytem:getObject("CNCSystem"),
            FeedSystemX:getFeedSystem("X"),
            FeedSystemY:getFeedSystem("Y"),
            FeedSystemZ:getFeedSystem("Z"),
        };
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
            Guide:getObejct(axis+"Guide"),
            Ballscrew:getObject(axis+"Ballscrew"),
            Bearings:getObject(axis+"Bearings"),
            Coupling:getObject(axis+"Coupling"),
            ServoMotor:getObject(axis+"ServoMotor"),
            Driver:getObject(axis+"Driver"),
        }
        return feedSystem;
    }
});