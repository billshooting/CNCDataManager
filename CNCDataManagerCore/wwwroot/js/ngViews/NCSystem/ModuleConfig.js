(function () {
    var app = angular.module("NCSystem", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/NCSystem/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/NCSystem/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());