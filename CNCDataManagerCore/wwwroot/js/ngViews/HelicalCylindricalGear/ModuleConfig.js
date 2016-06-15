(function () {
    var app = angular.module("HelicalCylindricalGear", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/HelicalCylindricalGear/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/HelicalCylindricalGear/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());