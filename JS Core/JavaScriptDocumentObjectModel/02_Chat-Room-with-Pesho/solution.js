function solve() {

    let buttons = Array.from(document.getElementsByTagName('button'))
                    .forEach((btn) => btn.addEventListener('click', doChat));

    function doChat(event) {

        let button = event.target.name;
        
        let div = document.createElement('div');
        let span = document.createElement('span');
        let p = document.createElement('p');
        div.appendChild(span);
        div.appendChild(p);

        if(button === 'myBtn') {

            let myInput = document.getElementById('myChatBox').value;
            document.getElementById('myChatBox').value = '';
            span.textContent = 'Me';
            p.textContent = myInput;

            div.style.textAlign = 'left';

        } else if(button === 'peshoBtn') {

            let peshoInput = document.getElementById('peshoChatBox').value;
            document.getElementById('peshoChatBox').value = '';
            span.textContent = 'Pesho';
            p.textContent = peshoInput;

            div.style.textAlign = 'right';
        }

        let chronologyDiv = document.getElementById('chatChronology');
        chronologyDiv.appendChild(div);
    }
}