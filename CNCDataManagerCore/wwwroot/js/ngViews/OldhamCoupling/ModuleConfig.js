(function () {
    var app = angular.module("OldhamCoupling", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/OldhamCoupling/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/OldhamCoupling/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());