(function () {
    var app = angular.module("FlexiblePinCoupling", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/FlexiblePinCoupling/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/FlexiblePinCoupling/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());