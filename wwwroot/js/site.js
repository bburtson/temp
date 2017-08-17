/*              site.js                 */
var $something;
var $goHere = $('#testing-lel');

(function () {
    $(document).ready(function () {
        var $sidebarAndWrapper = $("#sidebar,#wrapper");
        var $icon = $("#sidebartoggle i.fa");

        function spinIcon(initialT, animationT) {
            animationT = animationT + initialT;
            setTimeout(function () { $icon.toggleClass('slow-spin'); }, initialT);
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

        $('#you-are-here').on('mousedown', function (event) {
            event.preventDefault();
        });

        if ($(window).width() > 650 && $("#crumb span").text() === "Home") {
            setTimeout(function () {
                $sidebarAndWrapper.toggleClass('hide-sidebar');
                spinIcon(150, 475);
            }, 300);
        }

        const scrollItems = [
            'tic-tac-toe',
            'memory',
            'quote',
            'weather',
            'twitch',
            'tribute',
            'calculator',
            'wikipedia',
            'pomodoro',
            'workout',
            'traffic'
        ];

        for (let element of scrollItems) {
            $(`#scroll-to-${element}`).on('click', function (event) {
                event.preventDefault();
                $('body').stop().animate({
                    scrollTop: $(`#${element}`).offset().top - 70
                }, 500, 'swing');
            });
        }


        $('[id=scroll-to-top]').on('click', function () {
            $('body').stop().animate({
                scrollTop: 160
            });
        });
    });

})();
