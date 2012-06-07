//后台切换
jQuery(function ($) {
    $('.tag li').each(function () {
        var tabt = $('.tag li');
        var box = $('.tab-box');

        tabt.click(function () {
            var index = tabt.index(this);
            tabt.not(this).removeClass('current');
            $(this).addClass('current');

            box.not(':eq(' + index + ')').hide();
            box.eq(index).show();
        });

        var curr = tabt.filter('.current');
        if (!curr[0]) {
            curr = tabt.eq(0);
        } else {

        }
        curr.triggerHandler('click');
    });
});