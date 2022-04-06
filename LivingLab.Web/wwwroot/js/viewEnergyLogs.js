let table;

$(document).ready(async function() {
    let data = await getData();
    initTable(data);
    
    setInterval(async function() {
        console.log("Refreshing data...");
        data = await getData();
        table.destroy();
        initTable(data);
    }, 2000);
})

function initTable(data) {
   table = $("#logs").DataTable({
        data: data,
        columns: [
            { data: "device.serialNo" },
            { data: "lab.labLocation" },
            { data: "energyUsage" },
            { data: "loggedDate" }
        ],
        searching: false
    });
}

async function getData() {
    try {
        return await $.ajax({
            url: "/api/energylog/GetLogs/50",
            type: "GET",
        })
    } catch (error) {
        console.log(error);
    }
}