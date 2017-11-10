$("#filter").click(function (e) {  
    var studio = $("#studio").is(":checked");
    var oneroom = $("#oneroom").is(":checked");
    var tworooms = $("#tworooms").is(":checked");
    var threerooms = $("threerooms").is(":checked");

    var price = $("#price").is(":checked");
    var date = $("#date").is(":checked");

    var search = $("#searchString").val();
    $.ajax({
        url: "Home/Filter",
        data: { studio: studio, oneroom: oneroom, tworooms: tworooms, threerooms: threerooms, price: price, date:date, search:search },
        success: function (result) {
            $("#addsPlaceholder").html(result);
        }
    });
});