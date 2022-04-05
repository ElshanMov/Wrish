

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

////////////////////Search////////////////////
const search_icon = document.querySelectorAll(".search-icon");

search_icon.forEach(x => {
  x.addEventListener("click", function () {
    console.log(search_overlay_content.classList.toggle("search-visible"));
  });
});
///////////////////BasketBar/////////////////

//const basket_icon = document.querySelectorAll(".basket-icon");
//const close_basketbar = document.querySelectorAll(".close-basketbar");
//const basketbar = document.getElementById("basketbar");
//basket_icon.forEach(x =>
//{
//    x.addEventListener("click", function ()
//    {
//        basketbar.classList.add("openbar")
//    })
//})

//close_basketbar.forEach(x => {
//    x.addEventListener("click", function () {
//        basketbar.classList.remove("openbar")

//    })
//})

const basket_icon = document.querySelectorAll(".basket-icon");

basket_icon.forEach(x => {
  x.addEventListener("click", function () {
    basketbar.classList.toggle("openbar");
  });
});


