
(function () {
    var app = angular.module("AligningBallBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/AligingBallBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/AligingBallBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
    app.constant("ApiUrl", "localhost:8000/api/")
}());