(function () {
    var app = angular.module("LinearRollingGuide", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/LinearRollingGuide/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/LinearRollingGuide/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());