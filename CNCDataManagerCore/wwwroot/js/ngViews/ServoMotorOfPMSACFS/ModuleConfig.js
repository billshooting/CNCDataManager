(function () {
    var app = angular.module("ServoMotorOfPMSACFS", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/ServoMotorOfPMSACFS/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/ServoMotorOfPMSACFS/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());