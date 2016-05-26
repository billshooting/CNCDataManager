(function () {
    var app = angular.module("AngularContactBallBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/AngularContactBallBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/AngularContactBallBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());