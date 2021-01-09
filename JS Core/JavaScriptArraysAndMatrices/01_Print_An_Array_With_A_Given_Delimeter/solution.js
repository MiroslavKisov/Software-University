function solve(input) {
    
    let delimeter = input[input.length - 1];
    input.pop();
    let numbers = input.join(delimeter);
    console.log(numbers);
}

solve();