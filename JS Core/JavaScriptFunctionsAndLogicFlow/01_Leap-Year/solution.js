function leapYear() {
    
    let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', getYear);

    function getYear() {

        let divYear = document.getElementById('year').children;
        let h2 = divYear[0];
        let div = divYear[1];
        let input = document.getElementsByTagName('input')[0];
        let year = input.value;
        let isLeap = (year) => new Date(year, 1, 29).getDate() === 29;

        if(Number(year) > 0) {

            if(isLeap(year) === true) {

                h2.textContent = 'Leap Year';
                div.textContent = year;
    
            } else {
                
                h2.textContent = 'Not Leap Year';
                div.textContent = year;
    
            }

        }

        input.value = '';
    }
}