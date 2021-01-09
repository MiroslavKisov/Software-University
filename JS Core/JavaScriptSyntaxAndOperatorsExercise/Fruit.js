function solve(fruitName, weightInGrams, pricePerKilo) {

    let weight = weightInGrams / 1000;
    let totalPrice = weight * pricePerKilo;

    console.log(`I need ${totalPrice.toFixed(2)} leva to buy ${weight.toFixed(2)} kilograms ${fruitName}.`)
}

solve('orange', 2500, 1.80);