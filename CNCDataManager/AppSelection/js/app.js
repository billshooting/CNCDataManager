var selectionApp = angular.module("selectionApp", ["ui.router","ui.bootstrap","ngCookies","controllers","directives","filters","services","LinnearRollingGuideTableCtrl","LinnearRollingGuideDetailCtrl","SolidBallScrewNutPairsTableCtrl","SolidBallScrewNutPairsDetailCtrl"]);

selectionApp.run(function($rootScope, $state, $stateParams) {
    $rootScope.$state = $state;
    $rootScope.$stateParams = $stateParams;
});

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
            url: '/FeedSystem/{FeedSystemType}',
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
        .state('FeedSystem.detail',{
            url:'/detail/{id}',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../../../AppSelection/tpls/FeedSystem/LinearRollingGuide/LinearRollingGuideDetail.html'
                }
            }
        })
        .state('FeedSystem.SolidBallScrewNutPairs',{
            url:'/SolidBallScrewNutPairs',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../../../AppSelection/tpls/FeedSystem/SolidBallScrewNutPairs/SolidBallScrewNutPairsTable.html'
                }
            }
        })
        .state('FeedSystem.SolidBallScrewNutPairs.detail',{
            url:'/detail/{id}',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../../../AppSelection/tpls/FeedSystem/SolidBallScrewNutPairs/SolidBallScrewNutPairsDetail.html'
                }
            }
        })
        .state('FeedSystem.Bearings',{
            url:'/Bearings',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../../../AppSelection/tpls/FeedSystem/Bearings/BearingsTable.html'
                }
            }
        })
        .state('FeedSystem.Coupling',{
            url:'/Coupling',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../../../AppSelection/tpls/FeedSystem/Coupling/CouplingTable.html'
                }
            }
        })
        .state('FeedSystem.ServoMotor',{
            url:'/ServoMotor',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../../../AppSelection/tpls/FeedSystem/ServoMotor/ServoMotorTable.html'
                }
            }
        })
        .state('FeedSystem.Driver',{
            url:'/Driver',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../../../AppSelection/tpls/FeedSystem/Driver/DriverTable.html'
                }
            }
        })
});