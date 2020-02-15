
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

$('#admintable-enrollments').DataTable({
    "pageLength": 5,
    "processing": true,
    "bSearchable": true,
    "bFilter": true,
    "ajax": "AllEnrollmentsData",
    "columnDefs": [{
        "orderable": false,
        "targets": 2,
        "render": function (data, type, row) {
            return `<a type="submit" class="btn btn-info btn-sm " onclick="window.location.href='ViewEnrollment?studentid=${row[0]}&courseid=${row[1]}'" ><i class="far fa-id-badge"></i>VIEW</a>` +
                `<a type="submit" class="btn btn-warning btn-sm ml-1" onclick="window.location.href='EditEnrollment?studentid=${row[0]}&courseid=${row[1]}'" ><i class="far fa-edit"></i>EDIT</a>` +
                `<a type="submit" class="btn btn-danger btn-sm ml-1" onclick="window.location.href='DeleteEnrollment?studentid=${row[0]}&courseid=${row[1]}'" ><i class="fas fa-trash"></i>DELETE</a>`;
        }
    }]
});

$('#admintable-instructor').DataTable({
    "pageLength": 5,
    "processing": true,
    "bSearchable": true,
    "bFilter": true,
    "ajax": "AllInstructorsData",
    "columnDefs": [{
        "orderable": false,
        "targets": 4,
        "render": function (data, type, row) {
            return `<button type="submit" class="btn btn-info btn-sm" onclick="window.location.href='ViewInstructor/${row[0]}'" value='${row[0]}'><i class="far fa-id-badge"></i>VIEW</button>` +
                `<button type="submit" class="btn btn-warning btn-sm ml-1" onclick="window.location.href='EditInstructor/${row[0]}'" value='${row[0]}'><i class="far fa-edit"></i>EDIT</button>` +
                `<button type="submit" class="btn btn-danger btn-sm ml-1" onclick="window.location.href='DeleteInstructor/${row[0]}'" value='${row[0]}'><i class="fas fa-trash"></i>DELETE</button>`;
        }
    }]
});