(function () {
    var app = angular.module("CommonCylindricalWormGear", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/CommonCylindricalWormGear/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/CommonCylindricalWormGear/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());