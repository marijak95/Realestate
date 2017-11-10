$("#textButton").click(function (e) {
    var textButton = $("#textComment").val();
    var ad_id = $("#Ad_id").val();

    $.ajax({
        url: "../../Comments/AddComment",
        data: { textButton: textButton, ad_id: ad_id },
        success: function (result) {
            $("#addsPlaceholder").empty();
            $("#addsPlaceholder").html(result);
        }
    });
});
