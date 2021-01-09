function solve() {
    
    let products = document.getElementsByClassName('product');
    let textArea = document.getElementsByTagName('textarea')[0];
    let productNames = [];
    let sum = 0;

    for(let i = 0; i < products.length; i++) {

        let productInfo = products[i].children;
        let productName = productInfo[1].innerHTML;
        let productPrice = Number(productInfo[2].innerHTML.split(' ')[1]);

        productInfo[3].addEventListener('click', () => {

            if(!productNames.includes(productName)) {
                productNames.push(productName);
            }

            sum += productPrice;
            textArea.value += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
        });
    }

    let buyButton = document.getElementsByTagName('button')[3].addEventListener('click', () => {

        textArea.value += `You bought ${productNames.join(', ')} for ${sum.toFixed(2)}.\n`;                    
    });
}