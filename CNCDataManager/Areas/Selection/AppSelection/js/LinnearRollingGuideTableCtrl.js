var LinnearRollingGuideTableCtrl=angular.module("LinnearRollingGuideTableCtrl",[]);
//直线导轨选型控制器
LinnearRollingGuideTableCtrl.controller("LinnearRollingGuideTableCtrl",function($scope,$stateParams,$locals,$http,$state,$data){
	$scope.FeedSystemType=$stateParams.FeedSystemType;
    $scope.guidTypeOptions=["滚动导轨","滑动导轨"];
	$scope.rollerTypeOptions=[{id:0,name:"球滚子"},{id:1,name:"圆柱滚子"}];
    var CNCWorkingCondition=$locals.getObject("CNCWorkingCondition");
    //计算静载荷安全系数
    var safetyFactor={"无冲击":2,"轻微冲击":3,"有冲击或振动":5};
    //根据进给轴类型切换导轨尺寸图片
    if($scope.FeedSystemType=="XY"||$scope.FeedSystemType=="X"){
        $scope.imgsrc="../../Areas/Selection/AppSelection/imgs/立铣水平上导轨.jpg";
    }
    else if($scope.FeedSystemType=="Y"){
        $scope.imgsrc="../../Areas/Selection/AppSelection/imgs/立铣水平下导轨.jpg";
    }
    else if($scope.FeedSystemType=="Z"){
        $scope.imgsrc="../../Areas/Selection/AppSelection/imgs/立铣Z轴导轨.jpg";
    }
     //计算导轨加工轴最小静载荷，即X轴或XY轴
    var computeWorkingAxisMinStaticLoad=function(){
        var w1=9.8*CNCWorkingCondition.productCondition.productMaxMass;
        var w2=9.8*CNCWorkingCondition.productCondition.tableMass;
        var a=CNCWorkingCondition.productCondition.productMaxLength;
        var b=CNCWorkingCondition.productCondition.productMaxWidth;
        var c=CNCWorkingCondition.productCondition.productMaxHeight;
        var l0=$scope.sizePara.sizeL0;
        var l1=$scope.sizePara.sizeL1;
        var l6=$scope.sizePara.sizeL2;
        var l9=$scope.sizePara.sizeL3;
        var l4=$scope.sizePara.sizeL4;
        var l10=$scope.sizePara.sizeL5;
        var FA=CNCWorkingCondition.productCondition.feedAcceleration;
        var workLoads=new Array(4);
        //强力切削，一般切削，精切削
        for(var i=0;i<3;i++){
        	var LF=CNCWorkingCondition.cuttingCondition[i].lengthwaysForce;
        	workLoads[i]=new Array(8); 
        	workLoads[i][0]=Math.abs(0.125*LF*(1.0+a/l0-b/l1-4.0*(c+l9+l10)/l0+2.4*(l9+c)/l1)+0.25*(w1+w2));
        	workLoads[i][1]=Math.abs(0.125*LF*(1.0-a/l0-b/l1+4.0*(c+l9+l10)/l0+2.4*(l9+c)/l1)+0.25*(w1+w2));
        	workLoads[i][2]=Math.abs(0.125*LF*(1.0-a/l0+b/l1+4.0*(c+l9+l10)/l0-2.4*(l9+c)/l1)+0.25*(w1+w2));
        	workLoads[i][3]=Math.abs(0.125*LF*(1.0+a/l0+b/l1-4.0*(c+l9+l10)/l0-2.4*(l9+c)/l1)+0.25*(w1+w2));
        	workLoads[i][4]=Math.abs(0.25*LF*(2*(l4+0.5*b)/l0+0.60+1.20*a/l0));
        	workLoads[i][5]=Math.abs(0.25*LF*(0.60-1.20*a/l0-2*(l4+0.5*b)/l0));
        	workLoads[i][6]=workLoads[i][5];
        	workLoads[i][7]=workLoads[i][4];
        }
        //快速进给
        workLoads[3]=new Array(8);
        workLoads[3][0]=Math.abs(0.25*w1-w1*FA*l6/(19.6133*l0)+0.25*w2-w2*FA*(l9+l10+0.5*c)/(19.6133*l0));
        workLoads[3][1]=Math.abs(0.25*w1+w1*FA*l6/(19.6133*l0)+0.25*w2+w2*FA*(l9+l10+0.5*c)/(19.6133*l0));
        workLoads[3][2]=workLoads[3][1];
        workLoads[3][3]=workLoads[3][0];
        workLoads[3][4]=Math.abs((w1+w2)*FA*l4/(19.6133*l0));
        workLoads[3][5]=workLoads[3][4];
        workLoads[3][6]=workLoads[3][4];
        workLoads[3][7]=workLoads[3][4];
        // 取所有静载荷中的最大值
        var maxworkLoads=workLoads[0][0];
        for(var i=0;i<4;i++){
        	for(var j=0;j<8;j++){
        		if(workLoads[i][j]>maxworkLoads){
        			maxworkLoads=workLoads[i][j];
        		}
        	}
        }
        $scope.guidPara.minStaticLoad=Math.round(maxworkLoads*$scope.guidPara.safety*1000)/1000;
    };
    //计算导轨支撑轴最小静载荷，即Y轴
    var computeSupportingAxisMinStaticLoad=function(){
    	var a=CNCWorkingCondition.productCondition.productMaxLength;
        var b=CNCWorkingCondition.productCondition.productMaxWidth;
        var c=CNCWorkingCondition.productCondition.productMaxHeight; 
        var l=CNCWorkingCondition.productCondition.tableTravel;
        var l0x=$scope.sizePara.sizeL0;
        var l1x=$scope.sizePara.sizeL1;
        var l7x=$scope.sizePara.sizeL2;
        var l12=$scope.sizePara.sizeL3;
        var l4x=$scope.sizePara.sizeL4;
        var l11=$scope.sizePara.sizeL5;
        var l6=$scope.sizePara.varL6;
        var l9=$scope.sizePara.varL9;
        var l10=$scope.sizePara.varL10;
        var w1=9.8*CNCWorkingCondition.productCondition.tableMass;
        var w2=9.8*CNCWorkingCondition.productCondition.productMaxMass;
        var w3=9.8*$scope.guidPara.XMass;
        var FA=CNCWorkingCondition.productCondition.feedAcceleration;
        var workLoads=new Array(4);
        //强力切削
        for(var i=0;i<3;i++){
        	var LF=CNCWorkingCondition.cuttingCondition[i].lengthwaysForce;
        	workLoads[i]=new Array(8);
        	workLoads[i][0]=Math.abs(0.125*LF*(1.0-(a+1)/l1x-b/l0x+4.0*(c+l9+l12)/l1x+2.4*(l9+c+l11+l12)/l0x)+0.25*(w1+w2+w3)-0.25*(w1+w2)*l/l1x);
        	workLoads[i][1]=Math.abs(0.125*LF*(1.0-(a+1)/l1x+b/l0x+4.0*(c+l9+l12)/l1x-2.4*(l9+c+l11+l12)/l0x)+0.25*(w1+w2+w3)-0.25*(w1+w2)*l/l1x);
        	workLoads[i][2]=Math.abs(0.125*LF*(1.0+(a+1)/l1x+b/l0x-4.0*(c+l9+l12)/l1x-2.4*(l9+c+l11+l12)/l0x)+0.25*(w1+w2+w3)+0.25*(w1+w2)*l/l1x);
        	workLoads[i][3]=Math.abs(0.125*LF*(1.0+(a+1)/l1x-b/l0x-4.0*(c+l9+l12)/l1x+2.4*(l9+c+l11+l12)/l0x)+0.25*(w1+w2+w3)+0.25*(w1+w2)*l/l1x);
        	workLoads[i][4]=Math.abs(0.25*LF*(1-b/l0x+1.2*(a/2+l6)/l1x));
        	workLoads[i][5]=Math.abs(0.25*LF*(1+b/l0x-1.2*(a/2+l6)/l1x));
        	workLoads[i][6]=workLoads[i][5];
        	workLoads[i][7]=workLoads[i][4];
        }
        workLoads[3]=new Array(8);
        workLoads[3][0]=Math.abs(0.25*w3*(1-2*FA*l7x/(9.8*l0x))+0.25*w1*(1-2*FA*(l6-l10+l11+l12)/(9.8*l0x))+0.25*w2*(1-2*FA*(l9+0.5*c+l11+l12)/(9.8*l0x)));
        workLoads[3][1]=Math.abs(0.25*w3*(1+2*FA*l7x/(9.8*l0x))+0.25*w1*(1+2*FA*(l6-l10+l11+l12)/(9.8*l0x))+0.25*w2*(1+2*FA*(l9+0.5*c+l11+l12)/(9.8*l0x)));
        workLoads[3][2]=workLoads[3][1];
        workLoads[3][3]=workLoads[3][0];
        workLoads[3][4]=Math.abs(0.5*FA*(w3*l4x/l0x+(w1+w2)*(0.5*l+l4x)/l0x)/9.8);
        workLoads[3][5]=workLoads[3][4];
        workLoads[3][6]=workLoads[3][4];
        workLoads[3][7]=workLoads[3][4];
        //取所有静载荷中的最大值
        var maxworkLoads=workLoads[0][0];
        for(var i=0;i<4;i++){
        	for(var j=0;j<8;j++){
        		if(workLoads[i][j]>maxworkLoads){
        			maxworkLoads=workLoads[i][j];
        		}
        	}
        }
        $scope.guidPara.minStaticLoad=Math.round(maxworkLoads*$scope.guidPara.safety*1000)/1000;
    };
    //计算导轨主轴最小静载荷，即Z轴
    var computeSpindleAxisMinStaticLoad=function(){
    	var a=CNCWorkingCondition.productCondition.productMaxLength;
        var b=CNCWorkingCondition.productCondition.productMaxWidth;
        var c=CNCWorkingCondition.productCondition.productMaxHeight;
        var l0=$scope.sizePara.sizeL0;
        var l1=$scope.sizePara.sizeL1;
        var l2=$scope.sizePara.sizeL2;
        var l5=$scope.sizePara.sizeL3;
        var l4=$scope.sizePara.sizeL4;
        var l7=$scope.sizePara.sizeL5;
        var l6=$scope.sizePara.sizeL6;
        var w1=9.8*CNCWorkingCondition.productCondition.tableMass;
        var w2=9.8*CNCWorkingCondition.productCondition.productMaxMass;
        var FA=CNCWorkingCondition.productCondition.feedAcceleration;
        var workLoads=new Array(4);
        //强力切削
        //强力切削
        for(var i=0;i<3;i++){
        	var LF=CNCWorkingCondition.cuttingCondition[i].lengthwaysForce;
        	var VF=CNCWorkingCondition.cuttingCondition[i].verticalForce;
        	workLoads[i]=new Array(8);
        	workLoads[i][0]=Math.abs(0.25*LF*(1+2*l2/l0+2*(l5+l6-l7)/l1)-0.5*VF*l5/l0+0.5*w1*l7/l0+0.5*w2*l5/l0);
        	workLoads[i][1]=Math.abs(0.25*LF*(1-2*l2/l0+2*(l5+l6-l7)/l1)+0.5*VF*l5/l0-0.5*w1*l7/l0-0.5*w2*l5/l0);
        	workLoads[i][2]=Math.abs(0.25*LF*(1-2*l2/l0-2*(l5+l6-l7)/l1)+0.5*VF*l5/l0-0.5*w1*l7/l0-0.5*w2*l5/l0);
        	workLoads[i][3]=Math.abs(0.25*LF*(1+2*l2/l0-2*(l5+l6-l7)/l1)-0.5*VF*l5/l0+0.5*w1*l7/l0+0.5*w2*l5/l0);
        	workLoads[i][4]=Math.abs(0.25*LF*(1+2*l2/l0)-0.5*VF*l4/l0+0.5*(w1+w2)*l4/l0);
        	workLoads[i][5]=Math.abs(0.25*LF*(1-2*l2/l0)+0.5*VF*l4/l0+0.5*(w1+w2)*l4/l0);
        	workLoads[i][6]=workLoads[i][5];
        	workLoads[i][7]=workLoads[i][4];
        }
        workLoads[3]=new Array(8);
        workLoads[3][0]=Math.abs(0.5*(w1*l7+w2*l5)*(1+FA/9.8)/l0);
        workLoads[3][1]=workLoads[3][0];
        workLoads[3][2]=workLoads[3][0];
        workLoads[3][3]=workLoads[3][0];
        workLoads[3][4]=Math.abs(0.5*(w1+w2)*l4*(1+FA/9.8)/l0);
        workLoads[3][5]=workLoads[3][4];
        workLoads[3][6]=workLoads[3][4];
        workLoads[3][7]=workLoads[3][4];
        //取所有静载荷中的最大值
        var maxworkLoads=workLoads[0][0];
        for(var i=0;i<4;i++){
        	for(var j=0;j<8;j++){
        		if(workLoads[i][j]>maxworkLoads){
        			maxworkLoads=workLoads[i][j];
        		}
        	}
        }
        $scope.guidPara.minStaticLoad=Math.round(maxworkLoads*$scope.guidPara.safety*1000)/1000;
    };
    //计算导轨加工轴最小动载荷,即X轴
    var computeWorkingAxisMinDynamicLoad=function(){
        var w1=9.8*CNCWorkingCondition.productCondition.productMaxMass;
        var w2=9.8*CNCWorkingCondition.productCondition.tableMass;
        var a=CNCWorkingCondition.productCondition.productMaxLength;
        var b=CNCWorkingCondition.productCondition.productMaxWidth;
        var c=CNCWorkingCondition.productCondition.productMaxHeight;
        var l0=$scope.sizePara.sizeL0;
        var l1=$scope.sizePara.sizeL1;
        var l6=$scope.sizePara.sizeL2;
        var l9=$scope.sizePara.sizeL3;
        var l4=$scope.sizePara.sizeL4;
        var l10=$scope.sizePara.sizeL5;
        var FA=CNCWorkingCondition.productCondition.feedAcceleration;
        var workLoads=new Array(4);
        //强力切削，一般切削，精切削
        for(var i=0;i<3;i++){
        	var LF=CNCWorkingCondition.cuttingCondition[i].lengthwaysForce;
        	workLoads[i]=new Array(8); 
        	workLoads[i][0]=Math.abs(0.125*LF*(1.0+a/l0-b/l1-4.0*(c+l9+l10)/l0+2.4*(l9+c)/l1)+0.25*(w1+w2));
        	workLoads[i][1]=Math.abs(0.125*LF*(1.0-a/l0-b/l1+4.0*(c+l9+l10)/l0+2.4*(l9+c)/l1)+0.25*(w1+w2));
        	workLoads[i][2]=Math.abs(0.125*LF*(1.0-a/l0+b/l1+4.0*(c+l9+l10)/l0-2.4*(l9+c)/l1)+0.25*(w1+w2));
        	workLoads[i][3]=Math.abs(0.125*LF*(1.0+a/l0+b/l1-4.0*(c+l9+l10)/l0-2.4*(l9+c)/l1)+0.25*(w1+w2));
        	workLoads[i][4]=Math.abs(0.25*LF*(2*(l4+0.5*b)/l0+0.60+1.20*a/l0));
        	workLoads[i][5]=Math.abs(0.25*LF*(0.60-1.20*a/l0-2*(l4+0.5*b)/l0));
        	workLoads[i][6]=workLoads[i][5];
        	workLoads[i][7]=workLoads[i][4];
        }
        //快速进给
        workLoads[3]=new Array(8);
        workLoads[3][0]=Math.abs(0.25*w1+0.25*w2);
        workLoads[3][1]=workLoads[3][0];
        workLoads[3][2]=workLoads[3][0];
        workLoads[3][3]=workLoads[3][0];
        workLoads[3][4]=Math.abs((w1+w2)*FA*l4/(19.6133*l0));
        workLoads[3][5]=workLoads[3][4];
        workLoads[3][6]=workLoads[3][4];
        workLoads[3][7]=workLoads[3][4];
        // 取所有静载荷中的最大值
        var maxLoads=new Array(4);
        for(var i=0;i<4;i++){
            maxLoads[i]=workLoads[i][0]+workLoads[i][4];
            for(var j=0;j<4;j++){
                if(workLoads[i][j]+workLoads[i][j+4]>maxLoads[i]){
                    maxLoads[i]=workLoads[i][j]+workLoads[i][j+4];
                }
            }
        }
        //求平均当量载荷和平均速度
        var averageLoad=0;
        var averageSpeed=0;
        var allTime=0;
        for(var i=0;i<4;i++){
            averageLoad+=maxLoads[i]*maxLoads[i]*maxLoads[i]*CNCWorkingCondition.cuttingCondition[i].feedSpeed*CNCWorkingCondition.cuttingCondition[i].timeScale;
            allTime+=CNCWorkingCondition.cuttingCondition[i].timeScale;
            averageSpeed+=CNCWorkingCondition.cuttingCondition[i].feedSpeed*CNCWorkingCondition.cuttingCondition[i].timeScale;
        }
        averageSpeed=averageSpeed/allTime;
        if($scope.guidPara.rollerType==0){
            var lifeIndex=3;
            var rollingElementFormIndex=50;
        }
        else{
            var lifeIndex=10/3;
            var rollingElementFormIndex=100;
        }
        averageLoad=Math.pow(averageLoad/100,1/3);
        $scope.guidPara.minLiveLoad=Math.round(averageLoad*$scope.guidPara.load*Math.pow($scope.guidPara.life*60*averageSpeed*0.001/rollingElementFormIndex,1/lifeIndex)/$scope.guidPara.contact*1000)/1000;
    };
    //计算导轨支撑轴最小动载荷，即Y轴
    var computeSupportingAxisMinDynamicLoad=function(){
        var a=CNCWorkingCondition.productCondition.productMaxLength;
        var b=CNCWorkingCondition.productCondition.productMaxWidth;
        var c=CNCWorkingCondition.productCondition.productMaxHeight; 
        var l=CNCWorkingCondition.productCondition.tableTravel;
        var l0x=$scope.sizePara.sizeL0;
        var l1x=$scope.sizePara.sizeL1;
        var l7x=$scope.sizePara.sizeL2;
        var l12=$scope.sizePara.sizeL3;
        var l4x=$scope.sizePara.sizeL4;
        var l11=$scope.sizePara.sizeL5;
        var l6=$scope.sizePara.varL6;
        var l9=$scope.sizePara.varL9;
        var l10=$scope.sizePara.varL10;
        var w1=9.8*CNCWorkingCondition.productCondition.tableMass;
        var w2=9.8*CNCWorkingCondition.productCondition.productMaxMass;
        var w3=9.8*$scope.guidPara.XMass;
        var FA=CNCWorkingCondition.productCondition.feedAcceleration;
        var workLoads=new Array(4);
        //强力切削
        for(var i=0;i<3;i++){
            var LF=CNCWorkingCondition.cuttingCondition[i].lengthwaysForce;
            workLoads[i]=new Array(8);
            workLoads[i][0]=Math.abs(0.125*LF*(1.0-(a+1)/l1x-b/l0x+4.0*(c+l9+l12)/l1x+2.4*(l9+c+l11+l12)/l0x)+0.25*(w1+w2+w3)-0.25*(w1+w2)*l/l1x);
            workLoads[i][1]=Math.abs(0.125*LF*(1.0-(a+1)/l1x+b/l0x+4.0*(c+l9+l12)/l1x-2.4*(l9+c+l11+l12)/l0x)+0.25*(w1+w2+w3)-0.25*(w1+w2)*l/l1x);
            workLoads[i][2]=Math.abs(0.125*LF*(1.0+(a+1)/l1x+b/l0x-4.0*(c+l9+l12)/l1x-2.4*(l9+c+l11+l12)/l0x)+0.25*(w1+w2+w3)+0.25*(w1+w2)*l/l1x);
            workLoads[i][3]=Math.abs(0.125*LF*(1.0+(a+1)/l1x-b/l0x-4.0*(c+l9+l12)/l1x+2.4*(l9+c+l11+l12)/l0x)+0.25*(w1+w2+w3)+0.25*(w1+w2)*l/l1x);
            workLoads[i][4]=Math.abs(0.25*LF*(1-b/l0x+1.2*(a/2+l6)/l1x));
            workLoads[i][5]=Math.abs(0.25*LF*(1+b/l0x-1.2*(a/2+l6)/l1x));
            workLoads[i][6]=workLoads[i][5];
            workLoads[i][7]=workLoads[i][4];
        }
        workLoads[3]=new Array(8);
        workLoads[3][0]=Math.abs(0.25*w3*(1-2*FA*l7x/(9.8*l0x))+0.25*w1*(1-2*FA*(l6-l10+l11+l12)/(9.8*l0x))+0.25*w2*(1-2*FA*(l9+0.5*c+l11+l12)/(9.8*l0x)));
        workLoads[3][1]=Math.abs(0.25*w3*(1+2*FA*l7x/(9.8*l0x))+0.25*w1*(1+2*FA*(l6-l10+l11+l12)/(9.8*l0x))+0.25*w2*(1+2*FA*(l9+0.5*c+l11+l12)/(9.8*l0x)));
        workLoads[3][2]=workLoads[3][1];
        workLoads[3][3]=workLoads[3][0];
        workLoads[3][4]=Math.abs(0.5*FA*(w3*l4x/l0x+(w1+w2)*(0.5*l+l4x)/l0x)/9.8);
        workLoads[3][5]=workLoads[3][4];
        workLoads[3][6]=workLoads[3][4];
        workLoads[3][7]=workLoads[3][4];
        // 取所有静载荷中的最大值
        var maxLoads=new Array(4);
        for(var i=0;i<4;i++){
            maxLoads[i]=workLoads[i][0]+workLoads[i][4];
            for(var j=0;j<4;j++){
                if(workLoads[i][j]+workLoads[i][j+4]>maxLoads[i]){
                    maxLoads[i]=workLoads[i][j]+workLoads[i][j+4];
                }
            }
        }
        //求平均当量载荷和平均速度
        var averageLoad=0;
        var averageSpeed=0;
        var allTime=0;
        for(var i=0;i<4;i++){
            averageLoad+=maxLoads[i]*maxLoads[i]*maxLoads[i]*CNCWorkingCondition.cuttingCondition[i].feedSpeed*CNCWorkingCondition.cuttingCondition[i].timeScale;
            allTime+=CNCWorkingCondition.cuttingCondition[i].timeScale;
            averageSpeed+=CNCWorkingCondition.cuttingCondition[i].feedSpeed*CNCWorkingCondition.cuttingCondition[i].timeScale;
        }
        averageSpeed=averageSpeed/allTime;
        if($scope.guidPara.rollerType==0){
            var lifeIndex=3;
            var rollingElementFormIndex=50;
        }
        else{
            var lifeIndex=10/3;
            var rollingElementFormIndex=100;
        }
        averageLoad=Math.pow(averageLoad/100,1/3);
        $scope.guidPara.minLiveLoad=Math.round(averageLoad*$scope.guidPara.load*Math.pow($scope.guidPara.life*60*averageSpeed*0.001/rollingElementFormIndex,1/lifeIndex)/$scope.guidPara.contact*1000)/1000;
    };
    //计算导轨主轴最小动载荷
    var computeSpindleAxisMinDynamicLoad=function(){
        var a=CNCWorkingCondition.productCondition.productMaxLength;
        var b=CNCWorkingCondition.productCondition.productMaxWidth;
        var c=CNCWorkingCondition.productCondition.productMaxHeight;
        var l0=$scope.sizePara.sizeL0;
        var l1=$scope.sizePara.sizeL1;
        var l2=$scope.sizePara.sizeL2;
        var l5=$scope.sizePara.sizeL3;
        var l4=$scope.sizePara.sizeL4;
        var l7=$scope.sizePara.sizeL5;
        var l6=$scope.sizePara.sizeL6;
        var w1=9.8*CNCWorkingCondition.productCondition.tableMass;
        var w2=9.8*CNCWorkingCondition.productCondition.productMaxMass;
        var FA=CNCWorkingCondition.productCondition.feedAcceleration;
        var workLoads=new Array(4);
        //强力切削
        //强力切削
        for(var i=0;i<3;i++){
            var LF=CNCWorkingCondition.cuttingCondition[i].lengthwaysForce;
            var VF=CNCWorkingCondition.cuttingCondition[i].verticalForce;
            workLoads[i]=new Array(8);
            workLoads[i][0]=Math.abs(0.25*LF*(1+2*l2/l0+2*(l5+l6-l7)/l1)-0.5*VF*l5/l0+0.5*w1*l7/l0+0.5*w2*l5/l0);
            workLoads[i][1]=Math.abs(0.25*LF*(1-2*l2/l0+2*(l5+l6-l7)/l1)+0.5*VF*l5/l0-0.5*w1*l7/l0-0.5*w2*l5/l0);
            workLoads[i][2]=Math.abs(0.25*LF*(1-2*l2/l0-2*(l5+l6-l7)/l1)+0.5*VF*l5/l0-0.5*w1*l7/l0-0.5*w2*l5/l0);
            workLoads[i][3]=Math.abs(0.25*LF*(1+2*l2/l0-2*(l5+l6-l7)/l1)-0.5*VF*l5/l0+0.5*w1*l7/l0+0.5*w2*l5/l0);
            workLoads[i][4]=Math.abs(0.25*LF*(1+2*l2/l0)-0.5*VF*l4/l0+0.5*(w1+w2)*l4/l0);
            workLoads[i][5]=Math.abs(0.25*LF*(1-2*l2/l0)+0.5*VF*l4/l0+0.5*(w1+w2)*l4/l0);
            workLoads[i][6]=workLoads[i][5];
            workLoads[i][7]=workLoads[i][4];
        }
        workLoads[3]=new Array(8);
        workLoads[3][0]=Math.abs(0.5*(w1*l7+w2*l5)*(1+FA/9.8)/l0);
        workLoads[3][1]=workLoads[3][0];
        workLoads[3][2]=workLoads[3][0];
        workLoads[3][3]=workLoads[3][0];
        workLoads[3][4]=Math.abs(0.5*(w1+w2)*l4*(1+FA/9.8)/l0);
        workLoads[3][5]=workLoads[3][4];
        workLoads[3][6]=workLoads[3][4];
        workLoads[3][7]=workLoads[3][4];
        // 取所有静载荷中的最大值
        var maxLoads=new Array(4);
        for(var i=0;i<4;i++){
            maxLoads[i]=workLoads[i][0]+workLoads[i][4];
            for(var j=0;j<4;j++){
                if(workLoads[i][j]+workLoads[i][j+4]>maxLoads[i]){
                    maxLoads[i]=workLoads[i][j]+workLoads[i][j+4];
                }
            }
        }
        //求平均当量载荷和平均速度
        var averageLoad=0;
        var averageSpeed=0;
        var allTime=0;
        for(var i=0;i<4;i++){
            averageLoad+=maxLoads[i]*maxLoads[i]*maxLoads[i]*CNCWorkingCondition.cuttingCondition[i].feedSpeed*CNCWorkingCondition.cuttingCondition[i].timeScale;
            allTime+=CNCWorkingCondition.cuttingCondition[i].timeScale;
            averageSpeed+=CNCWorkingCondition.cuttingCondition[i].feedSpeed*CNCWorkingCondition.cuttingCondition[i].timeScale;
        }
        averageSpeed=averageSpeed/allTime;
        if($scope.guidPara.rollerType==0){
            var lifeIndex=3;
            var rollingElementFormIndex=50;
        }
        else{
            var lifeIndex=10/3;
            var rollingElementFormIndex=100;
        }
        averageLoad=Math.pow(averageLoad/100,1/3);
        $scope.guidPara.minLiveLoad=Math.round(averageLoad*$scope.guidPara.load*Math.pow($scope.guidPara.life*60*averageSpeed*0.001/rollingElementFormIndex,1/lifeIndex)/$scope.guidPara.contact*1000)/1000;

    };
    //点击计算按钮，计算出相关计算结果
   	$scope.caculate=function(){
   		switch($scope.FeedSystemType){
   			case "XY":
   			case "X":
   				computeWorkingAxisMinStaticLoad();
                computeWorkingAxisMinDynamicLoad();
   				break;
   			case "Y":
   				computeSupportingAxisMinStaticLoad();
                computeSupportingAxisMinDynamicLoad();
   				break;
   			case "Z":
   				computeSpindleAxisMinStaticLoad();
                computeSpindleAxisMinDynamicLoad();
   				break;
   			default:
   				break;
   		}
   	};
    //绑定相关尺寸和导轨参数数据并计算得出结果
    $scope.reset=function(){
        if($scope.FeedSystemType=="XY"||$scope.FeedSystemType=="X"){
            $scope.sizePara={
                sizeL0:500,
                sizeL1:500,
                sizeL2:200,
                sizeL3:150,
                sizeL4:50,
                sizeL5:100,
                sizeL6:60,
            };
        }
        else if($scope.FeedSystemType=="Y"){
            $scope.sizePara={
                sizeL0:600,
                sizeL1:800,
                sizeL2:250,
                sizeL3:200,
                sizeL4:150,
                sizeL5:100,
                sizeL6:60,
                varL6:200,
                varL9:150,
                varL10:100,
            };
        }
        else if($scope.FeedSystemType=="Z"){
            $scope.sizePara={
                sizeL0:600,
                sizeL1:400,
                sizeL2:500,
                sizeL3:250,
                sizeL4:100,
                sizeL5:150,
                sizeL6:60,
            };
        }
        $scope.guidPara={
        	life:20000,
        	safety:safetyFactor[CNCWorkingCondition.productCondition.loadCharacter],
        	load:1.2,
        	contact:1.2,
            friction:0.003,
        	minStaticLoad:0,
        	minLiveLoad:0,
        	XMass:400,
        	rollerType:0,
            guidType:"滚动导轨",
        };
		$scope.caculate();
    };
    $scope.reset();
    $http.get($data.http+"LineRollingGuides")
    .then(function(response){
        $scope.LineRollingGuides=response.data;
    });
    //表头排序
    $scope.title="TypeID";
    $scope.desc=1;
    //分页操作
    $scope.Page={
        currentPage:1,
        pageSize:10,
    };
    //点击表格中任意一行选中
    $scope.selected=function(LineRollingGuide){
        $scope.LineRollingGuideSelected=LineRollingGuide;
    };
    //点击下一步按钮，将导轨数据保存到相应cookie中,并跳转到下一个页面
    $scope.nextStep=function(){
       /* var FeedSystem=$locals.getObject("FeedSystem"+$scope.FeedSystemType);
        if(!FeedSystem){
            FeedSystem={};
        };
        FeedSystem.LineRollingGuide=$scope.LineRollingGuideSelected;
        $locals.putObject("FeedSystem"+$scope.FeedSystemType,FeedSystem);*/
        $scope.LineRollingGuideSelected.guidType=$scope.guidPara.guidType;//将导轨类型存入cookies
        $scope.LineRollingGuideSelected.friction=$scope.guidPara.friction;//将库伦摩擦系数存入cookies
        $scope.LineRollingGuideSelected.img="Guide.jpg";
        $locals.putObject($scope.FeedSystemType+"Guide",$scope.LineRollingGuideSelected);
        $scope.$emit('ComponentChange',$scope.FeedSystemType+"Guide");
        $state.go("FeedSystem.SolidBallScrewNutPairs");
    };
    //点击取消按钮，取消表格行被选中状态
    $scope.cancel=function(){
        $scope.LineRollingGuideSelected={};
    };
});