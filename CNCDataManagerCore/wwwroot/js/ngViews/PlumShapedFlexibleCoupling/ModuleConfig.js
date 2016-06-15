(function () {
    var app = angular.module("PlumShapedFlexibleCoupling", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/PlumShapedFlexibleCoupling/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/PlumShapedFlexibleCoupling/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());