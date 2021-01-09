function solve(input) {

    if(input.length === 0) {
        
        return;
    }

    let bestSequence = [];
    let currentBiggestNumber = input[0];

    for(let i = 0; i < input.length; i++) {

        if(currentBiggestNumber <= input[i]) {

           currentBiggestNumber = input[i];
           bestSequence.push(input[i]);
        }
    }

    bestSequence.forEach(x => console.log(x));
}

solve([1, 3, 8, 4, 10, 12, 3, 2, 24])