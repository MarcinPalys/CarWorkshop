$(document).ready(function () {
    $("#createCarWorkshopServiceModal form").submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {

                toastr["success"]("Created car workshop service"); 
                LoadCarWorkshopServices()
            },
            error: function (xhr, status, error) {
                toastr["error"]("Something went wrong");
                console.log("Error:", xhr.responseText);
            }
        });
        
    });
    LoadCarWorkshopServices()
    
});
