// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $(function () {
    $.ajax({
        type: "Get",
        url: "/Home/GetLabs",
        success: function (data) {
            //update the page content.
            var renderList = ""
            
            for(var i = 0; i < data.length; i++){
                renderList += "<li><a class=\"@Html.ActiveClass(\"LabBooking\", \"BookingsOverview\") hover:translate-x-2 transition-transform ease-in duration-300 w-full flex items-center h-10 pl-4 cursor-pointer\"asp-controller=\"LabProfile\" asp-action=\"LabProfile\" asp-route-labLocation="+data[i]['labLocation']+"><span>"+data[i]['labLocation']+"</span></a></li>\n"
            }
            $('#returnlabs').empty(); //clear the content
            $('#returnlabs').append(renderList); //add the latest data.
        },
        error: function (response) {
            console.log(response.responseText);
        }
    });
});

// To toggle navbar 
const btn = document.querySelector(".mobile-menu-button");
const sidebar = document.querySelector(".side-bar");

// add our event listener for the click
btn.addEventListener("click", () => {
    sidebar.classList.toggle("-translate-x-full");
});
