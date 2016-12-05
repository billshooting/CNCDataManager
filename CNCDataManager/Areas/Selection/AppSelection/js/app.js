var selectionApp = angular.module("selectionApp", ["ui.router","ui.bootstrap","ngCookies","ngAnimate","controllers",
    "directives","filters","services","LinnearRollingGuideTableCtrl","LinnearRollingGuideDetailCtrl",
    "SolidBallScrewNutPairsTableCtrl","SolidBallScrewNutPairsDetailCtrl","BearingsTableCtrl",
    "BearingsDetailCtrl","CouplingTableCtrl","CouplingDetailCtrl","ServoMotorTableCtrl",
    "ServoMotorDetailCtrl","DriverTableCtrl","DriverDetailCtrl"]);

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
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/home.html'
                },
                'list@CNCType': {
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/CNCType/CNCTypeList.html'
                },
                'table@CNCType': {
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/CNCType/CNCTypeTable.html'
                }
            }
        })
      .state('CNCType.WorkingCondition',{
            url: '/WorkingCondition',
            views:{
                    'table@CNCType': {
                        templateUrl: '../../Areas/Selection/AppSelection/tpls/CNCType/CNCWorkingCondition.html'
                    }
             }
        })
        .state('CNCSystem', {
            url: '/CNCSystem',
            views: {
                '': {
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/home.html'
                },
                'list@CNCSystem': {
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/CNCSystem/CNCSystemList.html'
                },
                'table@CNCSystem': {
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/CNCSystem/CNCSystemTable.html'
                }
            }
        })
        .state('CNCSystem.Accessories', {
            url: '/Accessories',
            views: {
                'table@CNCSystem': {
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/CNCSystem/CNCSystemAccessories.html'
                }
            }
        })
        .state('FeedSystem', {
            url: '/FeedSystem/{FeedSystemType}',
            views: {
                '': {
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/home.html'
                },
                'list@FeedSystem': {
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/FeedSystemList.html'
                },
                'table@FeedSystem':{
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/LinearRollingGuide/LinearRollingGuideTable.html'
                }
            }
        })
        .state('FeedSystem.detail',{
            url:'/detail/{id}',
            views:{
                'table@FeedSystem':{
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/LinearRollingGuide/LinearRollingGuideDetail.html'
                }
            }
        })
        .state('FeedSystem.SolidBallScrewNutPairs',{
            url:'/SolidBallScrewNutPairs',
            views:{
                'table@FeedSystem':{
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/SolidBallScrewNutPairs/SolidBallScrewNutPairsTable.html'
                }
            }
        })
        .state('FeedSystem.SolidBallScrewNutPairs.detail',{
            url:'/detail/{id}',
            views:{
                'table@FeedSystem':{
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/SolidBallScrewNutPairs/SolidBallScrewNutPairsDetail.html'
                }
            }
        })
        .state('FeedSystem.Bearings',{
            url:'/Bearings',
            views:{
                'table@FeedSystem':{
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/Bearings/BearingsTable.html'
                }
            }
        })
        .state('FeedSystem.Bearings.detail',{
            url:'/detail/{type}/{id}',
            views:{
                'table@FeedSystem':{
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/Bearings/BearingsDetail.html'
                }
            }
        })
        .state('FeedSystem.Coupling',{
            url:'/Coupling',
            views:{
                'table@FeedSystem':{
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/Coupling/CouplingTable.html'
                }
            }
        })
        .state('FeedSystem.Coupling.detail',{
            url:'/detail/{type}/{id}',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../Areas/Selection/AppSelection/tpls/FeedSystem/Coupling/CouplingDetail.html'
                }
            }
        })
        .state('FeedSystem.ServoMotor',{
            url:'/ServoMotor',
            views:{
                'table@FeedSystem':{
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/ServoMotor/ServoMotorTable.html'
                }
            }
        })
        .state('FeedSystem.ServoMotor.detail',{
            url:'/detail/{id}',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../Areas/Selection/AppSelection/tpls/FeedSystem/ServoMotor/ServoMotorDetail.html'
                }
            }
        })
        .state('FeedSystem.Driver',{
            url:'/Driver',
            views:{
                'table@FeedSystem':{
                    templateUrl: '../../Areas/Selection/AppSelection/tpls/FeedSystem/Driver/DriverTable.html'
                }
            }
        })
        .state('FeedSystem.Driver.detail',{
            url:'/detail/{id}',
            views:{
                'table@FeedSystem':{
                    templateUrl:'../../Areas/Selection/AppSelection/tpls/FeedSystem/Driver/DriverDetail.html'
                }
            }
        })
});