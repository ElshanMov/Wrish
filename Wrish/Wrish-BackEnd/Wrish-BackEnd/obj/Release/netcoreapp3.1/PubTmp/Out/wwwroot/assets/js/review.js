﻿const productRating = document.getElementById("comment-form");
const stars = productRating.querySelectorAll(".star");
let rating = 0;

window.addEventListener("click", e => {
    if (!e.target.matches(".star")) return;
    e.preventDefault();

    const starID = parseInt(e.target.getAttribute("value"));
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
    const starID = parseInt(e.target.getAttribute("value"));
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
        const starID = stars[i].getAttribute("value");
        const text = stars[i].querySelector(".screen-reader");

        text.textContent = `${starID} Stars`;
    }
}
