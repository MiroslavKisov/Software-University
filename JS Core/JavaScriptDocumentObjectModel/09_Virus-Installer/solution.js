function solve() {
    
    let buttons = document.getElementsByTagName('button');
    let nextButton = buttons[0].addEventListener('click', next);
    let cancelButton = buttons[1].addEventListener('click', cancel);

    function next(e) {

        let contentDiv = document.getElementById('content');
        let firstStepDiv = document.getElementById('firstStep');
        let secondStepDiv = document.getElementById('secondStep');
        let thirdStepDiv = document.getElementById('thirdStep');
        let iAgree = document.getElementsByTagName('input')[0];
        let button = e.target;

        if(firstStepDiv.className === '') {

            contentDiv.style.backgroundImage = "url('none')";
            firstStepDiv.style.display = 'inline-block';
            firstStepDiv.classList.add('visited');

        } else if(secondStepDiv.className === '' && iAgree.checked) {

            firstStepDiv.style.display = 'none';
            secondStepDiv.style.display = 'inline-block';
            secondStepDiv.classList.add('visited');
            button.style.visibility = 'hidden';

            setTimeout(function() { button.style.visibility = 'visible' }, 3000);

        } else if (thirdStepDiv.className === '' && iAgree.checked) {

            button.style.visibility = 'hidden';
            secondStepDiv.style.display = 'none';
            thirdStepDiv.style.display = 'inline-block';
            let cancel = document.getElementsByTagName('button')[1];
            cancel.addEventListener('click', cancel);
            cancel.textContent = 'Finish';
        }
    }

    function cancel() {

        let section = document.getElementsByTagName('section')[0];
        section.style.display = 'none';
    }
}