(function () {
    var app = angular.module("RotaryTable", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/RotaryTable/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/RotaryTable/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());