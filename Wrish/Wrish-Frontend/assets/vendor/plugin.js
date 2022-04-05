//Owl-Carousel Wrish-Slider
var wrish_slider = $(document).ready(function () {
  $(".owl-theme").owlCarousel({
    items: 1,
    loop: true,
    nav: true,
    dots: true,
    autoplay: true,
    autoplaySpeed: 1000,
    smartSpeed: 1000,
    autoplayHoverPause: true,
    responsive: {
      0: {
        items: 1,
        nav: false,
      },
      600: {
        items: 1,
        nav: false,
      },
      1000: {
        items: 1,
        nav: true,
      },
    },
  });
  //Owl-Brand Section
  $(".owl-brand").owlCarousel({
    items: 4,
    loop: true,
    nav: true,
    dots: false,
    autoplay: true,
    autoplaySpeed: 1000,
    scrollPerPage: true,
    autoplayHoverPause: true,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 2,
        slideBy: 1,
      },
      900: {
        items: 3,
        slideBy: 2,
      },
      1000: {
        items: 4,
        slideBy: 3,
      },
    },
  });
  //Owl-Arrivals Section
  $(".owl-arrivals").owlCarousel({
    items: 4,
    loop: true,
    nav: true,
    dots: false,
    autoplayHoverPause: true,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 2,
      },
      900: {
        items: 3,
      },
      1000: {
        items: 4,
      },
    },
  });
  $(".owl-related").owlCarousel({
    items: 4,
    loop: true,
    nav: true,
    dots: false,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 2,
      },
      900: {
        items: 3,
      },
      1000: {
        items: 4,
      },
    },
  });
  //Owl-Instagram Section
  $(".owl-instagram").owlCarousel({
    items: 4,
    loop: true,
    nav: false,
    dots: false,
    autoplayHoverPause: true,
    responsive: {
      0: {
        items: 3,
      },
      600: {
        items: 4,
      },
      900: {
        items: 4,
      },
      1000: {
        items: 6,
      },
    },
  });
  //OWL-FEEDBACK
  $(".owl-feedback").owlCarousel({
    items: 4,
    loop: true,
    nav: true,
    dots: true,
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 1,
      },
      900: {
        items: 1,
      },
      1000: {
        items: 1,
      },
    },
  });
});

//flex slider
console.log("salam");
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
