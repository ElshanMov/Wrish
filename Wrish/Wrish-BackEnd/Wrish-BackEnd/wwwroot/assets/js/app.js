$(function () {

    var basketbar = document.querySelector("#basketbar .div");
    var wislistitem = document.querySelector("#wishlist .content-items tbody")
    $(document).on("click", ".remove-basket", function (e) {
        e.preventDefault();
        var id = $(this).attr("data-id");
        basketbar.innerHTML = "";
        fetch('https://localhost:44345/product/deletefrombasket?id='+id)
            .then(response => response.text())
            .then(data => {
                basketbar.innerHTML = data;
            });
        //window.location.reload(true);
    });

    $(document).on("click", ".single-lupa-btn", function () {
        let id = $(this).attr("data-id");
        console.log(id);
        fetch('https://localhost:44345/home/getproduct?id='+id)
            .then(response => response.text())
            .then(data => {
                
                $("#exampleModal .modal-content").html(data);
            });

        $("#exampleModal").modal("show");
    });

    

    $(document).on("click", ".add-basket", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        console.log("salam")
        basketbar.innerHTML = "";
        fetch(url)
            .then(response => response.text())
            .then(data => {                
                basketbar.innerHTML = data;
               
            });
        //window.location.reload(true);

    });

    $(document).on("click", ".add-basket1", function (e) {
        e.preventDefault();
        var basketCount = $(".qty").val();
        let id = $(".plus").attr("data-id");
        fetch('https://localhost:44345/product/addbasket?productId=' + id + '&count=' + basketCount)
            .then(response => response.text())
            .then(data => {

                basketbar.innerHTML = data;

            });
        //window.location.reload(true);

        
    });





    $(document).on("click", ".add-wishlist", function (e) {

        e.preventDefault();
        let id = $(this).attr("data-id");        
        fetch('https://localhost:44345/product/AddWishList?id='+id)
            .then(response => response.text())
            .then(data => {
                console.log(data)
            })
    })
    $(document).on("click", ".remove-wishlist", function (e) {


        let id = $(this).attr("data-id");        
        fetch('https://localhost:44345/product/RemoveWishList?id='+id)
            .then(response => response.text())
            .then(data => {
                wislistitem.innerHTML = data;
            })
    })

    $(function () {
        $(".search-box input").keyup(function ()
        {
            let text = $(this).val();
            console.log(text);
            fetch('https://localhost:44345/product/search?text=' + text)
                .then(response => response.text())
                .then(data =>
                {
                    var road = document.querySelector(".search-box .result-search-products");
                    road.innerHTML = data;                    
                })
        })
    })
   
   

});
