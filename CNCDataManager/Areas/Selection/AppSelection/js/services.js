var services=angular.module("services",[]);
//service自定义服务保存可能变动的网址前缀
services.service("$data", function(){
	this.http="http://cncdataapi.azurewebsites.net/api/cncdata/";
});
//value自定义服务保存计算中没有提供参数时的默认值
services.value("$default",{
	guideFriction:0.003,   //导轨库伦摩擦系数
	guideSealingResistance:100,   //滚动导轨的密封阻力
	guideType:"滚动导轨",
	ballscrewShaftDia:24,   //滚珠丝杠联轴器配合轴孔直径
	ballscrewMaxSpeed:8000,   //滚珠丝杠极限转速
	ballscrewAccuracyClass:1,   //滚珠丝杠精度等级
	ballscrewLead:5,   //滚珠丝杠计算结果导程
});
