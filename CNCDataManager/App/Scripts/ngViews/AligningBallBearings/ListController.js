
(function (app) {
    var ListController = function ($scope, $http) {
        //1. scope模型初始化
        $scope.list = null;
        $scope.orderProperty = "TypeNo";
        $scope.colState = [true, true, false, true, false, false, false]; //控制是否显示
        $scope.colIfOrdered = { "TypeNo": "table-td-ordered", "Manufacturer": "", "InnerDiameter_d": "", "Diameter_D": "", "BasicRatedDynamicLoad": "", "BasicRatedStaticLoad": "" };

        //2. 显示初始化
        $(".overlay-container").css({ display: 'block' });//显示加载图标

        $http.get("http://localhost:8000/api/AligningBallBearings").success(function (data) {
            $scope.list = data;
            setTimeout(function () {
                $(".overlay-container").css({ display: 'none' });//关闭加载图标
            }, 500);          
        });

        //3. 添加scope的处理方法
        //显示与取消表格列
        $scope.toggleCol = function (id, e) {
            if ($scope.colState[id]) {
                $scope.colState[id] = false;
                angular.element(e.currentTarget).removeClass("cncdata-table-col-checked");
            }
            else {
                $scope.colState[id] = true;
                angular.element(e.currentTarget).addClass("cncdata-table-col-checked");
            }
        };
        //对表格进行排序
        $scope.changeOrderProperty = function (property, e) {
            $scope.orderProperty = property;
            for(var key in $scope.colIfOrdered)
            {
                $scope.colIfOrdered[key] = "";
            }
            $scope.colIfOrdered[property] = "table-td-ordered";
        };
    };

    ListController.$inject = ["$scope", "$http"];
    app.controller("ListController", ListController);
}(angular.module("AligningBallBearings")));