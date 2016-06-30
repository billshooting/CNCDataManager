var controllers = angular.module('controllers', ["services","ui.bootstrap"]);
//中间导航栏控制器
controllers.controller('CNCNavCtrl',function($scope){
	//控制中间导航栏是否显示
	$scope.nav=[true,false,false,false,false,false];
	$scope.$on("CNCTypeChange",function(event,data){
		if(data=="X"){
			$scope.nav=[true,true,false,true,true,true,true];
		}
		else if(data=="C"){
			$scope.nav=[true,true,true,false,false,true,true];
		}
	});
});

//机床类型控制器
controllers.controller("CNCTypeCtrl",function($scope,$state,$CNCType){
	$scope.type=-1;
	$scope.support="";
	//点击图片显示图片被选中
	$scope.imgClick=function(type,support){
		$scope.type=type;
		$scope.support=support;
	};
	//点击下一步按钮将机床类型存入$CNCType服务对象实例中
	$scope.nextStep=function(){
		var CNCType=["立式车床","立式铣床","龙门铣床","卧式车床","卧式铣床","斜床身车床","磨床"];
		$CNCType.type=CNCType[$scope.type];
		$CNCType.support=$scope.support;
		$scope.$emit("CNCTypeChange",$scope.support);
		$state.go("CNCType.WorkingCondition");
	};
	//点击取消按钮恢复图片为未被选中状态
	$scope.reset=function(){
		$scope.type=-1;
		$scope.support="";
	};
});

//机床工作需求控制器
controllers.controller('CNCWorkingConditionCtrl', function ($scope) {
    $scope.submitForm = function (isValid) {
        if (isValid) {
            alert('yes');
        }
    };
});

//数控系统选型控制器
controllers.controller('CNCSystemTable', function ($scope,$http,$CNCType) {
	  //表头排序
     $scope.title="TypeID";
     $scope.desc=1;
     // 生产厂家选项绑定
     $scope.Manufacturer=["华中数控","广州数控","沈阳高精","北京航天数控"];
     $scope.filtNum={
     	Manufacturer:null,
     	SupportNumberOfChannels:1,
     	MaxControlNumberOfFeedAxis:1,
     	SupportTypeOfMachine:$CNCType.support,
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
    	pageSize:12,
    };
    //单击表格选择数控系统型号
	$scope.Selected=function(CNCSystem){
		for(var i in CNCSystem){
			$scope.CNCSystemSelected[i]=CNCSystem[i];
		}
	};
});

//直线导轨选型控制器
controllers.controller("LinnearRollingGuideCtrl",function($scope,$CNCType,$StateParams){
	$scope.FeedSystemType=$rootScope.$StateParams.FeedSystemType;
})
