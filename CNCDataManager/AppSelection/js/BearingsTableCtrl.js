var BearingsTableCtrl=angular.module("BearingsTableCtrl",[]);
BearingsTableCtrl.controller("BearingsTableCtrl",function($scope,$cookies,$stateParams){
	$scope.bearingTypeOptions=["60°接触角推力球轴承","双向推力角接触球轴承","圆锥滚子轴承","滚针轴承和推力滚子组合轴承"];
	$scope.compoundModeOptions=[
	{name:"双列DF",factor:1},
	{name:"双列DT",factor:1},
	{name:"三列DFD",factor:1.62},
	{name:"三列DTD",factor:1.62},
	{name:"四列DFF",factor:1.62},
	{name:"四列DFT",factor:2.16}];
	$scope.lubricationMethodOptions=["脂润滑","油润滑"];
	$scope.bearingPara={
		bearingType:$scope.bearingTypeOptions[0],
		compoundMode:$scope.compoundModeOptions[0],
		lubricationMethod:$scope.lubricationMethodOptions[0],
		lifetime:20000,
		impactLoadFactor:1.3,
		loadMomentFactor:1.6,
		tempeartureVariation:2.5,
	};
	$scope.caculation={
		bearingBoreDiameter:0,
		bearingLimitSpeed:0,
		ratedDynamicLoad:0,
	};
	var ballscrew=$cookies.getObject($stateParams.FeedSystemType+"SolidBallScrewNutPairs");
	//计算轴承内径
	var computeBearingBoreDiameter=function(){
		$scope.caculation.bearingBoreDiameter=(ballscrew)?ballscrew.AdaptableDiameterWithBearing:28;
	};
	//计算轴承极限转速
	var computebearingLimitSpeed=function(){
		$scope.caculation.bearingLimitSpeed=(ballscrew)?ballscrew.LimitRotationSpeed:8000;
	};
})