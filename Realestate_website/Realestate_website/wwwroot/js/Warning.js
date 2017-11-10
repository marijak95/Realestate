$('.warning').click(function (e) {
    var id = $(this).val();
    var row = $(this).closest('tr');
    var ad_user_id = row.find('.Ad_user_id').val();
    var user_name = $("#User_name").val();
    if (ad_user_id != user_name) {
        $('#myModal').modal('show');
    }

    else {

        window.location.href = "Advertisements/Edit/" + id;
    }
});