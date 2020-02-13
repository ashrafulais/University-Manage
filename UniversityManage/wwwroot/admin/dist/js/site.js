
$('#admintable-students').DataTable({
    "pageLength": 5,
    "processing": true,
    "bSearchable": true,
    "bFilter": true,
    "ajax": "AllStudentsData",
    "columnDefs": [{
        "orderable": false,
        "targets": 3,
        "render": function (data, type, row) {
            return `<button type="submit" class="btn btn-info btn-sm" onclick="window.location.href='ViewStudent/${data}'" value='${data}'><i class="far fa-id-badge"></i>VIEW</button>` +
                `<button type="submit" class="btn btn-warning btn-sm ml-1" onclick="window.location.href='EditStudent/${data}'" value='${data}'><i class="far fa-edit"></i>EDIT</button>` +
                `<button type="submit" class="btn btn-danger btn-sm ml-1" onclick="window.location.href='DeleteStudent/${data}'" value='${data}'><i class="fas fa-trash"></i>DELETE</button>`;
        }
    }]
});
