(function () {
    var app = angular.module("CrossTaperedRollerBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/CrossTaperedRollerBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/CrossTaperedRollerBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());