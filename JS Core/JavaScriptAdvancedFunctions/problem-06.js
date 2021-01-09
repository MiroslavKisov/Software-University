function solution() {

    let wareHouse = {

        'protein' : 0,
        'carbohydrate' : 0,
        'fat' : 0,
        'flavour' : 0,
    };

    return function(input) {
        
        let commandArgs = input.split(' ');

        let command;
        let product;
        let quantity;

        command = commandArgs[0];

        if(commandArgs.length === 3) {

            product = commandArgs[1];
            quantity = commandArgs[2];
        }

        if(command === 'report') {

            return `protein=${wareHouse.protein} carbohydrate=${wareHouse.carbohydrate} fat=${wareHouse.fat} flavour=${wareHouse.flavour}`;

        } else if(command === 'restock') {

            wareHouse[product] += +quantity;
            return 'Success';

        } else if(command === 'prepare') {

            if(product === 'apple') {

                if(wareHouse.carbohydrate <= 1  * quantity) {

                    return 'Error: not enough carbohydrate in stock';
                } 

                if(wareHouse.flavour < 2 * quantity) {

                    return 'Error: not enough flavour in stock';
                }
                
                wareHouse.carbohydrate -= 1 * quantity;
                wareHouse.flavour -= 2 * quantity;

                return 'Success';

            } else if(product === 'coke') {

                if(wareHouse.carbohydrate < 10 * quantity) {

                    return 'Error: not enough carbohydrate in stock';
                }

                if(wareHouse.flavour < 20 * quantity) {

                    return 'Error: not enough flavour in stock';
                }

                wareHouse.carbohydrate -= 10 * quantity;
                wareHouse.flavour -= 20 * quantity;

                return 'Success';

            } else if(product === 'omelet') {

                if(wareHouse.protein < 5 * quantity) {

                    return 'Error: not enough protein in stock';
                } 

                if(wareHouse.fat < 1 * quantity) {

                    return 'Error: not enough fat in stock';
                } 

                if(wareHouse.flavour < 1 * quantity) {

                    return 'Error: not enough flavour in stock';
                }

                wareHouse.protein -= 5 * quantity;
                wareHouse.fat -= 1 * quantity;
                wareHouse.flavour -= 1 * quantity;

                return 'Success';

            } else if(product === 'burger') {

                if(wareHouse.carbohydrate < 5 * quantity) {

                    return 'Error: not enough carbohydrate in stock';
                }

                if(wareHouse.fat < 7 * quantity) {

                    return 'Error: not enough fat in stock';
                }

                if(wareHouse.flavour < 3 * quantity) {

                    return 'Error: not enough flavour in stock';
                }

                wareHouse.carbohydrate -= 5 * quantity;
                wareHouse.fat -= 7 * quantity;
                wareHouse.flavour -= 3 * quantity;

                return 'Success';

            } else if(product === 'cheverme') {

                if(wareHouse.protein < 10 * quantity) {

                    return 'Error: not enough protein in stock';
                }

                if(wareHouse.carbohydrate < 10 * quantity) {

                    return 'Error: not enough carbohydrate in stock';
                }

                if(wareHouse.fat < 10 * quantity) {

                    return 'Error: not enough fat in stock';
                }

                if(wareHouse.flavour < 10 * quantity) {

                    return 'Error: not enough flavour in stock';
                }

                wareHouse.protein -= 10 * quantity
                wareHouse.carbohydrate -= 10 * quantity;
                wareHouse.fat -= 10 * quantity;
                wareHouse.flavour -= 10 * quantity;

                return 'Success';
            }
        }
    }
}

let manager = solution();
console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));
console.log(manager('prepare cheverme 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare cheverme 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare cheverme 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare cheverme 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare cheverme 1'));
console.log(manager('report'));



