var ServoMotorDetailCtrl=angular.module("ServoMotorDetailCtrl",[]);
ServoMotorDetailCtrl.controller('ServoMotorDetailCtrl', function($stateParams,$scope,$http,$data,$state,$locals){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
	
	$scope.servoMotorParas={};
	$scope.servoMotorSizes={};
	//从WebAPI获取型号的详细数据，包括技术数据和尺寸数据
	$http({
		method:"GET",
		url:$data.http+"PMSrvMotorParas",
		params:{
			id:$stateParams.id
		}
	}).success(function(data){
		$scope.servoMotorParas=data;
	});

	$http({
		method:"GET",
		url:$data.http+"PMSrvMotorSizes",
		params:{
			id:$stateParams.id
		}
	}).success(function(data){
		$scope.servoMotorSizes=data;
	});

	//点击下一步按钮，跳转到伺服驱动选型页面
	$scope.nextStep=function(){
		var servoMotor=Object.assign($scope.servoMotorParas,$scope.servoMotorSizes);
		$locals.putObject($scope.FeedSystemType+"ServoMotor",servoMotor);
		$state.go("FeedSystem.Driver");
	};

	//点击返回按钮，返回到伺服电机列表页面
	$scope.back=function(){
		$state.go("FeedSystem.ServoMotor");
	};
});