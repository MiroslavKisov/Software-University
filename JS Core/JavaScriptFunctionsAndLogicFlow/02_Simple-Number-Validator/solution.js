function validate() {
    
    let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', check);

    function check() {

        let weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];
        let input = document.getElementsByTagName('input')[0];
        let span = document.getElementById('response');
        let inputValue = input.value;
        let numbers = inputValue.split('').map(Number);
        let result = 0;

        if(numbers.length !== 10) {

            span.textContent = 'This number is NOT Valid!';
            return;
        }

        for(let i = 0; i < weights.length; i++) {

            result += (weights[i] * numbers[i]);
        }

        result = result % 11;

        if(result === 10) {

            result = 0;
        }

        if(result === numbers[9]) {

            span.textContent = 'This number is Valid!';
            return;
            
        } else if(result !== numbers[9]) {

            span.textContent = 'This number is NOT Valid!';
            return;
        }
    }
}