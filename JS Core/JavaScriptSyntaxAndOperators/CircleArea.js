function solve(param) {
    let inputType = typeof(param);
    let result = 0;

    if(inputType === 'number')
    {
        result = (param ** 2) * Math.PI;
        console.log(result.toFixed(2));
    }
    else
    {
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
}

solve(5);