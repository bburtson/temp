(function () {
    "use strict";

    var incidentApiService = function ($http, $rootScope) {

        var latLngByYear = function (year) {
            return $http.get("/api/incident/latlng/" + year)
                .then(function (response) {
                    $rootScope.errorMessage = "";
                    return response.data;
                }, function (error) {
                    $rootScope.errorMessage = "ERR" + error.data;
                });
        };
        var latLngByFilter = function (filterParams) {
            return $http.post("/api/incident/filter", filterParams)
                .then(function (response) {
                    console.log(response);
                    return response.data;
                }, function(error) {
                    console.log(error.data);
                });
        };

        var getIncidentDetails = function(id) {
            return $http.get("/api/incident/" + id)
                .then(function(response) {
                    return response.data;
                });
        };


        return {
            latLngByYear: latLngByYear,
            latLngByFilter: latLngByFilter,
            getIncidentDetails: getIncidentDetails
        }
    };


    var module = angular.module("app-violations");

    module.factory("incidentApiService", incidentApiService);


})();