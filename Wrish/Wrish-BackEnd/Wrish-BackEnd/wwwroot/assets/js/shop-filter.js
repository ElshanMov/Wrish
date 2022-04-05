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

//////////////////////////////////////////////////
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
