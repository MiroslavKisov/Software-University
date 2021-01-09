function solve() {
    
    let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', getCards);

    function getCards() {

        let inputFrom = document.getElementById('from').value;
        let inputTo = document.getElementById('to').value;
        let option = document.getElementsByTagName('option');
        let cardsArray = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

        if(inputFrom === '' || inputTo === '') {

            return;
        }

        let cards = { 

             '2' : 2,
             '3' : 3,
             '4' : 4,
             '5' : 5,
             '6' : 6,
             '7' : 7,
             '8' : 8,
             '9' : 9,
            '10' : 10,
             'J' : 11,
             'Q' : 12,
             'K' : 13,
             'A' : 14,
        }
        
        if(!cardsArray.includes(inputFrom) || !cardsArray.includes(inputTo)) {

            return;
        }

        if(cards[inputFrom] <= cards[inputTo]) {

            for(let card in cards) {

                if(cards[card] >= cards[inputFrom] && cards[card] <= cards[inputTo]) {

                    let section = document.getElementById('cards');
                    let cardDiv = document.createElement('div');
                    section.appendChild(cardDiv);
                    cardDiv.classList.add('card');
                    let pOne = document.createElement('p');
                    let pTwo = document.createElement('p');
                    let pThree = document.createElement('p');

                    if(option[0].selected) {

                        pOne.innerHTML = '&hearts;';
                        pTwo.innerHTML = card;
                        pThree.innerHTML = '&hearts;';

                    } else if(option[1].selected) {
                        
                        pOne.innerHTML = '&spades;';
                        pTwo.innerHTML = card;
                        pThree.innerHTML = '&spades;';

                    } else if(option[2].selected) {
                        
                        pOne.innerHTML = '&diamond;';
                        pTwo.innerHTML = card;
                        pThree.innerHTML = '&diamond;';

                    }   else if(option[3].selected) {
                        
                        pOne.innerHTML = '&clubs;';
                        pTwo.innerHTML = card;
                        pThree.innerHTML = '&clubs;';
                    }

                    cardDiv.appendChild(pOne);
                    cardDiv.appendChild(pTwo);
                    cardDiv.appendChild(pThree);
                }
            }
        }
    }
}