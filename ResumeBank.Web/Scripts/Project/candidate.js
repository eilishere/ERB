
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
        }

    });

};