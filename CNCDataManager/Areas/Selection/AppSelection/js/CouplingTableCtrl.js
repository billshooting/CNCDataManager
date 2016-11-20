var CouplingTableCtrl=angular.module("CouplingTableCtrl",[]);
CouplingTableCtrl.controller('CouplingTableCtrl',function($scope,$state,$stateParams,$cookies,$default){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
	//联轴器类型数据
	$scope.typeOptions=[
	{name:"十字滑块式联轴器",},
	{name:"弹性柱销联轴器",},
	{name:"弹性套柱销联轴器",},
	{name:"带制动轮弹性套柱销联轴器",},
	{name:"凸缘联轴器",},
	{name:"齿式联轴器",},
	{name:"梅花形弹性联轴器"}];
	//从cookies中取出计算所需参数
	var guide=$cookies.getObject($scope.FeedSystemType+"Guide");
	var ballscrew=$cookies.getObject($scope.FeedSystemType+"Ballscrew");
	var CNCWorkingCondition=$cookies.getObject("CNCWorkingCondition");
	//计算联轴器轴孔直径
	var computeCouplingShaftDia=function()
	{
		$scope.caculation.shaftDia=ballscrew?ballscrew.AdaptableDiameterWithCouplingShaftHole:$default.ballscrewShaftDia;
	}
	//计算联轴器最大转速
	var computeMaxSpeed=function()
	{
		$scope.caculation.maxSpeed=ballscrew?ballscrew.LimitRotationSpeed:$default.ballscrewMaxSpeed;
	}
	//计算滚珠丝杠在滚动导轨条件下的工作载荷
	var computeWorkingLoadsForRollingGuide=function()
	{
		var friction=guide?guide.friction:$default.guideFriction;
		var workBenchLoad=friction*(CNCWorkingCondition.productCondition.productMaxMass+
			CNCWorkingCondition.productCondition.tableMass);
		var loads=new Array(4);
		for(var i=0;i<4;++i)
		{
			loads[i]=CNCWorkingCondition.cuttingCondition[i].lengthwaysForce+friction*
				CNCWorkingCondition.cuttingCondition[i].verticalForce+workBenchLoad+$default.guideSealingResistance;
		}
		return loads;
	}
	//计算滚珠丝杠在滑动导轨条件下的工作载荷
	var computeWorkingLoadsForSlidingGuide=function()
	{
		var friction=guide?guide.friction:$default.guideFriction;
		var workBenchLoad=friction*(CNCWorkingCondition.productCondition.productMaxMass+
			CNCWorkingCondition.productCondition.tableMass);
		var loads=new Array(4);
		for(var i=0;i<4;++i)
		{
			loads[i]=1.15*CNCWorkingCondition[i].cuttingCondition.lengthwaysForce+friction*
				CNCWorkingCondition[i].cuttingCondition.verticalForce+workBenchLoad;
		}
		return loads;
	}
	//计算滚珠丝杠下不同工作条件下的工作载荷
	var computeWorkingLoads=function()
	{
		var guideType=guide?guide.guidType:$default.guideType;
		if(guideType=="滚动导轨")
			return computeWorkingLoadsForRollingGuide();
		else
			return computeWorkingLoadsForSlidingGuide();
	}
	//计算联轴器计算转矩
	var computeCouplingcomputedTorque=function()
	{
		var workingLoads=computeWorkingLoads();
		var workingload=workingLoads[0];
		for(var i=1;i<4;++i)
			workingload=(workingLoads[i]>workingload)?workingLoads[i]:workingload;

		var accuracyClass=ballscrew?ballscrew.accuracyClass:$default.ballscrewAccuracyClass;
		var screwDriveEfficiency=(accuracyClass>=4)?0.9:0.85;
		var ballscrewLead=ballscrew?ballscrew.lead:$default.ballscrewLead;
		$scope.caculation.computedTorque=Math.round(($scope.couplingPara.applicationFactor*workingload*ballscrewLead*
			0.003)/(2*Math.PI*screwDriveEfficiency)*1000)/1000;
	}
	//绑定联轴器页面计算按钮点击事件
	$scope.caculate=function(){
		computeCouplingShaftDia();
		computeMaxSpeed();
		computeCouplingcomputedTorque();
	};
	//绑定联轴器页面重置按钮点击事件
	$scope.reset=function(){
		$scope.couplingPara={
			couplingType:$scope.typeOptions[0],
			applicationFactor:1.6,
		};
		$scope.caculation={
			shaftDia:0,
			maxSpeed:0,
			computedTorque:0,
		};
		$scope.caculate();
	};
	$scope.reset();
	
});