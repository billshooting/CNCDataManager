﻿var filters=angular.module("filters",[]);
//数控系统主过滤器
filters.filter("CNCSystemFilt",function(){
	return function(e,filtNum){
		var result=[];
		if(filtNum.Manufacturer!=null)
		{
			if(e!=null)
			for(var i=0;i<e.length;i++){
				if(e[i].Manufacturer==filtNum.Manufacturer
					&&e[i].SupportMachineType.indexOf(filtNum.SupportTypeOfMachine)>=0
					&&e[i].SupportChannels>=filtNum.SupportNumberOfChannels
					&&e[i].MaxNumberOfFeedShafts>=filtNum.MaxControlNumberOfFeedAxis){
					result.push(e[i]);
				}
			}
		}
		else
		{
			if(e!=null)
			for(var i=0;i<e.length;i++){
				if(e[i].SupportMachineType.indexOf(filtNum.SupportTypeOfMachine)>=0
					&&e[i].SupportChannels>=filtNum.SupportNumberOfChannels
					&&e[i].MaxNumberOfFeedShafts>=filtNum.MaxControlNumberOfFeedAxis){
					result.push(e[i]);
				}
			}
		}
		return result;
	}
});

//进给系统导轨主过滤器
filters.filter("LinnearRollingGuideFilt",function(){
	return function(e,rollerType,minLiveLoad,minStaticLoad){
		if(!e){
			return [];
		}
		var result=[];
		var rollerTypeOptions=["球滚子","圆柱滚子"];
		for(var i=0;i<e.length;i++){
			if(e[i].RollerType.indexOf(rollerTypeOptions[rollerType])>=0
				&&e[i].BasicRatedDynamicLoad_C>=(minLiveLoad*0.001)
				&&e[i].BasicRatedStaticLoad_C0>=(minStaticLoad*0.001)){
				result.push(e[i]);
			}
		}
		return result;
	}
});

//进给系统滚珠丝杠主过滤器
filters.filter("SolidBallScrewNutPairsFilt",function(){
	return function(e,caculation){
		if(!e){
			return [];
		}
		var result=[];
		for(var i=0;i<e.length;i++){
			if(e[i].NominalLead_Ph0>=caculation.lead
				&&e[i].BasicRatedDynamicLoad_Ca>=caculation.dynamicLoad
				&&e[i].BottomDiameterOfScrew_d2>=caculation.minDiameter){
				result.push(e[i]);
			}
		}
		return result;
	}
});

//进给系统轴承主过滤器
filters.filter("BearingsFilt",function() {
	return function(e,caculation,lubricationMethod){ 
		if(!e){
			return [];
		}
		var result=[];
		if(lubricationMethod=="脂润滑"){
			for(var i=0;i<e.length;i++){
				if(e[i].InnerDiameter_d>=caculation.bearingBoreDiameter
					&&e[i].BasicRatedDynamicLoad>=caculation.ratedDynamicLoad
					&&e[i].SpeedLimitOfGrease>=caculation.bearingLimitSpeed)
					result.push(e[i]);
			}
		}
		else{
			for(var i=0;i<e.length;i++){
				if(e[i].InnerDiameter_d>=caculation.bearingBoreDiameter
					&&e[i].BasicRatedDynamicLoad>=caculation.ratedDynamicLoad
					&&e[i].SpeedLimitOfOil>=caculation.bearingLimitSpeed)
					result.push(e[i]);
			}
		}
		return result;
	}
});

//进给系统联轴器主过滤器
filters.filter("CouplingFilt",function(){
	return function(e,caculation){
		if(!e){
			return [];
		}
		var result=[];
		for(var i=0;i<e.length;i++){
			if(e[i].AllowableRotationSpeed>=caculation.maxSpeed
				&&e[i].NominalTorque>=caculation.computedTorque*1000)
				result.push(e[i]);
		}
		return result;
	}
});

//进给系统伺服电机主过滤器
filters.filter("ServoMotorFilt",function(){
	return function(e,caculation){
		if(!e){
			return [];
		}
		var result=[];
		if(caculation.voltage.id==0)
		{
			for(var i=0;i<e.length;i++){
				if(e[i].Manufacturer==caculation.manufacturer
					&&e[i].MomentOfInertia*2>=caculation.loadInertia
					&&e[i].MomentOfInertia*2/3<=caculation.loadInertia
					&&e[i].RatedTorque>=caculation.loadTorque)
					result.push(e[i]);
			}
		}
		else
		{
			for(var i=0;i<e.length;i++){
				if(e[i].Manufacturer==caculation.manufacturer
					&&e[i].MomentOfInertia*2>=caculation.loadInertia
					&&e[i].MomentOfInertia*2/3<=caculation.loadInertia
					&&e[i].RatedTorque>=caculation.loadTorque
					&&e[i].WorkVoltage==caculation.voltage.id)
					result.push(e[i]);
			}
		}
		return result;
	}
});

//伺服驱动主过滤器
filters.filter("DriverFilt",function(){
	return function(e,caculation){
		if(!e){
			return [];
		}
		var result=[];
		for(var i=0;i<e.length;i++){
			if(e[i].Manufacturer==caculation.manufacturer.value
				&&e[i].ContinuousCurrent>=caculation.ratedCurrent
				&&e[i].SupplyVoltage==caculation.powerType.value)
				result.push(e[i]);
		}
		return result;
	}
});

//分页控件获取筛选后数组的长度
filters.filter("size",function(){
	return function(e){
		if(!e)
			return 0;
		return e.length;
	}
});

//分页控件获取每一页的数据
filters.filter("paging",function(){
	return function(e,currentPage,pageSize){
		if(!e)
			return [];
		var start=(currentPage-1)*pageSize;
		return e.slice(start,start+pageSize);
	}
});

//去除数组中的重复项
filters.filter("distinct",function(){
	return function(e){
		if(e){
			return [];
		}
		var result=[];
		var map={};
		var elem;
		for(var i=0;i<e.length;i++){
			elem=e[i];
			if(!map[elem]){
				result.push(elem);
				map[elem]=true;
			}
		}
		return result;
	}
});