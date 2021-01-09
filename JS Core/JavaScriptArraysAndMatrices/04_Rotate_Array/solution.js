function solve(input) {

    let numberOfRotations = input[input.length - 1];

    input.pop();

    if(numberOfRotations > input.length) {

        numberOfRotations = input.length % numberOfRotations;
    }

    for(let i = 0; i < numberOfRotations; i++) {
        
        input.unshift(input[input.length - 1]);
        input.pop();
    }

    console.log(input.join(' '));
}

solve([1, 2, 3, 4, 12]);