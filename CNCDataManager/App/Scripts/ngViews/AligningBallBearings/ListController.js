
(function (app) {
    var ListController = function ($scope, $http) {
        $(".overlay-container").css({ display: 'block' });//显示加载图标

        $http.get("http://localhost:8000/api/AligningBallBearings").success(function (data) {
            $scope.list = data;
            setTimeout(function () {
                $(".overlay-container").css({ display: 'none' });//关闭加载图标
            }, 500);          
        });
    };

    ListController.$inject = ["$scope", "$http"];
    app.controller("ListController", ListController);
}(angular.module("AligningBallBearings")));