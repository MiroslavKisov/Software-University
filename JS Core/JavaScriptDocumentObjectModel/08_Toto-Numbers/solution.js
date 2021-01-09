function solve() {
	
	let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', getNumbers);

	function getNumbers() {

		let inputFieldValue = document.getElementsByTagName('input')[0].value;
		let numbers = inputFieldValue.split(' ');
		let resultDiv = document.getElementById('allNumbers');

		for (let num of numbers) {
            if (num < 1 || num > 49) {
                return;
            }
        }
 
        if (numbers.length !== 6) {
            return;
        }

		for(let i = 0; i < 49; i++) {

			let div = document.createElement('div');
			div.textContent = i + 1;
			div.classList.add('numbers');
				
			for(let j = 0; j < numbers.length; j++) {
					
				if(numbers[j] === div.textContent) {
						
					div.style.background = 'orange';
				}
			}
				
			resultDiv.appendChild(div);

			document.getElementsByTagName('input')[0].setAttribute('disabled', 'true');
        	document.getElementsByTagName('button')[0].setAttribute('disabled', 'true');
		}
	}
}
