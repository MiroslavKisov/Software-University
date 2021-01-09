function attachEvents() {

    let selectors = {
        angler : '.angler',
        weight : '.weight',
        species : '.species',
        location : '.location',
        bait : '.bait',
        captureTime : '.captureTime',
        catches : '#catches',
        catch : '.catch',
        aside : '#aside',
        update : '.update',
        load : '.load',
        delete : '.delete',
        add : '.add',
    }

    $(selectors.load).on('click', loadCatches);
    $(selectors.add).on('click', addCatch);

    let catchDiv = $(selectors.catches);

    let asideDiv = $(selectors.aside);

    const appID = '';
    const username = 'guest';
    const password = 'guest';
    const base64auth = btoa(username + ":" + password);
    const authHeaders = {'Authorization': 'Basic ' + base64auth, 'Content-Type': 'application/json'};
    const baseUrl ='https://baas.kinvey.com/appdata/'+ appID + '/biggestCatches';

    function loadCatches() {

        catchDiv.empty();

        $.ajax({
            method : 'GET',
            url : baseUrl,
            headers : authHeaders,
        })
        .then(displayCatches)
        .catch(displayError);

        function displayCatches(catches) {

            for(const c of catches) {
                catchDiv
                .append(`<div class="catch" data-id="${c._id}">
                <label>Angler</label>
                <input type="text" class="angler" value="${c.angler}"/>
                <label>Weight</label>
                <input type="number" class="weight" value="${c.weight}"/>
                <label>Species</label>
                <input type="text" class="species" value="${c.species}"/>
                <label>Location</label>
                <input type="text" class="location" value="${c.location}"/>
                <label>Bait</label>
                <input type="text" class="bait" value="${c.bait}"/>
                <label>Capture Time</label>
                <input type="number" class="captureTime" value="${c.captureTime}"/>
                <button class="update">Update</button>
                <button class="delete">Delete</button>
                </div>`);

                $(selectors.catch).children(selectors.update).on('click', updateCatch.bind(this, c));
                $(selectors.catch).children(selectors.delete).on('click', deleteCatch.bind(this, c._id));
            }
        }
    }

    function addCatch() {

        let anglerCreate = asideDiv.find($(selectors.angler)).val();
        let weightCreate = Number(asideDiv.find($(selectors.weight)).val());
        let speciesCreate = asideDiv.find($(selectors.species)).val();
        let locationCreate = asideDiv.find($(selectors.location)).val();
        let baitCreate = asideDiv.find($(selectors.bait)).val();
        let captureTimeCreate = Number(asideDiv.find($(selectors.captureTime)).val());

        let newCatch = {
            angler:anglerCreate,
            weight:weightCreate,
            species:speciesCreate,
            location:locationCreate,
            bait:baitCreate,
            captureTime:captureTimeCreate,
        };

        $.ajax({
            method : 'POST',
            url : baseUrl,
            data: JSON.stringify(newCatch),
            headers : authHeaders,
        })
        .then(loadCatches)
        .catch(displayError);
    }

    function updateCatch(c) {

        let parentDiv = catchDiv;
        let anglerEdit = parentDiv.find($(selectors.angler)).val();
        let weightEdit = Number(parentDiv.find($(selectors.weight)).val());
        let speciesEdit= parentDiv.find($(selectors.species)).val();
        let locationEdit = parentDiv.find($(selectors.location)).val();
        let baitEdit = parentDiv.find($(selectors.bait)).val();
        let captureTimeEdit = Number(parentDiv.find($(selectors.captureTime)).val());
        
        let currentCatch = {
            angler:anglerEdit,
            weight:weightEdit,
            species:speciesEdit,
            location:locationEdit,
            bait:baitEdit,
            captureTime:captureTimeEdit,
        };

        $.ajax({
            method : 'PUT',
            url : baseUrl + '/' + c._id,
            data: JSON.stringify(currentCatch),
            headers : authHeaders,
        })
        .then(loadCatches)
        .catch(displayError);
    }

    function deleteCatch(catchId) {
        $.ajax({
            method : 'DELETE',
            url : baseUrl + '/' + catchId,
            headers : authHeaders,
        })
        .then(loadCatches)
        .catch(displayError);
    }

    function displayError(error) {
        console.log(error.statusText);
    }
}

