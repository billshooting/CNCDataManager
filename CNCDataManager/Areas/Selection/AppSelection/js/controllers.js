var controllers = angular.module('controllers', []);
var injector=angular.injector(["ng"]);
//中间导航栏控制器
controllers.controller('CNCNavCtrl',function($scope,$locals){
	//中间导航栏初始化方法，控制中间导航栏是否显示
    var reset=function(){
        var CNCType=$locals.getObject("CNCType");
        if(!CNCType){
            $scope.navShow=[true,false,false,false,false,false];
            angular.element(document.querySelectorAll('.c-feed,.x-feed')).css('display','none');
        }
        else{
            if(CNCType.support=="X"){
                $scope.navShow=[true,true,false,true,true,true,true];
                angular.element(document.querySelectorAll('.c-feed')).css('display','none');
                angular.element(document.querySelectorAll('.x-feed')).css('display','inline');
            }
            else if(CNCType.support=="C"){
                $scope.navShow=[true,true,true,false,false,true,true];
                angular.element(document.querySelectorAll('.x-feed')).css('display','none');
                angular.element(document.querySelectorAll('.c-feed')).css('display','inline');
            }
        }
    };
    injector.invoke(reset);
    injector.invoke(resetSide);
    //监控子作用域传播来的事件，并初始化中间导航栏和侧边栏中的数控机床类型
    $scope.$on("CNCTypeChange",function(event,data){
        injector.invoke(reset);
        var CNCType=$locals.getObject("CNCType");
        onComponentChange("CNCType",CNCType.type,CNCType.support,CNCType.img);
    });
    //控制中间导航栏选项是否active
    $scope.navActive=0;
    $scope.$on("$stateChangeSuccess",function(event,toState,toParams,fromState,fromParams){
        var statename=toState.name;
        if(statename.indexOf("CNCType")>=0){
            $scope.navActive=0;
        }
        else if(statename.indexOf("CNCSystem")>=0){
            $scope.navActive=1;
        }
        else if(statename.indexOf("FeedSystem")>=0){
            switch(toParams.FeedSystemType){
                case "XY":
                    $scope.navActive=2;
                    break;
                case "X":
                    $scope.navActive=3;
                    break;
                case "Y":
                    $scope.navActive=4;
                    break;
                case "Z":
                    $scope.navActive=5;
                    break;
                default:
                    break;
            }
        }
    });

    //监控子作用域传播来的事件，并初始化侧边栏中的进给轴部件
    $scope.$on('ComponentChange',function(event,data){
        var Component=$locals.getObject(data);
        onComponentChange(data,Component.TypeID,Component.Manufacturer,Component.img);
    });
    
    //更新侧边栏
    function onComponentChange(data,ID,Manu,img){
        angular.element(document.getElementById(data+"Check")).removeClass('glyphicon-unchecked');
        angular.element(document.getElementById(data+"Check")).addClass('glyphicon-check');
        angular.element(document.getElementById(data + "Img")).attr("src", "../../Areas/Selection/AppSelection/imgs/" + img);
        angular.element(document.getElementById(data+"ID")).text(ID);
        angular.element(document.getElementById(data+"Manu")).text(Manu);
        angular.element(document.getElementById(data+"Num")).text(1);
    }
    //初始化侧边栏
    function onComponentReset(data){
        angular.element(document.getElementById(data+"Check")).removeClass('glyphicon-check');
        angular.element(document.getElementById(data+"Check")).addClass('glyphicon-unchecked');
        angular.element(document.getElementById(data + "Img")).attr("src", "../../Areas/Selection/AppSelection/imgs/loading.jpg");
        angular.element(document.getElementById(data+"ID")).text("未选择");
        angular.element(document.getElementById(data+"Manu")).text("");
        angular.element(document.getElementById(data+"Num")).text(0);
    }
    function resetSide(){
        var CNCTypec=$locals.getObject("CNCType");
        if(CNCTypec)
        {
            onComponentChange("CNCType",CNCTypec.type,CNCTypec.support,CNCTypec.img);
        }
        else
            return;

        var CNCSystemc=$locals.getObject("CNCSystem");
        if(CNCSystemc)
            onComponentChange("CNCSystem",CNCSystemc.TypeID,CNCSystemc.Manufacturer,CNCSystemc.img);
        else
            onComponentReset("CNCSystem");

        var feedSide=new Array("XY","X","Y","Z");
        var ComponentSide=new Array("Guide","Ballscrew","Bearings","Coupling","Motor","Driver");
        for(var i=0;i<feedSide.length;++i)
        {
            for(var j=0;j<ComponentSide.length;++j)
            {
                var cookiesAddr=feedSide[i]+ComponentSide[j];
                var Componentc=$locals.getObject(cookiesAddr);
                if(Componentc){
                    onComponentChange(cookiesAddr,Componentc.TypeID,Componentc.Manufacturer,Componentc.img);}
                else
                    onComponentReset(cookiesAddr);
            }
        }
    }
});

