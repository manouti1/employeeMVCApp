$(document).ready(function () {
    $('#employeeGrid').DataTable({
        "processing": true,
        "filter": true,
        "orderMulti": false,
        "paging": false,
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
    var obj = {};
    obj.Id = eId;

    $.ajax({
        // Since your route is "api/{controller}/{action}/{id}", 
        // add the id to the url
        url: url + eId,
        type: 'Post',
        success: function (response) {
            Swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            );
            oTable = $('#employeeGrid').DataTable();
            oTable.draw();
        }

    });
}