
$(window).on("load", function () {
    // The slider being synced must be initialized first
    $("#carousel").flexslider({
        animation: "slide",
        itemWidth: 210,
        itemMargin: 5,
        asNavFor: "#slider",
        minItems: 1,
        maxItems: 4,
    });

    $("#slider").flexslider({
        animation: "slide",
        controlNav: false,
        animationLoop: false,
        slideshow: false,
        sync: "#carousel",
    });


});