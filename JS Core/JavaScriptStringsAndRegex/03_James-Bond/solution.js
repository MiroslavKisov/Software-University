function solve() {
    let input = JSON.parse(document.getElementById('arr').value)

    let specialKey = input[0];
    
    let patternSpecialKey = /(^|\s)([A-Za-z]+)/g;
    
    if(!patternSpecialKey.test(specialKey)) {
        return;
    }
    
    let pattern = new RegExp(`${specialKey}[\\s]+([!#$%A-Z]{8,10000})([\\.\\,\\s]|$)`, "gmi");
    let patternMessage = /[^A-Z#$%!]/;
    let result = document.getElementById('result');

    for(let i = 1; i < input.length; i++) {

        let m;
        let line = input[i];
        let decodedMessage = '';

        while((m = pattern.exec(input[i])) !== null) {

            let encodedMessage = m[1];

            if(!patternMessage.test(encodedMessage)) {

                decodedMessage = decodeMessage(encodedMessage);
                line = line.replace(encodedMessage, decodedMessage); 
            }
        }

        let paragraph = document.createElement('p');
        paragraph.textContent = line;
        result.appendChild(paragraph);
    }

    function decodeMessage(message) {

        let messageArray = message.split('');

        for(let i = 0; i < messageArray.length; i++) {

            if(messageArray[i] === '!') {

                messageArray[i] = '1'

            } else if (messageArray[i] === '%') {

                messageArray[i] = '2'

            } else if (messageArray[i] === '#') {
                
                messageArray[i] = '3'

            } else if (messageArray[i] === '$') {
                
                messageArray[i] = '4'
            }
        }
        
        message = messageArray.join('').toLowerCase();

        return message;
    }
}
