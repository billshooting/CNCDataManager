
(function () {
    var app = angular.module("AligningBallBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/ngViews/AligingBallBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/ngViews/AligingBallBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
    app.constant("ApiUrl", "http://cncdataapi.azurewebsites.net/api/cncdata/")
}());