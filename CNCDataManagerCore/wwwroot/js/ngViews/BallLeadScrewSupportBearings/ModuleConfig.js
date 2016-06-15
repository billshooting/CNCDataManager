(function () {
    var app = angular.module("BallLeadScrewSupportBearings", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/BallLeadScrewSupportBearings/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/BallLeadScrewSupportBearings/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());