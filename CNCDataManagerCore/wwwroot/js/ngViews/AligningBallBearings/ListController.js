
(function (app) {
    var ListController = function ($scope, $http, ApiUrl) {
        //1. scope模型初始化
        $scope.list = null;
        $scope.orderProperty = "TypeNo";
        $scope.colState = [true, true, false, true, false, false, false]; //控制是否显示
        $scope.colIfOrdered = { "TypeNo": "table-td-ordered", "Manufacturer": "", "InnerDiameter_d": "", "Diameter_D": "", "BasicRatedDynamicLoad": "", "BasicRatedStaticLoad": "" };

        //2. 显示初始化
        $(".overlay-container").css({ display: 'block' });//显示加载图标

        $http.get("http://cncdataapi.azurewebsites.net/api/cncdata/AligningBallBearings").then(
            function (response) {
                $scope.list = response.data;
                setTimeout(function () {
                $(".overlay-container").css({ display: 'none' });//关闭加载图标
            }, 500);          
            }, function (response) {
                $(".overlay-container >span").css({ display: 'inline' });
                $(".overlay-container >div").css({ display: 'none' });
                $(".overlay-container >h2").replaceWith("<h2>请求出错，请刷新重试。错误为：" + response.status.toString() + response.statusText.toString() + "</h2>");
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