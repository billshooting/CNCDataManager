var SolidBallScrewNutPairsTableCtrl=angular.module("SolidBallScrewNutPairsTableCtrl",[]);
SolidBallScrewNutPairsTableCtrl.controller("SolidBallScrewNutPairsTableCtrl",function($scope,$cookies,$stateParams){
	//滚珠丝杠选项值绑定
	$scope.accuracyClassOptions=["P1","P2","p3","P4","P5","P7","P10"];
	$scope.reliabilityOptions=["90","95","96","97","98","99"];
	$scope.ballscrewPara={
		accuracyClass,
		reliability,
		supportMode,
		preloadType,
		screwLength:1000,
		locationAccuracy:5,
		repeatLocationAccuracy:5,
		motorMaxSpeed:3000,
	};
	$scope.caculation={
		lead:0,
		dynamicLoad:0,
		minDiameter:0,
		torque:0,
	};
	var CNCWorkingCondition=$cookies.getObject("CNCWorkingCondition");
	var guid=$cookies.getObject($stateParams.FeedSystemType+"LinearRollingGuide");
	var friction=(guid)?guid.friction:0.003;
	//计算滚珠丝杠合适的公称导程
	var computeLead=function(){
		var hellicalPitches=[1,2,2.5,3,4,5,6,8,10,12,16,20,25,32,40];//常用公称导程
		var helicalPitch=CNCWorkingCondition.productCondition.maxFeedSpeed*1000/$scope.ballscrewPara.motorMaxSpeed;//计算实际公称导程
		if(helicalPitch>hellicalPitches[hellicalPitches.length-1]){
			$scope.message="导程超出可选公称导程范围！";
		}
		else{
			for(var i=0;i<hellicalPitches.length;i++){
				if(helicalPitch<=hellicalPitches[i]){
					$scope.caculation.lead=hellicalPitches[i];
					break;
				}
			}
		}
	};
	//根据不同的工作条件计算滚珠丝杠的工作载荷，也就是丝杠的轴向作用力
	var computeWorkingLoads=function(){
		var guidType=(guid)?guid.guidType:"滚动导轨";
		var sealingResistance=100;
		var workBenchLoad=friction*(CNCWorkingCondition.productCondition.productMaxMass+CNCWorkingCondition.productCondition.tableMass);
		var loads=new Array(4);
		if(guidType=="滚动导轨"){
			for(var i=0;i<4;i++){
				loads[i]=CNCWorkingCondition.cuttingCondition[i].lengthwaysForce+friction*CNCWorkingCondition.cuttingCondition[i].verticalForce+workBenchLoad+sealingResistance;
			}
		}
		else if(guidType=="滑动导轨"){
			for(var i=0;i<4;i++){
				loads[i]=1.15*CNCWorkingCondition.cuttingCondition[i].lengthwaysForce+friction*CNCWorkingCondition.cuttingCondition[i].verticalForce+workBenchLoad;
			}
		}
		return loads;
	};
	//利用额定寿命计算滚珠丝杠的额定动载荷
	var computeDynamicLoadByWorkingLife=function(workingLoads){
		//计算当量载荷和当量转速
		var equivalentRotationalSpeed=0,equivalentLoad=0;
		for(var i=0;i<4;i++){
			var speed=CNCWorkingCondition.cuttingCondition[i].feedSpeed*1000/$scope.caculation.lead*CNCWorkingCondition.cuttingCondition[i].timeScale/100;
			var workLoad=workingLoads[i];
			equivalentRotationalSpeed+=speed;
			equivalentLoad+=workLoad*workLoad*workLoad*speed;
		}
		equivalentLoad=Math.pow(equivalentLoad/equivalentRotationalSpeed,1/3);
	};
	computeWorkingLoads();
	var computedynamicLoad=function(){

	};
});