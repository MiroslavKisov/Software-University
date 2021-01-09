function getNext() {
    
    let input = document.getElementById('num');
    let num = Number(input.value);
    let span = document.getElementById('result');
    let result;

    if(!Number.isInteger(num) || num < 1) {

        return;
    }
    
    span.textContent = getSequence(num).join(' ').toString() + ' ';

    function getSequence(num) {
        
        let numbers = [];
        numbers.push(num);

        while(num > 1) {

            if(num % 2 === 0) {

                num = Math.trunc(num / 2);

            } else if(num % 2 !== 0) {

                num = (num * 3) + 1;
            }

            numbers.push(num)
        }

        return numbers;
    }
}