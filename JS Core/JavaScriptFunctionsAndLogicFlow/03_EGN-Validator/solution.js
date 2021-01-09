function validate() {
    
    let button = document.getElementsByTagName('button')[0];

    button.addEventListener('click', getEgn);

    function getEgn() {

        let weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];
        let result = '';

        let months = {

            January : '01',
            February : '02',
            March : '03',
            April : '04',
            May : '05',
            June : '06',
            July : '07',
            August : '08',
            September : '09',
            October : '10',
            November : '11',
            December : '12',
        }
        
        let yearInput = document.getElementById('year');
        let monthInput = document.getElementById('month');
        let dateInput = document.getElementById('date');
        let maleInput = document.getElementById('male');
        let femaleInput = document.getElementById('female');
        let regionInput = document.getElementById('region');

        if(yearInput.value < 1900 || 
           yearInput.value > 2100 || 
           regionInput.value < 43 || 
           regionInput.value > 999 ||
           yearInput.value === '' ||
           monthInput.value === '' ||
           maleInput.value === undefined ||
           femaleInput.value === undefined ||
           dateInput.value === '' ||
           regionInput.value === '') {

            return;
        }

        result += yearInput.value.split('').slice(2).join('');
        result += months[monthInput.value];

        let date = +dateInput.value;

        if(date < 10) {

            dateInput.value = '0' + date;  
        }

        result += dateInput.value;
        let region = regionInput.value;

        if(+region > 99) {
            
            let temp = region;
            region = temp.substring(0, temp.length - 1);
        }

        result += region;

        if(maleInput.checked) {

            result += '2';
        }
        else if(femaleInput.checked) {

            result += '1';
        }

        let numbers = result.split('').map(Number);
        let finalNumber = 0;

        for(let i = 0; i < weights.length; i++) {

            finalNumber += (weights[i] * numbers[i]);
        }

        finalNumber = finalNumber % 11;

        if(finalNumber === 10) {

            finalNumber = 0;
        }

        let finalNumberToStr = finalNumber.toString();
        result += finalNumberToStr;

        yearInput.value = '';
        document.getElementById('month').children[0].selected = 'selected';
        dateInput.value = '';
        maleInput.checked = false;
        femaleInput.checked = false;
        regionInput.value = '';

        let p = document.getElementById('egn');
        p.textContent = `Your EGN is: ${result}`;
    }
}

