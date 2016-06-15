(function () {
    var app = angular.module("HubShapedCouplings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/HubShapedCouplings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/HubShapedCouplings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());