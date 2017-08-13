(function () {
    "use strict";
    var appAnimations = function ($timeout, cfpLoadingBar) {


        var $progressBar = $("#map-progress");
        var $map = $("#map");
        var $mapMenuToggle = $("#map-menu-toggle");
        var $mapMenu = $("#map-menu");


        function disableWithDelay() {
            $timeout(function () {
                $progressBar.css("z-index", -1);
            }, 500);
        };

        function toggleMapLoaded() {
            $mapMenu.toggleClass("hidden");
            $map.toggleClass("loaded");
            $progressBar.toggleClass("loaded");
            cfpLoadingBar.complete();
            $progressBar.hasClass("loaded") ? disableWithDelay() : $progressBar.css("z-index", 2);
        };

        $(document).ready(function () {
            $("#map-menu-toggle").on("click", function () {
                $("#map-menu-toggle").toggleClass("menu-open");
                $("#map-menu").toggleClass("menu-open");
            });
        });
        function toggleFiltersSelected() {
            $mapMenu.toggleClass("menu-open");
            $mapMenuToggle.toggleClass("menu-open");
        }

        function toggleMapTypeSelection() {
            
            $("#heatmap-toggle").toggleClass("btn-default");
            $("#heatmap-toggle").toggleClass("btn-info");
            $("#markermap-toggle").toggleClass("btn-default");
            $("#markermap-toggle").toggleClass("btn-info");
        }


        return {
            toggleMapLoaded: toggleMapLoaded,
            toggleFiltersSelected: toggleFiltersSelected,
            toggleMapTypeSelection: toggleMapTypeSelection
        };
    };



    var module = angular.module("app-violations");

    module.factory("appAnimations", appAnimations);

})();
