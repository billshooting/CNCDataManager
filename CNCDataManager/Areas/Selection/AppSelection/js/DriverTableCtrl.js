var DriverTableCtrl=angular.module("DriverTableCtrl",[]);
DriverTableCtrl.controller('DriverTableCtrl', function($stateParams,$scope,$locals,$default,$constants,$data,$http,$state){
	$scope.FeedSystemType=$stateParams.FeedSystemType;

	//输入电源类型选项数据
	$scope.powerTypeOptions=[
		{name:"单相220V",value:"单相220"},
		{name:"三相220V",value:"三相220"},
		{name:"三相380V",value:"三相380"}];

	//执行计算得到计算结果
	$scope.caculate=function(){
		computeInputCurrent();
	};

	//重置界面计算数据	
	$scope.reset=function(){
		$scope.driverPara={
			powerType:$scope.powerTypeOptions[0],
			overloadCurrent:2,
			inputCurrent:1,
			ratedCurrent:0,
		}
		$scope.caculate();
	};
	$scope.reset();

	//计算伺服驱动器输出电流
	function computeInputCurrent(){
		$scope.ratedCurrent=$scope.inputCurrent*$scope.overloadCurrent;
	}
});