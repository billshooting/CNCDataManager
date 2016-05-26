(function () {
    var app = angular.module("DoubleRowCylindricalRollerBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/DoubleRowCylindricalRollerBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/DoubleRowCylindricalRollerBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());