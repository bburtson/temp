//   simpleControls.js

(function () {
    "use strict";

    var module = angular.module("simpleControls", []);

    module.directive("waitCursor", waitCursor);

    function waitCursor() {

        return {
            scope: {
                show: "=displayWhen"
            },
            restrict: "A",
            templateUrl: "/views/components/waitCursor.html"
        };
    }

    module.directive("dropDownComponent", dropDownComponent);

    function dropDownComponent() {

        return {
            scope: {
                value:"=value",
                options: "=optionData",
                action:"=action"

            },
            restrict: "E",
            templateUrl: "/views/components/dropDownComponent.html"
        };
    }

})();