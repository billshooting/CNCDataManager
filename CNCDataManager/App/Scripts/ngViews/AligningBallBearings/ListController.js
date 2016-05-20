
(function (app) {
    var ListController = function ($scope, $http) {
        $http.get("http://localhost:8000/api/AligningBallBearings").success(function (data) {
            $scope.list = data;
        });
    };

    ListController.$inject = ["$scope", "$http"];
    app.controller("ListController", ListController);
}(angular.module("AligningBallBearings")));