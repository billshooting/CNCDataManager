(function () {
    var app = angular.module("TaperedRollerBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/TaperedRollerBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/TaperedRollerBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());