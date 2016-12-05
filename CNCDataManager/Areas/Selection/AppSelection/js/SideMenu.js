$(function () {
    //启用侧边栏插件
    $('#sideMenu').BootSideMenu({
        side: "right",
        autoClose: true
    });

    //点击侧边栏finish按钮，发送json数据到服务器
    $("#side-finish").click(function () {
        let system = getObject("CNCSystem");
        let ncSystem = {
            TypeID: system.TypeID,
            SupportMachineType: system.SupportMachineType,
            NumberOfSupportChannels: system.SupportChannels,
            MaxNumberOfFeedSystemAxis: system.MaxNumberOfFeedShafts,
            MaxNumberOfSpindleAxis: system.MaxNumberOfSpindels,
            MaxNumberOfLinkageAxis: system.MaxNumberOfLinkageAxis
        };

    	var selectionResult={
            CNCType:getObject("CNCType"),
            NCSystem:ncSystem,
            FeedSystemZ:getFeedSystem("Z"),
        };
        if(selectionResult.CNCType.support==="C")
        {
            selectionResult.FeedSystemXY=getFeedSystem("XY");
        }
        else if(selectionResult.CNCType.support==="X")
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

    //点击侧边栏restart按钮，清楚数据
    $("#side-restart").click(function(){
    	localStorage.clear();
    	location.href="/Selection/Selection/Index#/CNCType";
    	$("#restartModal").modal("hide");
    	location.reload();
    });

    //为每个侧边栏选项添加取消点击事件
    var feedSide=new Array("XY","X","Y","Z");
    var ComponentSide=new Array("Guide","Ballscrew","Bearings","Coupling","Motor","Driver");
    addCancelEvent("CNCSystem");
    for(var i=0;i<feedSide.length;++i)
        {
            for(var j=0;j<ComponentSide.length;++j)
            {
                var data=feedSide[i]+ComponentSide[j];
                addCancelEvent(data);
            }
        }


    function addCancelEvent(data){
        $("#"+data+"Cancel").click(function(){
            localStorage.removeItem(data);
            ResetComponent(data);
            $(this).hide();
        });
    }

    function ResetComponent(data){
        $("#"+data+"Check").removeClass('glyphicon-check');
        $("#"+data+"Check").addClass('glyphicon-unchecked');
        $("#"+data + "Img").attr("src", "../../Areas/Selection/AppSelection/imgs/loading.jpg");
        $("#"+data+"ID").text("未选择");
        $("#"+data+"Manu").text("");
        $("#"+data+"Num").text(0);
    }

    //从localstorag中获取数据
    function getObject(key){
        return JSON.parse(localStorage.getItem(key)) || {};
    }

    //从每个进给系统的localstorage中获取数据
    function getFeedSystem(axis){
        var feedSystem = {
            Guide: getObject(axis + "Guide"),
            Ballscrew: getObject(axis + "Ballscrew"),
            Bearings: getObject(axis + "Bearings"),
            Coupling: getObject(axis + "Coupling"),
            ServoMotor: getObject(axis + "Motor"),
            Driver: getObject(axis + "Driver"),
        };
        console.log(feedSystem.Driver);
        return feedSystem;
    }
});