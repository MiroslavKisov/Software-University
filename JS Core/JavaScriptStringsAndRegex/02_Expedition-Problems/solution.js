function solve() {
    let string = document.getElementById('str').value;
    let text = document.getElementById('text').value;

    //let pattern = /(north|east)([^0-9]*)([0-9]{2})([^,]*)(,{1})([^0-9]*)([0-9]{6})/gi;
    let pattern = /(north|east)[\s\S]*?([0-9]{2})[^,]*?,[^,]*?([0-9]{6})/gi;
    let messagePattern = new RegExp(`${string}(.*?)${string}`, "g");
    let matches = text.match(pattern);
    let match;

    let north = '';
    let east = '';

    while((match = pattern.exec(text)) !== null) {
        if (match.index === pattern.lastIndex) {
          pattern.lastIndex++;
        }

        if(match[1].toLowerCase() === 'north') {
          north = `${match[2]}.${match[3]} N`;

        } else if(match[1].toLowerCase() === 'east') {
          east = `${match[2]}.${match[3]} E`;
        }
    }

    let messageMatch = messagePattern.exec(text);
    let message = messageMatch[1];

    let pNorth = document.createElement('p');
    pNorth.textContent = north;

    let pEast = document.createElement('p');
    pEast.textContent = east;

    let pMessage = document.createElement('p');
    pMessage.textContent = `Message: ${message}`;

    let result = document.getElementById('result');

    result.appendChild(pNorth);
    result.appendChild(pEast);
    result.appendChild(pMessage);
}