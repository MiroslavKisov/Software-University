function getInfo() {
    let stopId = $('#stopId').val();
    let url = ``;

    $.ajax({
        method : 'GET',
        url : url,
        success : displayBusStops,
        error : displayError
    });

    function displayBusStops(data) {
        $('#stopName').text(data.name);
        let buses = Object.entries(data.buses);
        let busesList = $('#buses');

        for(const [key, value] of buses) {

            let message = `Bus ${key} arrives in ${value} minutes`;
            let busItem = $('<li>').text(message);
            busesList.append(busItem);
        }
    }

    function displayError(error) {
        $('#stopName').text('Error');
    }
}
