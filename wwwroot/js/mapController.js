(function () {
    "use strict";

    function mapController($rootScope, incidentApiService, appAnimations) {

        function initMap(year) {
            $rootScope.map = new google.maps.Map($("#map")[0], {
                zoom: 13,
                center: { lat: 39.043333, lng: -77.028333 },
                mapTypeId: "hybrid",
                tilt: 0
            });

            $rootScope.heatMap = new google.maps.visualization.HeatmapLayer({
                map: $rootScope.map,
                maxIntensity: 25,
                radius: 10
            });
            setMap(year);
        }


        var locationData = [];
        var markers = [];

        function setMap(year) {
            appAnimations.toggleMapLoaded();
            incidentApiService.latLngByYear(year)
                .then(onLocations)
                .finally(function () { buildMap(); });
        }

        var setMapLocations = function (filterParameters) {
            appAnimations.toggleMapLoaded();
            appAnimations.toggleFiltersSelected();
            incidentApiService.latLngByFilter(filterParameters)
                .then(onLocations)
                .finally(function () { buildMap(); });
        }

        function onLocations(locations) {
            locationData = locations;
            appAnimations.toggleMapLoaded();
        }

        function buildMap() {
            clearAllMapData();
            $rootScope.mapType === "heat" ? setHeatMapData() : setMarkerData();
        }

        function setHeatMapData() {
            var latLng = locationData.reduce(toGmapLatLng, []);
            $rootScope.heatMap.set("data", latLng);
        }

        function setMarkerData() {
            locationData.forEach((i) => {

                var marker = new google.maps.Marker({
                    position: { lat: i.lat, lng: i.lng },
                    title: i.id += "",
                    map: $rootScope.map
                });
                marker.addListener("click", function () {
                    showIncidentDataWindow(marker.title);
                });
                markers.push(marker);
            });
        }

        function clearAllMapData() {
            $rootScope.heatMap.set("data", null);
            markers.reduce((acc, cur) => cur.setMap(null), []);
            markers = [];
        }

        function toGmapLatLng(acc, cur) {
            acc.push(new google.maps.LatLng(cur.lat, cur.lng));
            return acc;
        }

        function showIncidentDataWindow(id) {
            incidentApiService.getIncidentDetails(id).then(onDetails);
        }

        function onDetails(incident) {
            var contentString =
                `<div id="content">
                    <div id= "siteNotice"></div>
                    <h2 id="firstHeading" class="firstHeading"> Incident # ${incident.incidentId.toString()} </h2>
                    <div id="bodyContent">
                        <b>Date & Time: </b> ${incident.dateTime} <br />
                        <b>Alcohol Involved: </b> ${incident.alcohol} <br />
                        <b>Fatal: </b> ${incident.fatal} <br />
                        <b>Seatbets Worn: </b> ${incident.seatBelts} <br />
                        <b>Description: </b> ${incident.description} <br />
                        <div>
                            <h4>Driver Information<h4>
                        </div>
                        <b>Race: </b> ${incident.driver.race} <br /> 
                        <b>Gender: </b> ${incident.driver.gender} <br />
                        <b>Licenese City, State: </b> ${incident.driver.city},  ${incident.driver.state} <br />
                        <div>
                            <h4>Vehicle Information<h4>
                        </div>
                        <b>Make: </b> ${incident.vehicle.make} <br />
                        <b>Model: </b>${incident.vehicle.model} <br />
                        <b>Color: </b> ${incident.vehicle.color} <br />
                    </div>
                </div>
            </div>`;



            //var contentString = '<div id="content">' +
            //    '<div id="siteNotice">' +
            //    '</div>' +
            //    '<h2 id="firstHeading" class="firstHeading"> Incident #' + incident.incidentId.toString() + '</h2>' +
            //    '<div id="bodyContent">' +

            //    '<b>Date & Time: </b>' +
            //    incident.dateTime + '<br />' +
            //    '<b>Alcohol Involved: </b>' +
            //    incident.alcohol + '<br />' +
            //    '<b>Fatal: </b>' +
            //    incident.fatal + '<br />' +

            //    '<b>Seatbets Worn: </b>' +
            //    incident.seatBelts + '<br />' +

            //    '<b>Description: </b>' +
            //    incident.description + '<br />' +

            //    '<div><h4>Driver Information<h4></div>' +

            //    '<b>Race: </b>' +
            //    incident.driver.race + '<br />' +

            //    '<b>Gender: </b>' +
            //    incident.driver.gender + '<br />' +

            //    '<b>Licenese City, State: </b>' +
            //    incident.driver.city + ', ' + incident.driver.state + '<br />' +

            //    '<div><h4>Vehicle Information<h4></div>' +

            //    '<b>Make: </b>' +
            //    incident.vehicle.make + '<br />' +

            //    '<b>Model: </b>' +
            //    incident.vehicle.model + '<br />' +

            //    '<b>Color: </b>' +
            //    incident.vehicle.color + '<br />' +

            //    '</div>' +
            //    '</div>' +
            //    '</div>';

            var infoWindow = new google.maps.InfoWindow({ content: contentString });
            var marker = {};
            for (var i = 0; i < markers.length; i++) {
                if (markers[i].title == incident.incidentId) marker = markers[i];
            }
            infoWindow.open($rootScope.map, marker);
        }



        return {
            initMap: initMap,
            setMap: setMap,
            setMapLocations: setMapLocations,
            showHeatMap: showHeatMap,
            buildMap: buildMap
        };

    }

    //Todo: add controls to the map displays
    //vm.adjustRadius = (val) => vm.heatmap.set("radius", vm.heatmap.get("radius") + val);

    //vm.adjustIntensity = (val) => {
    //    var current = vm.heatmap.get("maxIntensity");
    //    if (current + val >= 1) vm.heatmap.set("maxIntensity", current + val);
    //};


    var module = angular.module("app-violations");

    module.factory("mapController", mapController);

})();