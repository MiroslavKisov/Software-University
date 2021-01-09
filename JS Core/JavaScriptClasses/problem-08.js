class Kitchen {
    constructor(budget) {
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(productsInfo) {

        this.actionsHistory = [];

        for(let product of productsInfo) {
            
            let currentProductInfo = product.split(' ');
            let productName = currentProductInfo[0];
            let productQuantity = Number(currentProductInfo[1]);
            let productPrice = Number(currentProductInfo[2]);

            if(this.budget >= productPrice) {

                this.budget -= productPrice;

                if(!this.productsInStock.hasOwnProperty(productName)) {

                    this.productsInStock[productName] = productQuantity;
    
                } else {
    
                    this.productsInStock[productName] += productQuantity;
                }

                let successMessage = `Successfully loaded ${productQuantity} ${productName}`;
                this.actionsHistory.push(successMessage);

            } else {

                let errorMessage = `There was not enough money to load ${productQuantity} ${productName}`;
                this.actionsHistory.push(errorMessage);
            }
        }

        return this.actionsHistory.join('\n');
    }

    addToMenu(mealName, mealProducts, mealPrice) {

        if(!this.menu.hasOwnProperty(mealName)) {

            this.menu[mealName] = {
                products : mealProducts,
                price : Number(mealPrice),
            };

            return `Great idea! Now with the ${mealName} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
        }

        else {

            return `The ${mealName} is already in our menu, try something different.`;
        }
    }

    showTheMenu() {
        let result = ''

        if(Object.keys(this.menu).length > 0) {

            for(let meals of Object.entries(this.menu)) {
                
                result += `${meals[0]} - $ ${meals[1][Object.keys(meals[1])[1]]}\n`;
            }

        } else {

            result = `Our menu is not ready yet, please come later...`;
        }

        return result;
    }

    makeTheOrder(orderedMenu) {

        if(this.menu.hasOwnProperty(orderedMenu)) {

            let targetMeal = this.menu[orderedMenu];
            
            for(let product of targetMeal.products) {

                let productInfo = product.split(' ');
                let productName = productInfo[0];
                let productQuantity = Number(productInfo[1]);
                let productInStockQuantity = Number(this.productsInStock[productName]); 

                if(!this.productsInStock.hasOwnProperty(productName) ||
                productInStockQuantity < productQuantity) {

                    return `For the time being, we cannot complete your order (${orderedMenu}), we are very sorry...`;
                }
            }

            this.budget += this.menu[orderedMenu].price;

            for(let product of targetMeal.products) {

                let productInfo = product.split(' ');
                let productName = productInfo[0];
                let productQuantity = Number(productInfo[1]);

                this.productsInStock[productName] -= productQuantity;
            }

            return `Your order (${orderedMenu}) will be completed in the next 30 minutes and will cost you ${this.menu[orderedMenu].price}.`;
        }

        return `There is not ${orderedMenu} yet in our menu, do you want to order something else?`;
    }
}



