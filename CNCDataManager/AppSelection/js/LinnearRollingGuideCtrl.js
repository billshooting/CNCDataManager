var LinnearRollingGuideCtrl=angular.module("LinnearRollingGuideCtrl",[]);
//直线导轨选型控制器
LinnearRollingGuideCtrl.controller("LinnearRollingGuideCtrl",function($scope,$stateParams,$cookies){
	var FeedSystemType=$stateParams.FeedSystemType;
    var CNCWorkingCondition=$cookies.getObject("CNCWorkingCondition");
    //根据进给轴类型切换导轨尺寸图片
    if(FeedSystemType=="XY"||FeedSystemType=="X"){
        $scope.imgsrc="../../../../AppSelection/imgs/立铣水平上导轨.jpg";
    }
    else if(FeedSystemType=="Y"){
        $scope.imgsrc="../../../../AppSelection/imgs/立铣水平下导轨.jpg";
    }
    else if(FeedSystemType=="Z"){
        $scope.imgsrc="../../../../AppSelection/imgs/立铣Z轴导轨.jpg";
    }
    //绑定相关尺寸和导轨参数数据并计算得出结果
    $scope.reset=function(){
        if(FeedSystemType=="XY"||FeedSystemType=="X"){
            $scope.isShow6=false;
            $scope.sizePara={
                sizeL0:500,
                sizeL1:500,
                sizeL2:200,
                sizeL3:150,
                sizeL4:50,
                sizeL5:100,
            };
        }
        else if(FeedSystemType=="Y"){
            $scope.isShow6=false;
            $scope.sizePara={
                sizeL0:600,
                sizeL1:800,
                sizeL2:250,
                sizeL3:200,
                sizeL4:150,
                sizeL5:100,
            };
        }
        else if(FeedSystemType=="Z"){
            $scope.isShow6=true;
            $scope.sizePara={
                sizeL0:600,
                sizeL1:400,
                sizeL2:500,
                sizeL3:250,
                sizeL4:100,
                sizeL5:150,
                sizeL6:60,
            };
        }
    };
    $scope.reset();
    //计算导轨加工所在轴最小静载荷
    var computeWorkingAxisMinLoad=function(){
        var w1=9.8*CNCWorkingCondition.productMaxMass;
        var w2=9.8*CNCWorkingCondition.tableMass;
        var workLoads=[8,4];
        //强力切削，一般切削，精切削

    }
});