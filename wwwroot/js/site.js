/*              site.js                 */


(function () {


    var $sidebarAndWrapper = $("#sidebar,#wrapper");
    var $icon = $("#sidebartoggle i.fa");

    function spinIcon(initialT, animationT) {
        animationT = animationT + initialT;
        setTimeout(function () {
            $icon.toggleClass('slow-spin');

        }, initialT);

        setTimeout(function () {
            $icon.toggleClass('slow-spin');
            if ($sidebarAndWrapper.hasClass('hide-sidebar')) {

                $icon.removeClass("fa-arrow-circle-o-left");
                $icon.addClass("fa-arrow-circle-o-right");
            } else {
                $icon.addClass("fa-arrow-circle-o-left");
                $icon.removeClass("fa-arrow-circle-o-right");
            }
        }, animationT);
    }


    $("#sidebartoggle").on("click", function () {
        $sidebarAndWrapper.toggleClass('hide-sidebar');
        spinIcon(150, 475);
    });

    $('#you-are-here').on('mousedown', /** @param {!jQuery.Event} event */
        function (event) {
            event.preventDefault();
        });

    if ($(window).width() > 650 &&
        $("#crumb span").text() === "Home") {
        setTimeout(function () {
            $sidebarAndWrapper.toggleClass('hide-sidebar');
            spinIcon(150, 475);
        }, 300);
    }


    

})();
