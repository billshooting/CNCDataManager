(function () {
    var app = angular.module("ServoMotorOfSpindle", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/ServoMotorOfSpindle/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/ServoMotorOfSpindle/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());