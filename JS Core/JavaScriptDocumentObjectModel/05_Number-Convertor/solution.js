function solve() {

    let selectMenu = document.getElementById('selectMenuTo');
    let selectMenuOptions = selectMenu.children;

    let binaryOption = selectMenuOptions[0];
    let hexOption = document.createElement('option');

    hexOption.textContent = 'Hexadecimal';
    hexOption.value = 'hexadecimal';
    
    binaryOption.textContent = 'Binary';
    binaryOption.value = 'binary';

    selectMenu.appendChild(hexOption);

    let buttons = document.getElementsByTagName('button');
    let button = buttons[0];

    console.log(selectMenuOptions);

    button.addEventListener('click', function() { convert(selectMenu) });

    function convert(selectMenu) {

        let inputField = document.getElementById('input');
        let resultField = document.getElementById('result');

        let number = inputField.value;
        let result;

        if(selectMenu.value === 'binary') {

            result = decimalToBinary(number);

        } else if (selectMenu.value === 'hexadecimal') {
            
            result = decimalToHexadecimal(number);
        }

        resultField.value = result;
    }

    function decimalToHexadecimal(inputNum) {

        let hex = Number(inputNum).toString(16);
        return hex.toUpperCase();
    }

    function decimalToBinary(inputNum) {

        inputNum = Number(inputNum);
        let result = inputNum.toString(2);

        return result;
    }
}