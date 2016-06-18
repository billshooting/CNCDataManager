(function () {
    var app = angular.module("GearCoupling", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/GearCoupling/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/GearCoupling/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());