
var ConfirmDeleteCandidate = function(id) {
    $("#confirmDeleteModal").modal('show');
    $("#hiddenCandidateId").val(id);
};


var DeleteCandidate = function() {

    var id = $("#hiddenCandidateId").val();

    $.ajax({
        type: "POST",
        url: "/Candidate/DeleteCandidate",
        data: { id: id },
        success: function(result) {

            $("#confirmDeleteModal").modal("hide");
            window.location.reload(true);
        },
        error: function (result) {
            $.notify('Oops, something bad happened !!!', 'error');
        }

    });

};



//..... Start Add Candidate Page.....

$(function () {
    if ($("#primaryCategoryId").val() != '' && $('#subCategoryId option').length > 0) {
        $("#subCategoryId").removeAttr("disabled");
    }
});

$("#primaryCategoryId").change(function () {

    var id = $("#primaryCategoryId").val();
    var objData = { id: id };

    if ($("#primaryCategoryId").val() == '') {
        $('#subCategoryId').empty();
        $("#subCategoryId").attr("disabled", true);

        return;
    }

    $.ajax({
        type: "POST",
        url: "/Candidate/GetSubCategories",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(objData),
        dataType: "json",
        success: function (rData) {
            if (rData != undefined && rData != "") {

                $("#subCategoryId").removeAttr("disabled");
                $('#subCategoryId').empty();

                $.each(rData, function (key, value) {

                    $("#subCategoryId").append($("<option></option>")
                        .val(value.Id).html(value.Name));
                });

            }
            else {

                $('#subCategoryId').empty();
                $("#subCategoryId").attr("disabled", true);
            }
        },
        error: function (result) {
            $.notify('Oops, something bad happened !!!', 'error');
        }

    });
});

//..... End Add Candidate Page.....

//..... Start Search Candidate Page.....

$(function () {
    if ($("#primaryCategorySearchId").val() != '' && $('#subCategorySearchId option').length > 0) {
        $("#subCategorySearchId").removeAttr("disabled");
}
});

$("#primaryCategorySearchId").change(function () {

    var searchId = $("#primaryCategorySearchId").val();
    var searchObjData = { id: searchId };

    if ($("#primaryCategorySearchId").val() == '') {
        $('#subCategorySearchId').empty();
        $("#subCategorySearchId").append($("<option></option>")
            .val('').html("---Select Sub-Category---"));
        $("#subCategorySearchId").attr("disabled", true);

        return;
    }

    $.ajax({
        type: "POST",
        url: "/Candidate/GetSubCategories",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(searchObjData),
        dataType: "json",
        success: function (rData) {
            if (rData != undefined && rData != "") {

                $("#subCategorySearchId").removeAttr("disabled");
                $('#subCategorySearchId').empty();
                $("#subCategorySearchId").append($("<option></option>")
                    .val('').html("---Select Sub-Category---"));

                $.each(rData, function (key, value) {

                    $("#subCategorySearchId").append($("<option></option>")
                        .val(value.Id).html(value.Name));
                });

            }
            else {

                $('#subCategorySearchId').empty();
                $("#subCategorySearchId").append($("<option></option>")
                    .val('').html("---Select Sub-Category---"));
                $("#subCategorySearchId").attr("disabled", true);
            }
        },
        error: function (result) {
            $.notify('Oops, something bad happened !!!', 'error');
        }

    });

});

//..... End Search Candidate Page.....


//..... Start File Check .....//
$(document).ready(function () {
    $("#originalResumeFile").change(function () {
        if (this.files && this.files[0]) {
            if (!this.files[0].name.match(/\.(pdf|doc|docx|ppt|pptx)$/)) {
                alert("This file is not supported");
                $(this).val(null);
                return;
            }
            if (!(this.files[0].size > (0))) {
                alert("There is no data in the file");
                $(this).val(null);
                return;
            }
        }
    });

    $("#modifiedResumeFile").change(function () {
        if (this.files && this.files[0]) {
            if (!this.files[0].name.match(/\.(pdf|doc|docx|ppt|pptx)$/)) {
                alert("This file is not supported");
                $(this).val(null);
                return;
            }
            if (!(this.files[0].size > (0))) {
                alert("There is no data in the file");
                $(this).val(null);
                return;
            }
        }
    });
});
//..... End File Check .....//