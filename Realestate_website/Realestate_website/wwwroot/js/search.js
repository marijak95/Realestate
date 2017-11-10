function key_down(e) {
    if (e.keyCode === 13) {
        search(e);
    }
}

$("#search").click(function search(e) {
    var search = $("#searchString").val();

    $.ajax({
        url: "Home/ListOfAdds",
        data: { search: search },
        success: function (result) {
            $("#addsPlaceholder").html(result);
        }
    });
});

