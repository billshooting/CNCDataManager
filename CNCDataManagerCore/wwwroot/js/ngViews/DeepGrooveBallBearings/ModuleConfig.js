(function () {
    var app = angular.module("DeepGrooveBallBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/DeepGrooveBallBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/DeepGrooveBallBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());