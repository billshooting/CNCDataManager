var directives=angular.module("directives",[]);
directives.directive('tsList',function(){
	return {
		restrict:'EAC',
		templateUrl:'../../../../AppSelection/tpls/directivetemplate/tsList.html',
		scope:{
			imgsrc:'=iAttr',
			typeID:'=tAttr',
			manufacturer:'=mAttr',
			num:'=nAttr',
			id:'=idAttr',
			name:'=nameAttr',
		},
		transclude:true,
	};
});
