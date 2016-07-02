var controllers = angular.module('controllers', []);
var injector=angular.injector(["ng"]);
//中间导航栏控制器
controllers.controller('CNCNavCtrl',function($scope,$cookies){
	//中间导航栏初始化方法，控制中间导航栏是否显示
    var reset=function(){
        var CNCType=$cookies.getObject("CNCType");
        if(CNCType==undefined){
            $scope.navShow=[true,false,false,false,false,false];
        }
        else{
            if(CNCType.support=="X"){
                $scope.navShow=[true,true,false,true,true,true,true];
            }
            else if(CNCType.support=="C"){
                $scope.navShow=[true,true,true,false,false,true,true];
            }
        }
    };
    injector.invoke(reset);
    //监控子作用域传播来的事件，并初始化中间导航栏
    $scope.$on("CNCTypeChange",function(event,data){
        injector.invoke(reset);
    });
	/*$scope.navShow=[true,false,false,false,false,false];*/
	/*$scope.$on("CNCTypeChange",function(event,data){
		if(data=="X"){
			$scope.navShow=[true,true,false,true,true,true,true];
		}
		else if(data=="C"){
			$scope.navShow=[true,true,true,false,false,true,true];
		}
	});*/
    //控制中间导航栏选项是否active
    $scope.navActive=0;
    $scope.navClick=function(e){
        $scope.navActive=e;
    };
    //初始化导航栏方法
    
});

//机床类型控制器
controllers.controller("CNCTypeCtrl",function($scope,$state,$cookies){
	$scope.type=-1;
	$scope.support="";
	//点击图片显示图片被选中
	$scope.imgClick=function(type,support){
		$scope.type=type;
		$scope.support=support;
	};
	//点击下一步按钮将机床类型存入cookies键为CNCType中
	$scope.nextStep=function(){
		var CNCType=["立式车床","立式铣床","龙门铣床","卧式车床","卧式铣床","斜床身车床","磨床"];
		$cookies.putObject("CNCType",{
            type:CNCType[$scope.type],
            support:$scope.support,
        });
        $scope.$emit("CNCTypeChange");
		$state.go("CNCType.WorkingCondition");
	};
	//点击取消按钮恢复图片为未被选中状态
	$scope.reset=function(){
		$scope.type=-1;
		$scope.support="";
	};
});

//机床工作需求控制器
controllers.controller('CNCWorkingConditionCtrl', function ($scope,$state,$cookies) {
    //点击下一步按钮
    $scope.nextStep=function(){
        var CNCType=$cookies.getObject("CNCType");
         if(CNCType.support=="X"){
                $state.go("FeedSystem",{FeedSystemType:'X'});
            }
        else if(CNCType.support=="C"){
                $state.go("FeedSystem",{FeedSystemType:'XY'});
            }
        
    };
    $scope.reset=function(){

    };
});

//数控系统选型控制器
controllers.controller('CNCSystemTable', function ($scope,$http,$state,$cookies) {
	  //表头排序
     $scope.title="TypeID";
     $scope.desc=1;
     // 生产厂家选项绑定
     $scope.Manufacturer=["华中数控","广州数控","沈阳高精","北京航天数控"];
     $scope.filtNum={
     	Manufacturer:null,
     	SupportNumberOfChannels:1,
     	MaxControlNumberOfFeedAxis:1,
     	SupportTypeOfMachine:$cookies.getObject("CNCType").support,
     };
     //所选数控系统类型
     $scope.CNCSystemSelected={};
     //数字输入框增加减少方法
     $scope.add=function(id){
     	switch(id){
     		case 0:
     			$scope.filtNum.SupportNumberOfChannels=parseInt($scope.filtNum.SupportNumberOfChannels,10)+1;
     			break;
     		case 1:
     			$scope.filtNum.MaxControlNumberOfFeedAxis=parseInt($scope.filtNum.MaxControlNumberOfFeedAxis,10)+1;
     			break;
     		default:
     			break;
     	}
     };
     $scope.minus=function(id){
     	switch(id){
     		case 0:
     			if($scope.filtNum.SupportNumberOfChannels>=2){
     				$scope.filtNum.SupportNumberOfChannels=parseInt($scope.filtNum.SupportNumberOfChannels,10)-1;
     			}
     			break;
     		case 1:
     			if($scope.filtNum.MaxControlNumberOfFeedAxis>=2){
     				$scope.filtNum.MaxControlNumberOfFeedAxis=parseInt($scope.filtNum.MaxControlNumberOfFeedAxis,10)-1;
     			break;
     			}
     			break;
     		default:
     			break;
     	}
     };
     //从服务端获取数据
    $http.get('http://cncdataapi.azurewebsites.net/api/cncdata/NCSystems')
      .then(function (response) {
          $scope.NCSystems = response.data;
      });
    //数控系统数据分页
    $scope.Page={
    	currentPage:1,
    	pageSize:10,
    };
    //单击表格选择数控系统型号
	$scope.Selected=function(CNCSystem){
        $scope.CNCSystemSelected=CNCSystem;//直接引用传递即可
	};
    //点击下一步按钮将数控系统类型存入$CNCSelected服务对象实例中
    $scope.nextStep=function(){
        $cookies.putObject("CNCSystem",$scope.CNCSystemSelected);
        $state.go("CNCSystem.Accessories");
    };
    // 点击取消按钮恢复表格中选中行为未选中状态
    $scope.reset=function(){
        $scope.CNCSystemSelected={};
    };
});

//直线导轨选型控制器
controllers.controller("LinnearRollingGuideCtrl",function($scope,$stateParams){
	var FeedSystemType=$stateParams.FeedSystemType;
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
});
