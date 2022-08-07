var table = null;
$(document).ready(function () {
    table = $('#employeeGrid').DataTable({
        "processing": true,
        "filter": true,
        "orderMulti": false,
        "paging": false,
        "autoWidth": true,
    });
});

function DeleteData(eId) {
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
            Delete(eId);

        }
    })
}


function Delete(eId) {
    var url = "Employee/Delete?id=";

    $.ajax({
        url: url + eId,
        type: 'POST',
        headers: {
            RequestVerificationToken:
                document.getElementById("RequestVerificationToken").value
        },
        success: function (response) {
            Swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            ).then((result) => {
                if (result.isConfirmed) {
                    history.go(0);
                }
            });

          
        }

    });
}