//机床类型控制器
controllers.controller("CNCTypeCtrl",function($scope,$state,$locals){
	$scope.type=-1;
	$scope.support="";
	//点击图片显示图片被选中
	$scope.imgClick=function(type,support){
		$scope.type=type;
		$scope.support=support;
	};
	//点击下一步按钮将机床类型存入cookies键为CNCType中
	$scope.nextStep=function(){
		var CNCType=["立式车床","立式铣床","龙门铣床","卧式车床","卧式铣床","斜床身车床","磨床"];
		$locals.putObject("CNCType",{
            type:CNCType[$scope.type],
            support:$scope.support,
            img:CNCType[$scope.type]+".jpg",
        });
        $scope.$emit("CNCTypeChange");
		$state.go("CNCType.WorkingCondition");
	};
	//点击取消按钮恢复图片为未被选中状态
	$scope.reset=function(){
		$scope.type=-1;
		$scope.support="";
	};
});

//机床工作需求控制器
controllers.controller('CNCWorkingConditionCtrl', function ($scope,$state,$locals) {
    //负载性质选项绑定
    $scope.loadCharacterOptions=["无冲击","轻微冲击","有冲击或振动"];
    //点击下一步按钮，将工作需求数据存入cookie中，进入数控系统选型
    $scope.nextStep=function(){
        $locals.putObject("CNCWorkingCondition",{
            cuttingCondition:$scope.cuttingCondition,
            productCondition:$scope.productCondition,
        });
        $state.go("CNCSystem");
    };
    //点击取消按钮，初始化界面
    $scope.reset=function(){
        //切削条件
        $scope.cuttingCondition=[
            {
                lengthwaysForce:2000,
                verticalForce:1200,
                feedSpeed:0.6,
                timeScale:10,
            },
            {
                lengthwaysForce:1000,
                verticalForce:500,
                feedSpeed:0.8,
                timeScale:30,
            },
            {
                lengthwaysForce:500,
                verticalForce:200,
                feedSpeed:1,
                timeScale:50,
            },
            {
                lengthwaysForce:0,
                verticalForce:0,
                feedSpeed:15,
                timeScale:10,
            }];
        //工况
        $scope.productCondition={
            maxFeedSpeed:15,
            tableTravel:1000,
            productMaxMass:300,
            tableMass:100,
            productMaxHeight:400,
            loadCharacter:"无冲击",
            productMaxLength:400,
            feedAcceleration:1,
            productMaxWidth:400,
            spindleBoxMass:100,
            tableLength:1200,
            productStiffness:1150000000,
        };
    };
    $scope.reset();
});

