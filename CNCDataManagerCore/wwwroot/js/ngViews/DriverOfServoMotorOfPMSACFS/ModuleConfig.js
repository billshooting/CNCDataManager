(function () {
    var app = angular.module("DriverOfServoMotorOfPMSACFS", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/DriverOfServoMotorOfPMSACFS/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/DriverOfServoMotorOfPMSACFS/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());