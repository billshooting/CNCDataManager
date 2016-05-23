
(function (app) {
    var ListController = function ($scope, $http) {
        $(".overlay-container").css({ display: 'block' });//显示加载图标

        $scope.colState = [true, true, false, true, false, false, false];
        $http.get("http://localhost:8000/api/AligningBallBearings").success(function (data) {
            $scope.list = data;
            setTimeout(function () {
                $(".overlay-container").css({ display: 'none' });//关闭加载图标
            }, 500);          
        });

        //添加scope的处理方法
        //显示与取消表格列
        $scope.toggleCol = function (id) {
            if ($scope.colState[id]) {
                $scope.colState[id] = false;
                $(this).removeClass("cncdata-table-col-checked");
            }
            else {
                $scope.colState[id] = true;
                $(this).addClass("cncdata-table-col-checked");
            }
        };
    };

    ListController.$inject = ["$scope", "$http"];
    app.controller("ListController", ListController);
}(angular.module("AligningBallBearings")));