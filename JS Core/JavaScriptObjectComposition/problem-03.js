function solve(carInfo) {
    let smallEngine = {
        power: 90, 
        volume: 1800
    };

    let normalEngine = {
        power: 120, 
        volume: 2400
    };

    let monsterEngine = {
        power: 200, 
        volume: 3500
    };

    let hatchback = {
        type: 'hatchback', 
        color: carInfo.color
    };

    let coupe = {
        type: 'coupe', 
        color: carInfo.color
    };

    let resultCar = {};

    resultCar.model = carInfo.model;

    if(carInfo.power <= 90) {
        resultCar.engine = smallEngine;
    } else if(carInfo.power > 90 && carInfo.power <= 120) {
        resultCar.engine = normalEngine;
    } else if(carInfo.power > 120) {
        resultCar.engine = monsterEngine;
    }

    if(carInfo.carriage === 'hatchback') {
        resultCar.carriage = hatchback;
    } else if(carInfo.carriage === 'coupe') {
        resultCar.carriage = coupe;
    }

    if(carInfo.wheelsize % 2 === 0) {
        carInfo.wheelsize--;
    }

    resultCar.wheels = [];

    for(let i = 0; i < 4; i++) {
        resultCar.wheels.push(carInfo.wheelsize);
    }

    return resultCar;
}