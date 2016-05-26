(function () {
    var app = angular.module("ElasticSleevePinCoupling", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/ElasticSleevePinCoupling/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/ElasticSleevePinCoupling/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());