var SolidBallScrewNutPairsTableCtrl=angular.module("SolidBallScrewNutPairsTableCtrl",[]);
SolidBallScrewNutPairsTableCtrl.controller("SolidBallScrewNutPairsTableCtrl",function($scope,$locals,$stateParams,$http,$state,$data){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
	//滚珠丝杠常用精度等级数据
	$scope.accuracyClassOptions=[
	{name:"P1",factor:1,transmissionEfficiency:0.9,class:1},
	{name:"P2",factor:1,transmissionEfficiency:0.9,class:2},
	{name:"p3",factor:1,transmissionEfficiency:0.9,class:3},
	{name:"P4",factor:0.9,transmissionEfficiency:0.85,class:4},
	{name:"P5",factor:0.9,transmissionEfficiency:0.85,class:5},
	{name:"P7",factor:0.8,transmissionEfficiency:0.85,class:7},
	{name:"P10",factor:0.7,transmissionEfficiency:0.86,class:10}];
	//滚珠丝杠常用可靠性数据
	$scope.reliabilityOptions=[
	{name:"90%",factor:1},
	{name:"95%",factor:0.62},
	{name:"96%",factor:0.53},
	{name:"97%",factor:0.44},
	{name:"98%",factor:0.33},
	{name:"99%",factor:0.21}];
	//滚珠丝杠预加载系数数据
	$scope.preloadTypeOptions=[
	{name:"轻预载",factor:6.7},
	{name:"中预载",factor:4.5},
	{name:"重预载",factor:3.4}];
	//滚珠丝杠支撑方式数据
	$scope.supportModeOptions=["两端固定","固定-支撑","两端支撑","固定-自由"];
	var CNCWorkingCondition=$locals.getObject("CNCWorkingCondition");
	var guid=$locals.getObject($stateParams.FeedSystemType+"Guide");
	var friction=(guid)?guid.friction:0.003;//导轨库伦摩擦系数
	var preload=0;//滚珠丝杠预紧力
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
			$scope.message="";
		}
	};
	//根据不同的工作条件计算滚珠丝杠的工作载荷，也就是丝杠的轴向作用力
	var computeWorkingLoads=function(){
		var guidType=(guid)?guid.guidType:"滚动导轨";
		var sealingResistance=100;
		var workBenchLoad=friction*(CNCWorkingCondition.productCondition.productMaxMass+CNCWorkingCondition.productCondition.tableMass)*9.8;
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
		var loadFactor={"无冲击":1.2,"轻微冲击":1.5,"有冲击或振动":2};
		//计算当量载荷和当量转速
		var equivalentRotationalSpeed=0,equivalentLoad=0;
		for(var i=0;i<4;i++){
			var speed=CNCWorkingCondition.cuttingCondition[i].feedSpeed*1000/$scope.caculation.lead*CNCWorkingCondition.cuttingCondition[i].timeScale/100;
			var workLoad=workingLoads[i];
			equivalentRotationalSpeed+=speed;
			equivalentLoad+=workLoad*workLoad*workLoad*speed;
		}
		equivalentLoad=Math.pow(equivalentLoad/equivalentRotationalSpeed,1/3);

		return Math.pow(equivalentRotationalSpeed*$scope.ballscrewPara.workingLife*60,1/3)*equivalentLoad*loadFactor[CNCWorkingCondition.productCondition.loadCharacter]
		/($scope.ballscrewPara.accuracyClass.factor*$scope.ballscrewPara.reliability.factor*100);
	};
	//利用预加载荷计算滚珠丝杠的额定动载荷
	var computeDynamicLoadByPreload=function(workingLoads){
		return Math.max.apply(null,workingLoads)*$scope.ballscrewPara.preloadType.factor;
	};
	//计算滚珠丝杠额定动载荷
	var computeDynamicLoad=function(){
		var workingLoads=computeWorkingLoads();
		var load1=computeDynamicLoadByWorkingLife(workingLoads);
		var load2=computeDynamicLoadByPreload(workingLoads);
		$scope.caculation.dynamicLoad=Math.round(Math.max(load1,load2)/1000*1000)/1000;
		preload=$scope.caculation.dynamicLoad/3;
	};
	//计算滚珠丝杠最小底半径
	var computeMinDiameter=function(){
		//滚珠丝杠螺纹长度
		var threadLength=CNCWorkingCondition.productCondition.tableTravel*1.15+$scope.caculation.lead*12;
		//滚珠丝杠允许的轴向变形
		var axialDeformation=Math.min($scope.ballscrewPara.locationAccuracy/3,$scope.ballscrewPara.repeatLocationAccuracy/4);
		//此处待完善
		var staticFriction=0.1*(CNCWorkingCondition.productCondition.productMaxMass+CNCWorkingCondition.productCondition.tableMass)*9.8;
		$scope.caculation.minDiameter=Math.round(0.039*Math.sqrt(staticFriction*threadLength/axialDeformation)*1000)/1000;
	};
	//计算滚珠丝杠等效转矩
	var computeTorque=function(){
		//去除滚珠丝杠轴向作用力中的最大值
		var maxWokringLoad=Math.max.apply(null,computeWorkingLoads());
		var efficiency=$scope.ballscrewPara.accuracyClass.transmissionEfficiency;
		$scope.caculation.torque=Math.round((maxWokringLoad+preload*(1-efficiency*efficiency))*$scope.caculation.lead/(2*Math.PI*efficiency*1000)*1000)/1000;
	};
	//点击计算按钮，执行所有计算方法
	$scope.caculate=function(){
		computeLead();
		computeDynamicLoad();
		computeMinDiameter();
		computeTorque();
	};
	//点击重置按钮，重置页面相关元素，并执行所有计算方法
	$scope.reset=function(){
		$scope.ballscrewPara={
			accuracyClass:$scope.accuracyClassOptions[0],
			reliability:$scope.reliabilityOptions[0],
			supportMode:$scope.supportModeOptions[0],
			preloadType:$scope.preloadTypeOptions[0],
			screwLength:1000,
			locationAccuracy:5,
			repeatLocationAccuracy:5,
			motorMaxSpeed:3000,
			workingLife:20000,
		};
		$scope.caculation={
			lead:0,
			dynamicLoad:0,
			minDiameter:0,
			torque:0,
		};
		$scope.caculate();
	};
	$scope.reset();
	//从服务端获取滚珠丝杠数据
	$http.get($data.http+"SolidBallScrewNutPairs")
	.then(function(response){
		$scope.ballscrews=response.data;
		angular.element(document.getElementsByClassName("loader")).remove();
	});
	$scope.title="TypeID";
	$scope.desc=1;
	$scope.Page={
		pageSize:10,
		currentPage:1
	};
	$scope.selected=function(ballscrew){
		$scope.ballscrewSelected=ballscrew;
	};
	$scope.nextStep=function(){
		$scope.ballscrewSelected.torque=$scope.caculation.torque;
		$scope.ballscrewSelected.supportMode=$scope.ballscrewPara.supportMode;//将滚珠丝杠支撑方式存入cookies
		$scope.ballscrewSelected.minDiameter=$scope.caculation.minDiameter;//将滚珠丝杠计算结果最小底径存入cookies
		$scope.ballscrewSelected.lead=$scope.caculation.lead;//将滚珠丝杠计算结果导程存入cookies
		$scope.ballscrewSelected.accuracyClass=$scope.ballscrewPara.accuracyClass.class;
		$scope.ballscrewSelected.img="Ballscrew.jpg";
		$locals.putObject($scope.FeedSystemType+"Ballscrew",$scope.ballscrewSelected);
		$scope.$emit('ComponentChange',$scope.FeedSystemType+"Ballscrew");
		$state.go("FeedSystem.Bearings");
	};
	$scope.cancel=function(){
		$scope.ballscrewSelected={};
	}
});