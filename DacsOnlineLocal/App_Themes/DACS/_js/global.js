/* ============================================================
Add .last-child/.first-child class to columns
============================================================ */
(function () {
    $(':first-child').addClass('first-child');
    $(':last-child').addClass('last-child');
})();


/* ============================================================
Scroll to top
============================================================ */
(function () {
    $('a[href=#top]').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 'slow');
        return false;
    });
})();


/* ============================================================
Don't scroll to top of page when clicing tooltips
============================================================ */
(function () {
    $('a.tip').click(function () {
        return false;
    });
})();


/* ============================================================
Toggle search result details
============================================================ */
(function () {
    $('ol.results a.toggle').toggle(function () {
        $(this).html('Less info');
        $(this).parent().parent().next().show();
    }, function () {
        $(this).html('More info');
        $(this).parent().parent().next().hide();
    });
})();


/* ============================================================
Add container around iframe embeds to enable CSS fix.
http://webdesignerwall.com/tutorials/css-elastic-videos
============================================================ */
(function () {
    $("iframe[src*='http://youtube.com']").wrap("<div class='object youtube'></div>");
})();


/* ============================================================
Add date picker UI to input.date
============================================================ */
(function () {
    $("input.date").datepicker({
        firstDay: 1,
        dateFormat: 'd MM yy'
    });
})();


/* ============================================================
Navigation menu
============================================================ */
(function () {
    var $banner = $('.banner'),
        $menu = $('#global-navigation'),
        $search = $('.global-search');

    $('.banner .global-search').before('<ul class="toggle-navigation"><li class="toggle-menu"><a href="#">Main Menu</a></li><li class="toggle-search"><a href="#">Search</a></li></ul>');
    $('.banner p.title').after('<ul class="toggle-navigation"><li class="toggle-menu"><a href="#">Main Menu</a></li></ul>');

    //$menu.addClass('hide');
    $('li.toggle-menu a').on('click', function () {
        $banner.toggleClass('show-menu');
        $banner.removeClass('show-search');
        return false;
    });

    //$search.addClass('hide');
    $('li.toggle-search a').on('click', function () {
        $banner.toggleClass('show-search');
        $banner.removeClass('show-menu');
        return false;
    });
})();


/* ============================================================
Section navigation
============================================================ */
(function () {
    $('li.children span').click(function () {
        $(this).siblings().toggle();
    });
})();


/* ============================================================
Reveal lightbox
============================================================ */
(function () {
    $('.show-modal').click(function () {
        $('.lightbox').show();
        return false;
    });

    $('.hide-modal').click(function () {
        $('.lightbox').hide();
        return false;
    });
})();