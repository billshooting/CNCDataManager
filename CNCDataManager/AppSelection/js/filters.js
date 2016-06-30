var filters=angular.module("filters",[]);
//数控系统主过滤器
filters.filter("CNCSystemFilt",function(){
	return function(e,filtNum){
		var result=[];
		if(filtNum.Manufacturer!=null)
		{
			if(e!=null)
			for(var i=0;i<e.length;i++){
				if(e[i].Manufacturer==filtNum.Manufacturer
					&&e[i].SupportTypeOfMachine.indexOf(filtNum.SupportTypeOfMachine)>=0
					&&e[i].SupportNumberOfChannels>=filtNum.SupportNumberOfChannels
					&&e[i].MaxControlNumberOfFeedAxis>=filtNum.MaxControlNumberOfFeedAxis){
					result.push(e[i]);
				}
			}
		}
		else
		{
			if(e!=null)
			for(var i=0;i<e.length;i++){
				if(e[i].SupportTypeOfMachine.indexOf(filtNum.SupportTypeOfMachine)>=0
					&&e[i].SupportNumberOfChannels>=filtNum.SupportNumberOfChannels
					&&e[i].MaxControlNumberOfFeedAxis>=filtNum.MaxControlNumberOfFeedAxis){
					result.push(e[i]);
				}
			}
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