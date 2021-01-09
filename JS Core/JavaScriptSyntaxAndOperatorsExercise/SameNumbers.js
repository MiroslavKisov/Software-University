function solve(num) {

    let sumDigits = 0;
    let lastDigit;
    let secondToLastDigit;
    let areSame = true;

    while(true)
    {
        lastDigit = num % 10;
        num = Math.trunc(num / 10);
        secondToLastDigit = num % 10;
        sumDigits += lastDigit;

        if (num === 0)
        {
            break;
        }

        if(lastDigit != secondToLastDigit)
        {
            areSame = false;
        }
    }

    console.log(areSame);
    console.log(sumDigits);
}

solve(1234);