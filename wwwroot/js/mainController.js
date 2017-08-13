// violationsController.js

(function () {
    "use strict";

    angular.module("app-violations")
        .controller("mainController", mainController);

    function mainController($http, $rootScope, mapController, appAnimations) {

        var vm = this;
        $rootScope.mapType = "heat";
        vm.yearOptions = ["2012", "2013", "2014", "2015", "2016", "2017"];
        vm.raceOptions = ["No Filter", "Native American", "Asian", "Hispanic", "Black", "White", "Other"];
        vm.genderOptions = ["No Filter", "Male", "Female", "Undisclosed", "Unknown"];
        vm.fatalityOptions = ["No Filter", "Yes", "No"];
        vm.alcoholOptions = ["No Filter", "Yes", "No"];
        vm.violationTypeOptions = ["Citation", "Warning", "Unknown", "No Filter"];
        vm.selectedYear = "2017";
        vm.selectedRace = vm.raceOptions[0];
        vm.selectedGender = vm.genderOptions[0];
        vm.selectedFatality = vm.fatalityOptions[0];
        vm.selectedAlcohol = vm.alcoholOptions[0];
        vm.selectedViolationType = vm.violationTypeOptions[3];

        if (!$rootScope.map) mapController.initMap(vm.selectedYear);

        vm.selectYear = function (year) {
            vm.selectedYear = year;
            if ($rootScope.mapType !== "heat") {
                $rootScope.mapType = "heat";
                appAnimations.toggleMapTypeSelection();
            }
            mapController.setMap(year);
        };

        vm.selectRace = function (race) { vm.selectedRace = race; };

        vm.selectGender = function (gender) { vm.selectedGender = gender; };

        vm.selectFatality = function (fatality) { vm.selectedFatality = fatality; };

        vm.selectAlcohol = function (alcohol) { vm.selectedAlcohol = alcohol; };

        vm.selectViolationType = function (violationType) { vm.selectedViolationType = violationType; };

        vm.selectMapType = function (type) {
            if (type !== $rootScope.mapType) {
                appAnimations.toggleMapTypeSelection();
                $rootScope.mapType = type;
                mapController.buildMap();
            }
        };

        vm.submitFilters = function () {
            mapController.setMapLocations({
                year: vm.selectedYear,
                race: vm.selectedRace,
                gender: vm.selectedGender,
                fatal: vm.selectedFatality,
                alcohol: vm.selectedAlcohol,
                violationType: vm.selectedViolationType === "No Filter" ? 3 : vm.selectedViolationType
            });
        };
    }

})();