var BearingsTableCtrl=angular.module("BearingsTableCtrl",[]);
BearingsTableCtrl.controller("BearingsTableCtrl",function($scope,$cookies,$stateParams,$http,$state,$data){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
	$scope.bearingTypeOptions=[
	{name:"60°接触角推力球轴承",type:"ball",url:"AngContactBallBrgs"},
	{name:"双向推力角接触球轴承",type:"ball",url:"DoubleThrustAngContactBallBrgs"},
	{name:"圆锥滚子轴承",type:"roller",url:"TaperedRollerBrgs"},
	{name:"滚针轴承和推力滚子组合轴承",type:"roller",url:"NeedleRollerThrustRollerBrgs"}];
	$scope.compoundModeOptions=[
	{name:"双列DF",factor:1},
	{name:"双列DT",factor:1},
	{name:"三列DFD",factor:1.62},
	{name:"三列DTD",factor:1.62},
	{name:"四列DFF",factor:1.62},
	{name:"四列DFT",factor:2.16}];
	$scope.lubricationMethodOptions=["油润滑","脂润滑"];
	var ballscrew=$cookies.getObject($stateParams.FeedSystemType+"SolidBallScrewNutPairs");
	var LinearRollingGuide=$cookies.getObject($stateParams.FeedSystemType+"Guide");
	var CNCWorkingCondition=$cookies.getObject("CNCWorkingCondition");
	//计算轴承内径
	var computeBearingBoreDiameter=function(){
		$scope.caculation.bearingBoreDiameter=(ballscrew)?ballscrew.AdaptableDiameterWithBearing:28;
	};
	//计算轴承极限转速
	var computebearingLimitSpeed=function(){
		$scope.caculation.bearingLimitSpeed=(ballscrew)?ballscrew.LimitRotationSpeed:8000;
	};
	//计算轴承在滚动导轨条件下的工作载荷unfinish
	var computeWorkingLoadsForRollingGuide=function(){
		var loads=new Array();
		var friction=(LinearRollingGuide)?LinearRollingGuide.friction:0.003;
		for(var i=0;i<4;i++){
			loads[i]=CNCWorkingCondition.cuttingCondition[i].lengthwaysForce+friction*
			CNCWorkingCondition.cuttingCondition[i].verticalForce+friction*(CNCWorkingCondition.productCondition.tableMass
				+CNCWorkingCondition.productCondition.productMaxMass)+100;
		}
		return loads;
	};
	//计算丝杠在滚动导轨条件下的工作载荷
	var computeWorkingLoadsForSlidingGuide=function(){
		var loads=new Array();
		var friction=(LinearRollingGuide)?LinearRollingGuide.friction:0.003;
		for(var i=0;i<4;i++){
			loads[i]=1.15*CNCWorkingCondition.cuttingCondition[i].lengthwaysForce+friction*
			CNCWorkingCondition.cuttingCondition[i].verticalForce+friction*(CNCWorkingCondition.productCondition.tableMass
				+CNCWorkingCondition.productCondition.productMaxMass);
		}
		return loads;
	};
	//计算丝杠在滑动导轨条件下的工作载荷
	var computeWorkingLoads=function(){
		var guidType=(LinearRollingGuide)?LinearRollingGuide.guidType:"滚动导轨";
		if(guidType=="滚动导轨"){
			return computeWorkingLoadsForRollingGuide();
		}
		else if(guidType="滑动导轨"){
			return computeWorkingLoadsForSlidingGuide();
		}
	};
	//计算靠近电机固定端轴承基本额定动载荷
	var computeBasicDynamicLoads=function(){
		var loads=computeWorkingLoads();
		var lifeIndex=3;
		if($scope.bearingPara.bearingType.type=="ball")
			lifeIndex=3;
		else if($scope.bearingPara.bearingType.type=="roller")
			lifeIndex=10/3;
		var equivalRotationalSpeed=0;   //平均当量转速
		var equivalentDynamicLoad=0;   //平均当量动载荷
		var supportMode=(ballscrew)?ballscrew.supportMode:"两端固定";
		var lead=(ballscrew)?ballscrew.lead:5;
		if(supportMode=="两端固定"){
			for(var i=0;i<4;i++){
				var speed=CNCWorkingCondition.cuttingCondition[i].feedSpeed*1000/lead*
					CNCWorkingCondition.cuttingCondition[i].timeScale/100;
				equivalRotationalSpeed+=speed;
			}
			var minDiameter=(ballscrew)?ballscrew.minDiameter:20;   //滚珠丝杠最小底径
			equivalentDynamicLoad=$scope.bearingPara.impactLoadFactor*1.95*$scope.bearingPara.tempeartureVariation*
				minDiameter*minDiameter;
		}
		else
		{
			for(var i=0;i<4;i++){
				var speed=CNCWorkingCondition.cuttingCondition[i].feedSpeed*1000/lead*
					CNCWorkingCondition.cuttingCondition[i].timeScale/100;
				equivalRotationalSpeed+=speed;
				equivalentDynamicLoad+=Math.pow($scope.bearPara.impactLoadFactor*loads[i],lifeIndex);
			}
			equivalentDynamicLoad=Math.pow(equivalentDynamicLoad/(equivalRotationalSpeed*100),1/lifeIndex);
		}
		$scope.caculation.ratedDynamicLoad=Math.round(($scope.bearingPara.compoundMode.factor*
				$scope.bearingPara.loadMomentFactor*equivalentDynamicLoad*Math.pow((60*
				equivalRotationalSpeed*$scope.bearingPara.lifetime)/1000000,1/lifeIndex))*1000)/1000;
	};
	//点击计算按钮，按当前数据计算出计算结果
	$scope.caculate=function(){
		computeBearingBoreDiameter();
		computebearingLimitSpeed();
		computeBasicDynamicLoads();
	};
	//点击重置按钮，重置计算数据和计算结果
	$scope.reset=function(){
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
		$scope.caculate();
	};
	$scope.reset();
	//从服务端获取相应轴承数据
	$scope.getData=function(bearingType){
		$http.get($data.http+bearingType.url)
		.then(function(response){
			$scope.bearings=response.data;
		});
	};
	$scope.getData($scope.bearingPara.bearingType);
	//控制表头排序
	$scope.title="TypeID";
	$scope.desc=1;
	//控制分页显示
	$scope.Page={
		pageSize:10,
		currentPage:1
	};
	//点击表格中一行保存所选数据
	$scope.selected=function(bearing){
		$scope.bearingSelected=bearing;
	};
	//点击下一步按钮，将所选数据存入cookies，并跳转到联轴器选型界面
	$scope.nextStep=function(){
		$scope.bearingSelected.img="Bearings";
		$cookies.putObject($scope.FeedSystemType+"Bearings",$scope.bearingSelected);
		$scope.$emit('ComponentChange',$scope.FeedSystemType+"Bearings");
		$state.go("FeedSystem.Coupling");
	};
	//点击取消按钮，取消所选数据
	$scope.cancel=function(){
		$scope.bearingSelected={};
	}
});