//数控系统选型控制器
controllers.controller('CNCSystemTable', function ($scope,$http,$state,$locals,$data) {
	  //表头排序
     $scope.title="TypeID";
     $scope.desc=1;
     // 生产厂家选项绑定
     $scope.ManufacturerOptions=["华中数控","广州数控","沈阳高精","北京航天数控"];
     $scope.filtNum={
     	Manufacturer:null,
     	SupportNumberOfChannels:1,
     	MaxControlNumberOfFeedAxis:1,
     	SupportTypeOfMachine:$locals.getObject("CNCType").support,
     };
     //所选数控系统类型
     $scope.CNCSystemSelected={};
    
     //从服务端获取数据
    $http.get($data.http+'NCSystems')
      .then(function (response) {
          $scope.NCSystems = response.data;
      });
    //数控系统数据分页
    $scope.Page={
    	currentPage:1,
    	pageSize:10,
    };
    //单击表格选择数控系统型号
	$scope.Selected=function(CNCSystem){
        $scope.CNCSystemSelected=CNCSystem;//直接引用传递即可
	};
    //点击下一步按钮将数控系统类型存入$CNCSelected服务对象实例中
    $scope.nextStep=function(){
        var CNCSystem=$locals.getObject("CNCSystem");
        if(!CNCSystem){
            CNCSystem={};
        }
        $scope.CNCSystemSelected.img="CNCSystem/"+$scope.CNCSystemSelected.TypeID+".jpg";
        $locals.putObject("CNCSystem",$scope.CNCSystemSelected);
        $scope.$emit('ComponentChange',"CNCSystem");
        $state.go("CNCSystem.Accessories");
    };
    // 点击取消按钮恢复表格中选中行为未选中状态
    $scope.reset=function(){
        $scope.CNCSystemSelected={};
    };
});

