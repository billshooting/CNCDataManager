(function () {
    var app = angular.module("SpurGear", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/SpurGear/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/SpurGear/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());