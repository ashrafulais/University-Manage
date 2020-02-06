$(document).ready(function () {
    $('#usertable-dept').DataTable({
        "pageLength": 3,
        "processing": true,
        "bSearchable": true,        "bFilter": true,
        "ajax": "/Departments/GetAllDepartments",
        "columnDefs": [{
            "orderable": false,
            "targets": 2,
            "render": function (data, type, row) {
                return `<button type="submit" class="btn btn-info btn-sm" onclick="window.location.href='/Departments/ViewDepartment/${data}'" value='${data}'><i class="far fa-id-badge"></i>VIEW</button>`;
            }
        }]

    });

    $('#usertable-students').DataTable({
        "pageLength": 3,
        "processing": true,
        "bSearchable": true,        "bFilter": true,
        "ajax": "/Students/GetAllStudents",
        "columnDefs": [{
            "orderable": false,
            "targets": 3,
            "render": function (data, type, row) {
                return `<button type="submit" class="btn btn-info btn-sm" onclick="window.location.href='/Students/ViewStudent/${data}'" value='${data}'><i class="far fa-id-badge"></i>VIEW</button>`;
            }
        }]

    });

    $('#usertable-instructors').DataTable({
        "pageLength": 3,
        "processing": true,
        "bSearchable": true,        "bFilter": true,
        "ajax": "/Instructors/GetAllInstructors",
        "columnDefs": [{
            "orderable": false,
            "targets": 3,
            "render": function (data, type, row) {
                return `<button type="submit" class="btn btn-info btn-sm" onclick="window.location.href='/Instructors/ViewInstructor/${data}'" value='${data}'><i class="far fa-id-badge"></i>VIEW</button>`;
            }
        }]

    });
});