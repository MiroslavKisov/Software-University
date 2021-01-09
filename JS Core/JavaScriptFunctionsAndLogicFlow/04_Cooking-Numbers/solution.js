function solve() {

    Array.from(document.getElementsByTagName('button'))
            .forEach(button => button.addEventListener('click', performOperation));

    function performOperation(event) {

        let button = event.target.textContent;
        let initialValue = document.getElementsByTagName('input')[0].value;

        if(initialValue === '') {
            
            initialValue = 0;

        }

        let p = document.getElementById('output');
        
        if(button === 'Chop') {

            if(p.textContent === '') {
                
                p.textContent = initialValue / 2;

            } else {

                p.textContent = p.textContent / 2;
            }

        } else if(button === 'Dice') {

            if(p.textContent === '') {
                
                p.textContent = Math.sqrt(initialValue);

            } else {

                p.textContent = Math.sqrt(p.textContent);
            }

        } else if(button === 'Spice') {

            if(p.textContent === '') {
                
                p.textContent = Number(initialValue) + 1;

            } else {

                p.textContent = Number(p.textContent) + 1;
            }

        } else if(button === 'Bake') {

            if(p.textContent === '') {
                
                p.textContent = initialValue * 3;

            } else {

                p.textContent = p.textContent * 3;
            }

        } else if(button === 'Fillet') {

            if(p.textContent === '') {

                p.textContent = initialValue * 0.8;

            } else {

                p.textContent = p.textContent * 0.8;
            }
        }
    }
}
