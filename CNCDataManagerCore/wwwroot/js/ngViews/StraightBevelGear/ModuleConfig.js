(function () {
    var app = angular.module("StraightBevelGear", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/StraightBevelGear/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/StraightBevelGear/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());