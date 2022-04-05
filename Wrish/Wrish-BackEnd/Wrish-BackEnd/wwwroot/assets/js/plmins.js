jQuery(document).ready(function () {

    $('[data-quantity="plus"]').click(function (e) {
        e.preventDefault();
        fieldName = $(this).attr("data-field");
        var currentVal = parseInt($("input[name=" + fieldName + "]").val());
        if (!isNaN(currentVal)) {
            $("input[name=" + fieldName + "]").val(currentVal + 1);
        } else {
            $("input[name=" + fieldName + "]").val(0);
        }
    });
    $('[data-quantity="minus"]').click(function (e) {
        e.preventDefault();
        fieldName = $(this).attr("data-field");
        var currentVal = parseInt($("input[name=" + fieldName + "]").val());
        if (!isNaN(currentVal) && currentVal > 1) {
            $("input[name=" + fieldName + "]").val(currentVal - 1);
        } else {
            $("input[name=" + fieldName + "]").val(1);
        }
    });
});
