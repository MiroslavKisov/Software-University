function solve() {

    let input = document.getElementById('str').value;

    let inputArgs = input.split(',');
    let text = inputArgs[0];
    let parameter = inputArgs[1].trim();

    let twoNamePattern = /[\s]([A-Z][A-Za-z]*?)-([A-Z][A-Za-z]*?)[\s]/;
    let threeNamePattern = /[\s]([A-Z][A-Za-z]*?)-([A-Z]{1}[A-Za-z]*?[\.])-([A-Z][A-Za-z]*?)[\s]/;
    let airPortPattern = /[\s]([A-Z]{3})\/([A-Z]{3})[\s]/;
    let flightNumberPattern = /[\s]([A-Z]{1,3}[0-9]{1,5})[\s]/;
    let companyPattern = /-[\s]([A-Z]{1}[A-Za-z]*?)\*([A-Z]{1}[A-Za-z]*?)[\s]/;

    let passengerName = '';
    let airPortName = '';
    let flightNumber = '';
    let companyName = '';
    let match;

    let result = document.getElementById('result');

    if(twoNamePattern.test(text)) {

        match = twoNamePattern.exec(text);
        passengerName = `${match[1]} ${match[2]}`;

    } else if(threeNamePattern.test(text)) {

        match = threeNamePattern.exec(text);
        passengerName = `${match[1]} ${match[2]} ${match[3]}`;
    }

    match = flightNumberPattern.exec(text);
    flightNumber = match[1];

    match = airPortPattern.exec(text);
    airPortName = `${match[1]} to ${match[2]}`;

    match = companyPattern.exec(text);
    companyName = `${match[1]} ${match[2]}`;

    if(parameter === 'name') {

        result.textContent = `Mr/Ms, ${passengerName}, have a nice flight!`
        
    } else if(parameter === 'flight') {

        result.textContent = `Your flight number ${flightNumber} is from ${airPortName}.`

    } else if(parameter === 'company') {
        
        result.textContent = `Have a nice flight with ${companyName}.`

    } else if(parameter === 'all') {

        result.textContent = `Mr/Ms, ${passengerName}, your flight number ${flightNumber} is from ${airPortName}. Have a nice flight with ${companyName}.`
    }
}