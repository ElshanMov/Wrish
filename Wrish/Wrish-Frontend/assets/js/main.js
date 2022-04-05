//////////////////Sidebar/////////////////////
const bars_icon = document.getElementsByClassName("bars-icon")[0];
const close_sidebar = document.getElementsByClassName("close-sidebar")[0];

bars_icon.onclick = function () {
  let sidebar = document.getElementById("sidebar");
  sidebar.classList.add("open");
};

close_sidebar.onclick = function () {
  let sidebar = document.getElementById("sidebar");
  sidebar.classList.remove("open");
};
/////////////////////////////////////////////
const search_icon = document.querySelectorAll(".search-icon");

search_icon.forEach(x => {
  x.addEventListener("click", function () {
    console.log(search_overlay_content.classList.toggle("search-visible"));
  });
});
///////////////////BasketBar/////////////////
const basket_icon = document.querySelectorAll(".basket-icon");

basket_icon.forEach(x => {
  x.addEventListener("click", function () {
    basketbar.classList.toggle("openbar");
  });
});

///////////////////Shop-Filter///////////////
const filter_icon = document.querySelectorAll(".filter-icon");
const sidebar_product = document.querySelector(".sidebar_product");
filter_icon.forEach(x => {
  x.addEventListener("click", function () {
    sidebar_product.classList.toggle("shop-ly-active");
  });
});

const size_item = document.querySelectorAll(".size-item");
size_item.forEach(x => {
  x.addEventListener("click", function () {
    size_item.forEach(x => {
      x.classList.remove("li-active");
    });
    this.classList.toggle("li-active");
  });
});
/////////////////////////////////////////////
jQuery(document).ready(function () {
  // This button will increment the value
  $('[data-quantity="plus"]').click(function (e) {
    // Stop acting like a button
    e.preventDefault();
    // Get the field name
    fieldName = $(this).attr("data-field");
    // Get its current value
    var currentVal = parseInt($("input[name=" + fieldName + "]").val());
    // If is not undefined
    if (!isNaN(currentVal)) {
      // Increment
      $("input[name=" + fieldName + "]").val(currentVal + 1);
    } else {
      // Otherwise put a 0 there
      $("input[name=" + fieldName + "]").val(0);
    }
  });
  // This button will decrement the value till 0
  $('[data-quantity="minus"]').click(function (e) {
    // Stop acting like a button
    e.preventDefault();
    // Get the field name
    fieldName = $(this).attr("data-field");
    // Get its current value
    var currentVal = parseInt($("input[name=" + fieldName + "]").val());
    // If it isn't undefined or its greater than 0
    if (!isNaN(currentVal) && currentVal > 0) {
      // Decrement one
      $("input[name=" + fieldName + "]").val(currentVal - 1);
    } else {
      // Otherwise put a 0 there
      $("input[name=" + fieldName + "]").val(0);
    }
  });
});
////////////////////////////////////////////////

let grids = document.querySelectorAll(".combin .grid");

grids.forEach(element => {
  element.addEventListener("click", function () {
    let gridActived = document.querySelector(".grid-active");
    gridActived.classList.remove("grid-active");
    element.firstElementChild.classList.add("grid-active");
    let collectionCards = document.querySelectorAll(".col-sep");

    if (element.classList.contains("grid-2x2")) {
      collectionCards.forEach(element => {
        element.classList.remove("col-lg-4");
        element.classList.add("col-lg-6");
        element.style.transition = "0.5s";
      });
    } else {
      collectionCards.forEach(element => {
        element.classList.remove("col-lg-6");
        element.classList.add("col-lg-4");
        element.style.transition = "0.5s";
      });
    }
  });
});
////////////////Review Start////////////////

const productRating = document.getElementById("comment-form");
const stars = productRating.querySelectorAll(".star");
let rating = 0;

window.addEventListener("click", e => {
  if (!e.target.matches(".star")) return;
  e.preventDefault();

  const starID = parseInt(e.target.getAttribute("data-star"));
  const starScreenReaderText = e.target.querySelector(".screen-reader");

  removeClassFromElements("is-active", stars);
  highlightStars(starID);

  resetScreenReaderText(stars);
  starScreenReaderText.textContent = `${starID} Stars Selected`;

  rating = starID; // set rating
});

window.addEventListener("mouseover", e => {
  if (!e.target.matches(".star")) return;

  removeClassFromElements("is-active", stars);
  const starID = parseInt(e.target.getAttribute("data-star"));
  highlightStars(starID);
});

productRating.addEventListener("mouseleave", e => {
  removeClassFromElements("is-active", stars);
  if (rating === 0) return;
  highlightStars(rating);
});

function highlightStars(starID) {
  for (let i = 0; i < starID; i++) {
    stars[i].classList.add("is-active");
  }
}

function removeClassFromElements(className, elements) {
  for (let i = 0; i < elements.length; i++) {
    elements[i].classList.remove(className);
  }
}

function resetScreenReaderText(stars) {
  for (let i = 0; i < stars.length; i++) {
    const starID = stars[i].getAttribute("data-star");
    const text = stars[i].querySelector(".screen-reader");

    text.textContent = `${starID} Stars`;
  }
}
///////////////////////////////////////////////
