var DriverTableCtrl=angular.module("DriverTableCtrl",[]);
DriverTableCtrl.controller('DriverTableCtrl', function($stateParams,$scope,$locals,$data,$http,$state){
	$scope.FeedSystemType=$stateParams.FeedSystemType;

	//输入电源类型选项数据
	$scope.powerTypeOptions=[
		{name:"单相220V",value:"单相220"},
		{name:"三相220V",value:"三相220"},
		{name:"三相380V",value:"三相380"}];
	$scope.manufacturerOptions=[
		{name:"华中数控",value:"武汉华中数控股份有限公司"},
		{name:"广州数控",value:"广州数控"},
		{name:"沈阳高精",value:"沈阳高精数控技术有限公司"},
		{name:"北京航天数控",value:"北京航天数控"}];
	//执行计算得到计算结果
	$scope.caculate=function(){
		computeInputCurrent();
	};

	//重置界面计算数据	
	$scope.reset=function(){
		$scope.driverPara={
			manufacturer:$scope.manufacturerOptions[0],
			powerType:$scope.powerTypeOptions[0],
			overloadCurrent:2,
			inputCurrent:5,
			ratedCurrent:0,
		}
		$scope.caculate();
	};
	$scope.reset();

	//从webAPI获取伺服驱动技术数据
	$http.get($data.http+"PMSrvMotorDrivers")
		.then(function(response){
			$scope.drivers=response.data;
		});

	//选中表格中的一行伺服驱动型号
	$scope.selected=function(driver){
		$scope.driverSelected=driver;
	};

	//点击取消按钮，取消表格中一行的选定状态
	$scope.cancel=function(){
		$scope.driverSelected={};
	};

	//点击下一步按钮，跳转到下一个轴选型界面
	$scope.nextStep=function(){
		$scope.driverSelected.img="Driver.jpg";
		$locals.putObject($scope.FeedSystemType+"Driver",$scope.driverSelected);
		$scope.$emit('ComponentChange',$scope.FeedSystemType+"Driver");
		
		switch($scope.FeedSystemType){
			case "X":
				$state.go("FeedSystem",{FeedSystemType:"Y"});
				break;
			case "Y":
			case "Z":
			case "XY":
				$state.go("FeedSystem",{FeedSystemType:"Z"});
				break;
		}
	};

	//控制表头排序
	$scope.title="TypeID";
	$scope.desc=1;
	//控制分页
	$scope.Page={
		pageSize:10,
		currentPage:1
	};

	//计算伺服驱动器输出电流
	function computeInputCurrent(){
		$scope.driverPara.ratedCurrent=$scope.driverPara.inputCurrent*$scope.driverPara.overloadCurrent;
	}
});