(function () {
    var app = angular.module("FlangeCoupling", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/FlangeCoupling/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/FlangeCoupling/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());