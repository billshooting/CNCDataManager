(function () {
    var app = angular.module("NeedleRollerAndThrustRollerBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/NeedleRollerAndThrustRollerBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/NeedleRollerAndThrustRollerBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());