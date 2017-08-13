//      app-violations.js

(function () {
    "use strict";
    //create module                  |  include as dependancy |
    angular.module("app-violations", ["simpleControls", "ngRoute",  "angular-loading-bar", "cfp.loadingBar"])
        .config(function ($routeProvider, cfpLoadingBarProvider) {
            $routeProvider.when("/", {
                controller: "mainController",
                controllerAs: "vm",
                templateUrl: "/views/mainView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });
           
            cfpLoadingBarProvider.parentSelector = "#loading-bar-container";
            cfpLoadingBarProvider.includeSpinner = false;
            cfpLoadingBarProvider.latencyThreshold = 300;
        });


})();