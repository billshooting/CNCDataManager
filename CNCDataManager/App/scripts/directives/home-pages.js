﻿'use strict';

angular.module('cncdataManagerApp').directive('homeIndex',
    function () {
        return {
            templateUrl: '../App/views/home/index.html',
            restrict: 'E',
            scope: true,
            link: function (scope) { }
        };
    });

angular.module('cncdataManagerApp').directive('homeAbout',
    function () {
        return {
            templateUrl: '../App/views/home/about.html',
            restrict: 'E',
            scope: true,
            link: function (scope) { }
        };
    });

angular.module('cncdataManagerApp').directive('homeContact',
    function () {
        return {
            templateUrl: '../App/views/home/contact.html',
            restrict: 'E',
            scope: true,
            link: function (scope) { }
        };
    });