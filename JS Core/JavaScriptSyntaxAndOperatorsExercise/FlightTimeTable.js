function solve(args) {

    let type = args[0];
    let city = args[1];
    let time = args[2];
    let flightNumber = args[3];
    let gate = args[4];

    console.log(`${type}: Destination - ${city}, Flight - ${flightNumber}, Time - ${time}, Gate - ${gate}`);
}

solve(['Departures', 'London', '22:45', 'BR117', '42']);