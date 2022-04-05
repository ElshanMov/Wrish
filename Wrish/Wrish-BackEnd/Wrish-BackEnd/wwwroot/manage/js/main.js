$(function () {
    $(document).on("click", ".btn-delete", function (e) {
        e.preventDefault();
        let href = $(this).attr("href");
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(href)
                    .then(response => {
                        if (response.ok) {
                            window.location.reload(true);
                        }
                        else {
                            alert("Not Found")
                        }
                    })
            }
            else {
                console.log("cancel")
            }
        })
    });
});

let input = document.querySelectorAll(".img-upload-input")
let imgBox = document.querySelectorAll(".img-box");
console.log(imgBox);
let posterInput = document.querySelectorAll(".img-poster-input")[0];
let posterImg = document.querySelectorAll(".poster-img-change img")[0];
let hoverInput = document.querySelectorAll(".img-hover-input")[0];
let hoverImg = document.querySelectorAll(".hover-img-change img")[0];
console.log(posterImg);
input.forEach(function (elem) {
    elem.onchange = function (e) {
        let files = e.target.files;
        let filesArr = Array.from(files);
        console.log("salams")
        filesArr.forEach(x => {
            console.log("salam")
            if (x.type.startsWith("image/")) {
                let reader = new FileReader()
                console.log("sas")
                reader.onload = function () {
                    imgBox.forEach(function (e) {
                        e.innerText = "";
                        let newImg = document.createElement("img");

                        newImg.setAttribute("src", reader.result)
                        newImg.style.width = "250px"
                        newImg.style.height = "250px"
                        newImg.style.objectFit = "cover"

                        e.appendChild(newImg);
                    })
                }
                reader.readAsDataURL(x);
            }
        })
    }

}
)

posterInput.onchange = function (e) {
    console.log("salam")
    let files = e.target.files;
    let filesArr = Array.from(files);

    filesArr.forEach(x => {
        if (x.type.startsWith("image/")) {
            let reader = new FileReader()
            reader.onload = function () {
                posterImg.style.display = "block";
                posterImg.parentElement.lastElementChild.style.display = "block";
                posterImg.setAttribute("src", reader.result)
            }
            reader.readAsDataURL(x);
        }
    })
}

hoverInput.onchange = function (e) {
    let files = e.target.files;
    let filesArr = Array.from(files);

    filesArr.forEach(x => {
        if (x.type.startsWith("image/")) {
            let reader = new FileReader()
            reader.onload = function () {
                hoverImg.setAttribute("src", reader.result)
            }
            reader.readAsDataURL(x);
        }
    })
}
$(document).ready(function () {
    $(document).on("click", ".remove-img-box", function () {
        $(this).parent().remove();
    })
})

let productinput = document.getElementById("img-upload-input")
let productdiv = document.getElementById("product-images")
console.log(productinput)
productinput.onchange = function (e) {
    console.log("salam")
    let files = e.target.files
    let filesarr = [...files]
    filesarr.forEach(x => {
        console.log("sasadscasdzxddc");
        if (x.type.startsWith("image/")) {
            let reader = new FileReader()
            reader.onload = function () {
                let newimg = document.createElement("img")
                newimg.style.width = "180px"
                newimg.style.marginLeft = "8px"
                newimg.style.marginRight="8px"
                newimg.setAttribute("src", reader.result)
                productdiv.appendChild(newimg)
            }
            reader.readAsDataURL(x)
        }
    })
}





