$.fn.isVisible = function(offset) {
	var rect = this[0].getBoundingClientRect();
	return (
		(rect.height > 0 || rect.width > 0) &&
		rect.bottom >= 0 &&
		rect.right >= 0 &&
		rect.top <= (window.innerHeight - offset || document.documentElement.clientHeight - offset) &&
		rect.left <= (window.innerWidth - offset || document.documentElement.clientWidth - offset)
	);
};


$.fn.timelify = function(options){

	var settings = $.extend({
		animLeft: "bounceInLeft",
		animRight: "bounceInRight",
		animCenter: "bounceInUp",
		animSpeed: 100,
		offset: 150
	}, options);

	var elem = this;

	var timeline_items = $(this).find('.timeline-items li');

	window.addEventListener('scroll', function(){
		var scrollPos = $(window).scrollTop();
        if ($('.timeline-items li.is-hidden').length > 0) {
            var count = $(elem).offset().top - 600;
			if(scrollPos > count){
                $(timeline_items).each(function () {
                    $(this).removeClass('is-hidden').slideDown(2000);
                    $(this).css("display", "block");
                    $(this).css("visibility", "visible");

					//if ($(this).isVisible(settings.offset)) {
					//	$(this).removeClass('is-hidden').addClass('animated').css({"animation-duration": settings.animSpeed + "ms"});
					//	if (!$(this).hasClass('inverted')) {
					//		if ($(this).hasClass('centered')) {
					//			$(this).addClass(settings.animCenter)
					//		} else {
					//			$(this).addClass(settings.animLeft)
					//		}
					//	} else {

					//		$(this).addClass(settings.animRight)

					//	}
					//}
				});
			}
		}


	});

	return this;
};