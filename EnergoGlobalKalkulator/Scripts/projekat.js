$(document).ready(function () {
    LoadDataTable();
})

function LoadDataTable()
{
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Projektant/Projekti/5"
        },
        "columns": [
            { data: 'naziv_projekta' },
            { data: 'datum_izrade' },
            { data: 'idprojektant' },
            { data: 'ime_projektanta' }
           
            
        ]
    });

}