function solve() {

    let arriveButton = $('#arrive');
    let departButton = $('#depart');
    let infoBox = $('.info');
    let currentId = 'depot';
    let stopName;

    function depart() {
        
        departButton.attr('disabled', true);
        arriveButton.removeAttr('disabled');

        $.ajax({
            method : 'GET',
            url : ``,
            success : moveBus,
            error : displayError,
        });

        function moveBus(data) {
            currentId = data.next;
            stopName = data.name;
            infoBox.text(`Next stop ${stopName}`); 
        }

        function displayError(error) {
            infoBox.text('Error');
            arriveButton.attr('disabled', true);
            departButton.attr('disabled', true);
        }
    }

    function arrive() {

        arriveButton.attr('disabled', true);
        departButton.removeAttr('disabled');
        infoBox.text(`Arriving at ${stopName}`);
    }

    return {
        depart,
        arrive
    }
}
