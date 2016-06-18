(function () {
    var app = angular.module("ElectricSpindle", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/ElectricSpindle/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/ElectricSpindle/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());