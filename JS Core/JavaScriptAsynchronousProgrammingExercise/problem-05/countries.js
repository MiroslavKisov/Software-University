function attachEvents() {

    $(window).on('load', populateCountriesDropDownList);

    let selectors = {
        countryName : '#countryName',
        createCountry : '#createCountry',
        countries : "#countries",
        showCountries : '#showCountries',
        showTowns : '#showTowns',
        towns : '#towns',
        townName : '#townName',
        townCountry : '#townCountry',
        createTown : '#createTown',
        errorMessage : 'errorMessage',
        successMessage : 'successMessage',
        editCountry : '#editCountry',
        deleteCountry : '#deleteCountry',
        editTown : '#editTown',
        deleteTown : '#deleteTown',
        message: "#message",
        selected: ':selected',
        hideCountries : '#hideCountries',
        hideTowns : '#hideTowns',
        searchedCountry: '#searchedCountry',
    };

    $(selectors.createCountry).on('click', createCountry);
    $(selectors.createTown).on('click', createTown);
    $(selectors.showCountries).on('click', showCountries);
    $(selectors.showTowns).on('click', showTowns);
    $(selectors.hideCountries).on('click', hideCountries);
    $(selectors.hideTowns).on('click', hideTowns);

    const baseUrl = 'https://baas.kinvey.com/appdata/';
    const countriesEndPoint = 'countries';
    const townsEndPoint = 'towns';
    const appId = '';
    const username = 'guest';
    const password = 'guest';
    const base64auth = btoa(username + ":" + password);
    const headers = {
        "Authorization": "Basic " + base64auth, "Content-Type": "application/json"
    };

    //populateCountriesDropDownList();

    async function createCountry() {

        let name = $(selectors.countryName).val();
        let countries = await getCountries();

        if(countries.filter(e => e.name === name).length > 0) {

            displayErrorMessage(`ERROR! Country ${name} already exist.`);

        } else {

            let country = {
                name : name,
            };

            try {
                await $.ajax({
                    method : 'POST',
                    url : baseUrl + appId + '/' + countriesEndPoint,
                    headers : headers,
                    data : JSON.stringify(country),
                    success : displaySuccessMessageCountry
                });
    
                await populateCountriesDropDownList();
    
            } catch(error) {
    
                displayErrorMessage('ERROR!');
                console.log(error);
            }
        }

        $(selectors.countryName).val('');
    }

    async function createTown() {

        let name = $(selectors.townName).val();
        let country = $(selectors.townCountry).find(selectors.selected).text();
        let towns = await getTowns();
        let countryTowns = towns.filter(e => e.country === country);

        if(country === '') {

            displayErrorMessage('ERROR! You must create a country first.');

        } else if(countryTowns.filter(t => t.name === name).length > 0) {

            displayErrorMessage(`ERROR! Town ${name} already exist in ${country}.`);   

        } else {
            let town = {
                name : name,
                country : country,
            };
    
            try {
                await $.ajax({
                    method : 'POST',
                    url : baseUrl + appId + '/' + townsEndPoint,
                    headers : headers,
                    data : JSON.stringify(town),
                    success : displaySuccessMessageTown,
                });
    
            } catch(error) {
    
                displayErrorMessage('ERROR!');
                console.log(error);
            }
        }

        $(selectors.townName).val('');
    }

    async function showCountries() {
        
        $(selectors.countries).css('display', 'block').empty();

        let countries = await getCountries();

        for(const country of countries) {
            $(selectors.countries).append(
            `<tr id=${country._id}>
                <td>
                    <input value="${country.name}" type="text">
                </td>
                <td>
                    <button>Edit</button>
                </td>
                <td>
                    <button>Delete</button>
                </td>
            </tr>`
            );
            
            let editButton = $($(`#${country._id}`).children().children()[1]);
            let deleteButton = $($(`#${country._id}`).children().children()[2]);
            editButton.on('click', editCountry.bind(this, country._id));
            deleteButton.on('click', deleteCountry.bind(this, country._id));
        }

        $(selectors.hideCountries).css('visibility', 'visible');
        $(selectors.showCountries).css('visibility', 'hidden');
    }

    async function showTowns() {
        
        $(selectors.towns).css('display', 'block').empty();

        let country = $(selectors.searchedCountry).val();
        let countries = await getCountries();
        if(countries.filter(c => c.name === country).length === 0) {

            displayErrorMessage(`Country with name ${country} does not exist in out data base!`);

        } else {

            let towns = await getTowns();

            for(const town of towns.filter(t => t.country === country)) {
                $(selectors.towns).append(
                    `<tr id=${town._id}>
                        <td>
                            <input value="${town.name}" type="text">
                        </td>
                        <td>
                            <button>Edit</button>
                        </td>
                        <td>
                            <button>Delete</button>
                        </td>
                    </tr>`
                );
                    
                let editButton = $($(`#${town._id}`).children().children()[1]);
                let deleteButton = $($(`#${town._id}`).children().children()[2]);
                editButton.on('click', editTown.bind(this, town._id));
                deleteButton.on('click', deleteTown.bind(this, town._id));
            }
    
            $(selectors.hideTowns).css('visibility', 'visible');
            $(selectors.showTowns).css('visibility', 'hidden');
            //$(selectors.searchedCountry).val('');
        }
    }

    function hideCountries() {
        $(selectors.countries).css('display', 'none');
        $(selectors.hideCountries).css('visibility', 'hidden');
        $(selectors.showCountries).css('visibility', 'visible');
    }

    function hideTowns() {
        $(selectors.towns).css('display', 'none');
        $(selectors.hideTowns).css('visibility', 'hidden');
        $(selectors.showTowns).css('visibility', 'visible');
    }

    async function editCountry(countryId) {

        let name = $($(`#${countryId}`).children().children()[0]).val();
        let countries = await getCountries();

        if(countries.filter(c => c.name === name).length > 0) {

            displayErrorMessage(`ERROR! Country ${name} already exist.`);
            showCountries();

        } else {

            let country = {
                name,
            };
    
            try {
                await $.ajax({
                    method : 'PUT',
                    url : baseUrl + appId + '/' + countriesEndPoint + '/' + countryId,
                    headers : headers,
                    data : JSON.stringify(country),
                });
    
            } catch(error) {
                displayErrorMessage('ERROR!');
                console.log(error);
            }
            
            populateCountriesDropDownList();
            showCountries();
        }
    }

    async function deleteCountry(countryId) {

        try {
            await $.ajax({
                method : 'DELETE',
                url : baseUrl + appId + '/' + countriesEndPoint + '/' + countryId,
                headers : headers,
            });

        } catch(error) {
            displayErrorMessage('ERROR!');
            console.log(error);
        }

        showCountries();
    }

    async function editTown(townId) {

        let name = $($(`#${townId}`).children().children()[0]).val();
        let country = $(selectors.searchedCountry).val();
        let towns = await getTowns();
        let countryTowns = towns.filter(e => e.country === country);

        if(countryTowns.filter(t => t.name === name).length > 0) {

            displayErrorMessage(`ERROR! Town ${name} already exist in ${country}.`);
            showTowns();

        } else {

            let town = {
                country,
                name,
            };
    
            try {
                await $.ajax({
                    method : 'PUT',
                    url : baseUrl + appId + '/' + townsEndPoint + '/' + townId,
                    headers : headers,
                    data : JSON.stringify(town),
                });
    
            } catch(error) {
                displayErrorMessage('ERROR!');
                console.log(error);
            }
    
            showTowns();
        }
    }

    async function deleteTown(townId) {

        try {
            await $.ajax({
                method : 'DELETE',
                url : baseUrl + appId + '/' + townsEndPoint + '/' + townId,
                headers : headers,
            });

        } catch(error) {
            displayErrorMessage('ERROR!');
            console.log(error);
        }

        showTowns();
    }

    async function getTowns() {

        let towns;

        try {
            towns = await $.ajax({
                method : 'GET',
                url : baseUrl + appId + '/' + townsEndPoint,
                headers : headers,
            });

        } catch(error) {

            displayErrorMessage('ERROR!');
            console.log(error);
        }

        return towns;
    }

    async function getCountries() {

        let countries;

        try {
            countries = await $.ajax({
                method : 'GET',
                url : baseUrl + appId + '/' + countriesEndPoint,
                headers : headers,
            });

        } catch(error) {

            displayErrorMessage('ERROR!');
            console.log(error);
        }

        return countries;
    }

    async function populateCountriesDropDownList() {

        let countries = await getCountries();
        $(selectors.townCountry).empty();

        for(const country of countries) {
            $(selectors.townCountry).append(
                ` <option value="${country._id}">${country.name}</option>`
            )
        }
    }

    function displayErrorMessage(message) {

        $(selectors.message).append($('<div>').addClass(selectors.errorMessage)
        .text(message).fadeOut(5000));
    }

    function displaySuccessMessageCountry(country) {

        $(selectors.message).append($('<div>').addClass(selectors.successMessage)
        .text(`You have successfully added ${country.name}.`).fadeOut(5000));
    }

    function displaySuccessMessageTown(town) {

        $(selectors.message).append($('<div>').addClass(selectors.successMessage)
        .text(`You have succesfully added ${town.name} to ${town.country}.`).fadeOut(5000));
    }
}
