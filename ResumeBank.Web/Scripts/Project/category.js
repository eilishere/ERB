

var ConfirmDeleteCategory = function (id) {
    $("#confirmDeleteModal").modal('show');
    $("#hiddenCategoryId").val(id);
};


var DeleteCategory = function () {

    var id = $("#hiddenCategoryId").val();

    $.ajax({
        type: "POST",
        url: "/Category/DeleteCategory",
        data: { id: id },
        success: function (result) {

            $("#confirmDeleteModal").modal("hide");
            window.location.reload(true);
        },
        error: function (result) {
            $.notify('Oops, something bad happened !!!', 'error');
        }

    });

};