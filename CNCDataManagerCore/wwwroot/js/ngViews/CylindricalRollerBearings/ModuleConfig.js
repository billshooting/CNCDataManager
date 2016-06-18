(function () {
    var app = angular.module("CylindricalRollerBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/CylindricalRollerBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/CylindricalRollerBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());