//数控系统辅件选型控制器
controllers.controller("CNCSystemAccessoriesCtrl",function($scope,$state,$locals,$http,$data){
    $scope.controlTypeOptions=["全闭环","半闭环","开环"];
    $scope.IOUnit={
        controlType:"全闭环",
        baseboardId:"",
        baseboardNum:0,
        communicationboardId:"",
        communicationboardNum:0,
        IOModuleId:"",
        IOModuleNum:0,
        inputboardNum:0,
        outputboardNum:0,
    };
    $scope.UPSPower={
        isAdd:false,
        UPSId:"",
        UPSNum:0,
    };
    $scope.manul={
        isAdd:false,
        manulId:"",
        manulNum:0,
    }
    $scope.baseboardOptions=[];
    $scope.communicationboardOptions=[];
    $scope.IOModuleOptions=[];
    $scope.UPSOptions=[];
    $scope.manulOptions=[];
    //从服务端获取IO单元相关选项
    $http.get($data.http+"NCSystemIOUnits")
    .then(function(response){
        var IOUnits=response.data;
        for(var i=0;i<IOUnits.length;i++){
            if(IOUnits[i].Category=="底板"){
                $scope.baseboardOptions.push(IOUnits[i].TypeID);
            }
            else if(IOUnits[i].Category=="通讯"){
                $scope.communicationboardOptions.push(IOUnits[i].TypeID);
            }
            else if(IOUnits[i].Category="I/O"){
                $scope.IOModuleOptions.push(IOUnits[i].TypeID);
            }
        }
        $scope.IOUnit.baseboardId=$scope.baseboardOptions[0];
        $scope.IOUnit.communicationboardId=$scope.communicationboardOptions[0];
        $scope.IOUnit.IOModuleId=$scope.IOModuleOptions[0];
    });
    //从服务端获取UPS电源型号选项
    $http.get($data.http+"NCSystemPowerUnits")
    .then(function(response){
        var UPSPowers=response.data;
        for(var i=0;i<UPSPowers.length;i++){
            $scope.UPSOptions.push(UPSPowers[i].TypeID);
        }
        $scope.UPSPower.UPSId=$scope.UPSOptions[0];
    });
    //从服务端获取手操盘型号选项
    $http.get($data.http+"NCSystemManuals")
    .then(function(response){
        var manuls=response.data;
        for(var i=0;i<manuls.length;i++){
            $scope.manulOptions.push(manuls[i].TypeID);
        }
        $scope.manul.manulId=$scope.manulOptions[0];
    });
    //点击数字输入框增加按钮
    $scope.add=function(id){
        switch(id){
            case 0:
                $scope.IOUnit.baseboardNum=parseInt($scope.IOUnit.baseboardNum,10)+1;
                break;
            case 1:
                $scope.IOUnit.communicationboardNum=parseInt($scope.IOUnit.communicationboardNum,10)+1;
                break;
            case 2:
                $scope.IOUnit.IOModuleNum=parseInt($scope.IOUnit.IOModuleNum,10)+1;
                break;
            case 3:
                $scope.IOUnit.inputboardNum=parseInt($scope.IOUnit.inputboardNum,10)+1;
                break;
            case 4:
                $scope.IOUnit.outputboardNum=parseInt($scope.IOUnit.outputboardNum,10)+1;
                break;
            case 5:
                $scope.UPSPower.UPSNum=parseInt($scope.UPSPower.UPSNum,10)+1;
                break;
            case 6:
                $scope.manul.manulNum=parseInt($scope.manul.manulNum,10)+1;
                break;
            default:
                break;
        }
    };
    //点击数字输入框减少按钮
    $scope.minus=function(id){
        switch(id){
            case 0:
                if($scope.IOUnit.baseboardNum>=1){
                    $scope.IOUnit.baseboardNum=parseInt($scope.IOUnit.baseboardNum,10)-1;
                }
                break;
            case 1:
                 if($scope.IOUnit.communicationboardNum>=1){
                    $scope.IOUnit.communicationboardNum=parseInt($scope.IOUnit.communicationboardNum,10)-1;
                }
                break;
            case 2:
                if($scope.IOUnit.IOModuleNum>=1){
                    $scope.IOUnit.IOModuleNum=parseInt($scope.IOUnit.IOModuleNum,10)-1;
                }
                break;
            case 3:
                if($scope.IOUnit.inputboardNum>=1){
                    $scope.IOUnit.inputboardNum=parseInt($scope.IOUnit.inputboardNum,10)-1;
                }
                break;
            case 4:
                if($scope.IOUnit.outputboardNum>=1){
                    $scope.IOUnit.outputboardNum=parseInt($scope.IOUnit.outputboardNum,10)-1;
                }
                break;
            case 5:
                if($scope.UPSPower.UPSNum>=1){
                    $scope.UPSPower.UPSNum=parseInt($scope.UPSPower.UPSNum,10)-1;
                }
                break;
            case 6:
                 if($scope.manul.manulNum>=1){
                    $scope.manul.manulNum=parseInt($scope.manul.manulNum,10)-1;
                }
                break;
            default:
                break;
        }
    };
    //点击下一步按钮
    $scope.nextStep=function(){
        var CNCSystemAccessories={
            IOUnit:$scope.IOUnit,
            UPSPower:$scope.UPSPower,
            maunl:$scope.manul,
        };
        var CNCSystem=$locals.getObject("CNCSystem");
        if(!CNCSystem){
            CNCSystem={};
        }
        CNCSystem.CNCSystemAccessories=CNCSystemAccessories;
        $locals.putObject("CNCSystem",CNCSystem);
        var CNCSupport=$locals.getObject("CNCType").support;
        if(CNCSupport=="C"){
            $state.go("FeedSystem",{FeedSystemType:"XY"});
        }
        else if(CNCSupport=="X"){
            $state.go("FeedSystem",{FeedSystemType:"X"});
        }
    };
});

//进给系统列表控制器
controllers.controller("FeedSystemListCtrl",function($scope,$stateParams){
    $scope.feedSystemType=$stateParams.FeedSystemType;
    
});



