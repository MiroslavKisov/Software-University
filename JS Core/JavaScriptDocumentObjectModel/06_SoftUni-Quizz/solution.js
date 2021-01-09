function solve() {
	
	let buttons = document.getElementsByTagName('button');
	let correctAnswers = {};
	let answerCount = 1;
	let correctAnswersCount = 0;

	Array.from(buttons).forEach((button) => button.addEventListener('click', doQuiz));

	function doQuiz(e) {

		let button = e.target;
		let section = e.target.parentNode;
		let sections = document.getElementsByTagName('section');
		let answers = Array.from(section.getElementsByTagName('input'));
		let answer = answers.filter(e => e.checked)[0];

		if(answer) {

			if(answerCount < 3) {
				sections[answerCount].style.display = 'inline';
				answerCount++;
			}

			if(answer.value === '2013') {

				correctAnswersCount++;

			} else if(answer.value === 'Pesho' && answer.name === 'popularName') {

				correctAnswersCount++;

			} else if(answer.value === 'Nakov') {

				correctAnswersCount++;
			}
		}
		else {
			
			return;
		}

		if (button.textContent === 'Get the results') {

			let resultDiv = document.getElementById('result');

			if (correctAnswersCount === 3) {

				resultDiv.textContent = 'You are recognized as top SoftUni fan!'

			} else if (correctAnswersCount < 3) {

				resultDiv.textContent = `You have ${correctAnswersCount} right answers`;
			}
		}
	}
}