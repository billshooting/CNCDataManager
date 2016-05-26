(function () {
    var app = angular.module("StepperMotor", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/StepperMotor/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/StepperMotor/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());