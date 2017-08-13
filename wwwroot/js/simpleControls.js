//   simpleControls.js

(function () {
    "use strict";
    var module = angular.module("simpleControls", []);
    // DIRECTIVE: WAITCURSOR : a simple loading icon
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
    /*
    DIRECTIVE: DROPDOWN : dropdown component that exposes a hook to whatever action
    e.g doSomething(withSelectedParam)
    */
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
