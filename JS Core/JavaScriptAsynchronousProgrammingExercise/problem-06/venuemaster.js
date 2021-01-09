function attachEvents() {

    const selectors = {

        info : '.info',
        getVenues : '#getVenues',
        venueInfo : '#venue-info',
        venueDate : '#venueDate',
        content : '#content',
        venue : '.venue',
        venueName : '.venue-name',
        head: '.head',
        description : '.description',
        purchaseInfo : '.purchase-info',
        ticket : '.ticket',
        bl : '.bl',
        left : '.left',
        right : '.right',
        successMessage : 'successMessage',
        errorMessage : 'errorMessage',
        message : '#message',
        venueDetails : '.venue-details',
        purchase : '.purchase',
        venuePrice : '.venue-price',
        quantity : '.quantity',
    }

    $(selectors.getVenues).on('click', getVenuesIds);

    const baseUrl = `https://baas.kinvey.com/`;
    const appDataRoutePart = `appdata`
    const rpcRoutePart = `rpc`;
    const venuesEndPoint = `venues`;
    const customCalendarRoutePart = `custom/calendar`;
    const customPurchaseRoutePart = `custom/purchase`;
    const appId = ``;
    const username = 'guest';
    const password = 'pass';
    const base64auth = btoa(username + ":" + password);
    const headers = {
        "Authorization": "Basic " + base64auth, "Content-Type": "application/json"
    };

    let venueInfo = $(selectors.venueInfo);

    function getVenuesIds() {

        let date = $(selectors.venueDate).val();

        $.ajax({
        method : 'POST',
        url : baseUrl + rpcRoutePart + `/` + appId + `/` + customCalendarRoutePart + `?query=${date}`,
        headers : headers,
        })
        .then(showVenues)
        .catch(displayErrorMessage);
    }

    function showVenues(ids) {
        
        venueInfo.empty();

        for(const id of ids) {

            $.ajax({
                method : 'GET',
                url : baseUrl + appDataRoutePart + `/` + appId + `/` + venuesEndPoint + `/` + id,
                headers : headers,
            })
            .then(appendVenueInfo)
            .catch(displayErrorMessage);
        }
    }

    function appendVenueInfo(venue) {

        venueInfo.append(`<div class="venue" id="${venue._id}">
            <span class="venue-name"><input class="info" type="button" value="More info">${venue.name}</span>
            <div class="venue-details" style="display: none;">
            <table>
                <tr><th>Ticket Price</th><th>Quantity</th><th></th></tr>
                <tr>
                <td class="venue-price">${venue.price} lv</td>
                <td><select class="quantity">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                </select></td>
                <td><input class="purchase" type="button" value="Purchase"></td>
                </tr>
            </table>
            <span class="head">Venue description:</span>
            <p class="description">${venue.description}</p>
            <p class="description">Starting time: ${venue.startingHour}</p>
            </div>
            </div>`
        );

        //let moreInfoButton = $($(`#${venue._id}`).children().children()[0]);
        let moreInfoButton = $(`#${venue._id}`).find(selectors.info);
        let purchaseButton = $(`#${venue._id}`).find(selectors.purchase);
        purchaseButton.on('click', makePurchase.bind(this, venue._id));
        moreInfoButton.on('click', showDetails.bind(this, venue._id));
    }

    function makePurchase(venueId) {
        let name = $(`#${venueId}`).find(selectors.venueName).text();
        let qty = Number($(`#${venueId}`).find(selectors.quantity).val());
        let price = Number(($(`#${venueId}`).find(selectors.venuePrice).text()).split(' lv')[0]);

        venueInfo.empty();
        venueInfo.append(`<span class="head">Confirm purchase</span>
        <div class="purchase-info">
          <span>${name}</span>
          <span>${qty} x ${price}</span>
          <span>Total: ${qty * price} lv</span>
          <input type="button" value="Confirm">
        </div>`);

        let confirmButton = venueInfo.find(selectors.purchaseInfo).find('input');
        confirmButton.on('click', confirmPurchase.bind(this, {venueId, qty}));
    }

    function confirmPurchase(params) {

        $.ajax({
            method : 'POST',
            url : baseUrl + rpcRoutePart + `/` + appId + `/` + customPurchaseRoutePart + `?venue=${params.venueId}&qty=${params.qty}`,
            headers : headers,
            })
        .then(displayTicket)
        .catch(displayErrorMessage);
    }

    function displayTicket(ticket) {

        venueInfo.empty();
        venueInfo.append('<p>You may print this page as your ticket</p>').append(ticket.html);
    }

    function showDetails(venueId) {

        let divs = Array.from(venueInfo.children()).filter(x => x.id !== venueId);
        let detailsPanel = $($(`#${venueId}`).children()[1]);
        detailsPanel.toggle();

        for(let div of divs) {
            $($(div).children()[1]).hide();
        }
    }

    function displayErrorMessage() {

        venueInfo.empty();
        venueInfo.append(`<div class="errorMessage">ERROR!</div>`);
        console.log(error);
    }
}
