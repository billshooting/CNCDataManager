var DriverDetailCtrl=angular.module("DriverDetailCtrl",[]);
DriverDetailCtrl.controller('DriverDetailCtrl', function($stateParams,$scope,$locals,$data,$http,$state){
	$scope.FeedSystemType=$stateParams.FeedSystemType;

	//从webAPI获取对应型号伺服驱动技术数据
	$http({
		method:"GET",
		url:$data.http+"PMSrvMotorDrivers",
		params:{
			id:$stateParams.id
		}
	}).success(function(data){
		$scope.driver=data;
	});

	//点击下一步按钮，跳转到下一个轴的选型界面
	$scope.nextStep=function(){
		$scope.driver.img="Driver.jpg";
		$locals.putObject($scope.FeedSystemType+"Driver",$scope.driver);
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

	//点击返回按钮返回伺服驱动列表页
	$scope.back=function(){
		$state.go("FeedSystem.Driver");
	};
});