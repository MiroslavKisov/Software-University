function solve() {
    let playerOne = document.getElementById('player1Div');
    let playerOneCards = playerOne.getElementsByTagName('img');
    
    Array.from(document
        .getElementById('player1Div')
        .getElementsByTagName('img'))
        .forEach((img) => img.addEventListener('click', addEvents));
    
    Array.from(document
        .getElementById('player2Div')
        .getElementsByTagName('img'))
        .forEach((img) => img.addEventListener('click', addEvents));

    function addEvents(e) {
        let card = e.target;
        card.src = './images/whiteCard.jpg'
        let parent = card.parentNode;
        let spans = document.getElementById('result').children;
        let leftSpan = spans[0];
        let rightSpan = spans[2];

        if(parent.id === 'player1Div') {
            leftSpan.textContent = card.name;
        }
        else if(parent.id === 'player2Div') {
            rightSpan.textContent = card.name;
        }

        if(spans[0].textContent && spans[2].textContent) {

            let winner;
            let looser;

            if(Number(leftSpan.textContent) > Number(rightSpan.textContent)) {
                winner = document.querySelector(`#player1Div img[name="${leftSpan.textContent}"]`);
                looser = document.querySelector(`#player2Div img[name="${rightSpan.textContent}"]`);
            }
            else if (Number(leftSpan.textContent) < Number(rightSpan.textContent)) {
                winner = document.querySelector(`#player2Div img[name="${rightSpan.textContent}"]`);
                looser = document.querySelector(`#player1Div img[name="${leftSpan.textContent}"]`);
            }

            winner.style.border = '2px solid green';
            looser.style.border = '2px solid red';

            document.getElementById('history').textContent += `[${leftSpan.textContent} vs ${rightSpan.textContent}] `;

            leftSpan.textContent = "";
            rightSpan.textContent = "";
        }
    }
}