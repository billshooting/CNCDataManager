var ServoMotorTableCtrl=angular.module("ServoMotorTableCtrl",[]);
ServoMotorTableCtrl.controller('ServoMotorTableCtrl', function($stateParams,$scope,$locals,$default,$constants,$data,$http,$state){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
	$scope.a="red";
	//伺服电机相关数据数据
	$scope.manufacturerOptions=["华大","广数","登奇","光洋"];
	$scope.voltageOptions=[
	{name:"全部",id:0},
	{name:"低压220V",id:220},
	{name:"高压380V",id:380}];
	$scope.keywayOptions=["A","B","C","无"];

	//从localstorage中取出计算所需参数
	var ballscrew=$locals.getObject($scope.FeedSystemType+"Ballscrew");
	var workingCondition=$locals.getObject("CNCWorkingCondition");

	//执行计算得到计算结果
	$scope.caculate=function(){
		computeLoadInertia();
		computLoadTorque();
	};

	//将计算条件重置为初始值，并执行计算
	$scope.reset=function(){
		$scope.servoMotorPara={
			manufacturer:$scope.manufacturerOptions[0],
			voltage:$scope.voltageOptions[0],
			loadTorque:0,
			loadInertia:0,
			keyway:$scope.keywayOptions[0],
		};
		$scope.caculate();
	};

	$scope.reset();

	//从webAPI获取伺服电机数据
	$http.get($data.http+"PMSrvMotorParas")
		.then(function(response){
			$scope.servoMotors=response.data;
		});

	//点击表中一行，选中某一型号伺服电机
	$scope.selected=function(servoMotor){
		$scope.servoMotorSelected=servoMotor;
	};

	//点击下一步按钮，跳转到伺服驱动选型
	$scope.nextStep=function(){
		$scope.servoMotorSelected.img="ServoMotor.jpg";
		$locals.putObject($scope.FeedSystemType+"Motor",$scope.servoMotorSelected);
		$scope.$emit('ComponentChange',$scope.FeedSystemType+"Motor");
		$state.go("FeedSystem.Driver");
	};

	//点击取消，取消表格选定状态
	$scope.cancel=function(){
		$scope.servoMotorSelected={};
	};

	$scope.title="TypeID";
	$scope.desc=1;

	$scope.Page={
		pageSize:10,
		currentPage:1
	};

	//计算滚珠丝杠的转动惯量
	function computeIntertia(){
		var diameter=ballscrew?ballscrew.NominalDiameter_d0:$default.ballscrewNominalDiameter_d0;
		var ballscrewLength=ballscrew?ballscrew.LengthOfScrew_L:$default.ballscrewLength;
		var ballscrewIntertia=$constants.IronDensity*diameter*diameter*diameter*diameter*ballscrewLength
			*9.8e-7;
		return ballscrewIntertia;
	}

	//计算电机轴上的等效负载惯量
	function computeLoadInertia(){
		var lead=ballscrew?ballscrew.lead:$default.ballscrewLead;
		var L=lead/(20*Math.PI);
		$scope.servoMotorPara.loadInertia=(workingCondition.productCondition.tableMass
			+workingCondition.productCondition.productMaxMass)*L*L+computeIntertia();
	}

	//计算电机轴上的等效负载转矩
	function computLoadTorque(){
		$scope.servoMotorPara.loadTorque=ballscrew?ballscrew.torque:$default.ballscrewTorque;
	}
});