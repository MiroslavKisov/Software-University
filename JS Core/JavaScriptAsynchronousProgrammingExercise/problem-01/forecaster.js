function attachEvents() {
    $('#submit').on('click', getWeather);
    let $section = $('#forecast');
    let baseUrl = ``;

    let conditions  = {
        'Sunny' : '☀',
        'Partly sunny': '⛅',
        'Overcast' : '☁',
        'Rain' : '☂',
        'Degrees' : '°',
    };

    function getWeather() {

        let location = $('#location').val();
        $("#current").html("<div class='label'>Current conditions</div>");
        $("#upcoming").html("<div class='label'>Three-day forecast</div>");

        $.get({
            method : 'GET',
            url : baseUrl + 'locations.json',
        })
        .then(getLocation)
        .then(getTodayForecast)
        .then(getThreeDayForecast)
        .catch(displayError);

        function getThreeDayForecast(locationCode) {
            $.get({
                method : 'GET',
                url : baseUrl + `forecast/upcoming/${locationCode}.json`
            })
            .then(addThreeDayConditions)
            .catch(displayError);
        }
    
        function getTodayForecast(locationCode) {
            $.get({
                method : 'GET',
                url : baseUrl + `forecast/today/${locationCode}.json`
            })
            .then(addCurrentConditions)
            .catch(displayError);
    
            return locationCode;
        }
    
        function addThreeDayConditions(location) {
            for(const forecast of location.forecast) {
                $('#upcoming').append($('<span>').addClass('upcoming')
                .append($('<span>').addClass('symbol').text(conditions[forecast.condition]))
                .append($('<span>').addClass('forecast-data').text(`${forecast.low}${conditions.Degrees}/${forecast.high}${conditions.Degrees}`))
                .append($('<span>').addClass('forecast-data').text(forecast.condition)));
            }
    
            $section.css('display', 'block');
        }
    
        function addCurrentConditions(location) {
            $('#current')
            .append($('<span>').addClass('condition symbol').text(conditions[location.forecast.condition]))
            .append($('<span>').addClass('condition')
                .append($('<span>').addClass('forecast-data').text(location.name))
                .append($('<span>').addClass('forecast-data').text(`${location.forecast.low}${conditions.Degrees}/${location.forecast.high}${conditions.Degrees}`))
                .append($('<span>').addClass('forecast-data').text(location.forecast.condition)));
        }
    
        function getLocation(locations) {
            let desiredLocation = locations.find(l => l.name === location);
            
            return desiredLocation.code;
        }
    
        function displayError() {
            $section.css('display', 'block').html('Error');
        }
    }
}
