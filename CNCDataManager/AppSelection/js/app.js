var selectionApp = angular.module("selectionApp", ["ui.router", "controllers"]);
selectionApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/CNCType');
    $stateProvider
        .state('CNCType', {
            url: '/CNCType',
            views: {
                '': {
                    templateUrl: '../../../../AppSelection/tpls/home.html'
                },
                'list@CNCType': {
                    templateUrl: '../../../../AppSelection/tpls/CNCType/CNCTypeList.html'
                },
                'table@CNCType': {
                    templateUrl: '../../../../AppSelection/tpls/CNCType/CNCTypeTable.html'
                }
            }
        })
      .state('CNCType.WorkingCondition',{
            url: '/WorkingCondition',
            views:{
                    'table@CNCType': {
                        templateUrl: '../../../../AppSelection/tpls/CNCType/CNCWorkingCondition.html'
                    }
             }
        })
        .state('CNCSystem', {
            url: '/CNCSystem',
            views: {
                '': {
                    templateUrl: '../../../../AppSelection/tpls/home.html'
                },
                'list@CNCSystem': {
                    templateUrl: '../../../../AppSelection/tpls/CNCSystem/CNCSystemList.html'
                },
                'table@CNCSystem': {
                    templateUrl: '../../../../AppSelection/tpls/CNCSystem/CNCSystemTable.html'
                }
            }
        })
        .state('CNCSystem.Accessories', {
            url: '/Accessories',
            views: {
                'table@CNCSystem': {
                    templateUrl: '../../../../AppSelection/tpls/CNCSystem/CNCSystemAccessories.html'
                }
            }
        })
        .state('FeedSystem', {
            url: '/FeedSystem',
            views: {
                '': {
                    templateUrl: '../../../../AppSelection/tpls/home.html'
                },
                'list@FeedSystem': {
                    templateUrl: '../../../../AppSelection/tpls/FeedSystem/FeedSystemList.html'
                },
                'table@FeedSystem':{
                    templateUrl: '../../../../AppSelection/tpls/FeedSystem/LinearRollingGuide/LinearRollingGuideTable.html'
                }
            }
        })
});