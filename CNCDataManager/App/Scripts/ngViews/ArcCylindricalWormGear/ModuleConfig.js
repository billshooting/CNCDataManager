(function () {
    var app = angular.module("ArcCylindricalWormGear", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/ArcCylindricalWormGear/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/ArcCylindricalWormGear/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());