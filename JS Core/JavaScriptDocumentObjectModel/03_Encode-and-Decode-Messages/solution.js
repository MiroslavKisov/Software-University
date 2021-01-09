function solve() {
	
	let buttons = document.getElementsByTagName('button');

	let encodeAndSendButton = buttons[0];
	let decodeAndReadButton = buttons[1];

	encodeAndSendButton.addEventListener('click', encodeAndSend);
	decodeAndReadButton.addEventListener('click', decodeAndRead);

	let textFields = document.getElementsByTagName('textarea');

	let textFieldSender = textFields[0];
	let textfieldReceiver = textFields[1];
	

	function encodeAndSend() {

		let textValue = textFieldSender.value;
		let encodedMessage = '';

		for(let i = 0; i < textValue.length; i++) {

			encodedMessage += String.fromCharCode(textValue.charCodeAt(i) + 1);
		}

		textFieldSender.value = '';
		textfieldReceiver.value = encodedMessage;
	}

	function decodeAndRead() {

		if(textfieldReceiver.value) {

			let textValue = textfieldReceiver.value;
			let decodedMessage = '';

			for(let i = 0; i < textValue.length; i++) {

				decodedMessage += String.fromCharCode(textValue.charCodeAt(i) - 1);
			}

			textfieldReceiver.value = decodedMessage;
		}
	}
}