function solve(firstNumber, secondNumber) {
    let n = Number(firstNumber);
    let m = Number(secondNumber);
    let result = 0;

    for(let i = n; i <= m; i++)
    {
        result += i;
    }
    return result;
}

solve('1','5');