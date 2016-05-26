(function () {
    var app = angular.module("AligningRollerBearing", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/AligningRollerBearing/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/AligningRollerBearing/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());