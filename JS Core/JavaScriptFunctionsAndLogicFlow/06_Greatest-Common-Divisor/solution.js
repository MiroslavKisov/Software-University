function greatestCD() {
    
    let inputOne = document.getElementById('num1');
    let inputTwo = document.getElementById('num2');
    let numOne = Number(inputOne.value);
    let numTwo = Number(inputTwo.value);
    let span = document.getElementById('result');

    function gcd(numOne,numTwo) {

        numOne = Math.abs(numOne);
        numTwo = Math.abs(numTwo);

        if (numTwo > numOne) {

            let temp = numOne; numOne = numTwo; numTwo = temp;
        }

        while (true) {

            if (numTwo == 0) { 

                return numOne; 
            }

            numOne %= numTwo;

            if (numOne == 0) {

                return numTwo; 
            }

            numTwo %= numOne;
        }
    }

    let result = gcd(numOne, numTwo);

    span.textContent = result
}