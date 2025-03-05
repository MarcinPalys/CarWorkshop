// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const RenderCarWorkshopServices = (data, container) => {
    container.empty();
    console.log("Działa");
    for (const service of data) {
        container.append(`
            <div class="card border-secondery mb-3" style="max-width: 18rem;">
            <div class="card-header">${service.cost}</div>
                <div class="card-body">
                    <h5 class="card-title">${service.description}</h5>
                </div>
            </div>
            `)
    }
}

const LoadCarWorkshopServices = () => {
    const container = $('#services')
    const carWorkshopEncodedName = container.data('encodedName')

    console.log(carWorkshopEncodedName)
    $.ajax({
        url: `/CarWorkshop/${carWorkshopEncodedName}/CarWorkshopServices`,
        type: 'get',

        success: function (data) {
            if (!data.length) {
                container.html("There are no services for this car workshop")
            } else {
                RenderCarWorkshopServices(data, container)
            }
        },
        error: function (xhr, status, error) {
            toastr["error"]("Something went wrong");
            console.log("Error:", xhr.responseText);
        }
    });
}