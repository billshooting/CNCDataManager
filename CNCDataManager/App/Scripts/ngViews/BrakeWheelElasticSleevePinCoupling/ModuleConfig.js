(function () {
    var app = angular.module("BrakeWheelElasticSleevePinCoupling", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/BrakeWheelElasticSleevePinCoupling/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/BrakeWheelElasticSleevePinCoupling/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());