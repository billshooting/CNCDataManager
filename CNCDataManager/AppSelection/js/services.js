var services=angular.module("services",[]);
services.service("$CNCType",function(){
	this.type="";//机床类型
	this.support="";//机床支持类型，C代表车床，X代表铣床
});
