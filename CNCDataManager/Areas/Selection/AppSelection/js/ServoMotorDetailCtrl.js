var ServoMotorDetailCtrl=angular.module("ServoMotorDetailCtrl",[]);
ServoMotorDetailCtrl.controller('ServoMotorDetailCtrl', function($stateParams,$scope,$locals,$default,$constants,$data,$http){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
	
});