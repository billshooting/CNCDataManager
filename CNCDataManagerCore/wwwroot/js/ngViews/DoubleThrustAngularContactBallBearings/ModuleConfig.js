(function () {
    var app = angular.module("DoubleThrustAngularContactBallBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/DoubleThrustAngularContactBallBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/DoubleThrustAngularContactBallBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());