var carousel = $('.carousel');
var hPrice = $('#hPrice');

carousel.carousel({
    interval: false
});

carousel.on("click", ".carousel-control-next", function () {
    carousel.carousel('prev');
});

carousel.on("click", ".carousel-control-prev", function () {
    carousel.carousel('next');
});

carousel.on("click", "li", function () {
    var slideNumber = parseInt($(this).attr("data-slide-to"));
    carousel.carousel(slideNumber);
});

