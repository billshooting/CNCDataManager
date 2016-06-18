(function () {
    var app = angular.module("SolidBallScrewNutPairs", ["ngRoute", "ngAnimate"]);

    var config = function ($routeProvider) {
        $routeProvider.when("/list", { templateUrl: "/App/ngViews/SolidBallScrewNutPairs/list.html" })
                      .when("detail/:id", { templateUrl: "/App/ngViews/SolidBallScrewNutPairs/detail.html" })
                      .otherwise({ redirectTo: "/list" });
    };

    app.config(config);
}());