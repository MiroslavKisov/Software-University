function solve() {
    let buttons = document.getElementsByTagName('button');
    let furnitureList = document.getElementById('furniture-list');

    let result = {
      furnitureNames: [],
      totalPrice: 0,
      averageDecoration: 0,
    }

    let generateButton = buttons[0].addEventListener('click', () => {

    let furnitures = JSON.parse(document.getElementsByTagName('textarea')[0].value);

    for(let i = 0; i < furnitures.length; i++) {

        let furniture = document.createElement('div');
        furniture.classList.add('furniture');

        let name = furnitures[i].name;
        let image = furnitures[i].img;
        let price = furnitures[i].price;
        let decFactor = furnitures[i].decFactor;

        let pName = document.createElement('p');
        pName.textContent = `Name: ${name}`;
        furniture.appendChild(pName);

        let imageElement = document.createElement('img');
        imageElement.setAttribute('src', image);
        furniture.appendChild(imageElement);

        let pPrice = document.createElement('p');
        pPrice.textContent = `Price: ${price}`;
        furniture.appendChild(pPrice);

        let pDecoration = document.createElement('p');
        pDecoration.textContent = `Decoration factor: ${decFactor}`;
        furniture.appendChild(pDecoration);
      
        let checkBox = document.createElement('input');
        checkBox.setAttribute('type', 'checkbox');
        furniture.appendChild(checkBox);

        furnitureList.appendChild(furniture);
      }
  });

  let buyButton = buttons[1].addEventListener('click', () => {

      let textArea = document.getElementsByTagName('textarea')[1];
      let furnitureListElements = furnitureList.children;
      let numberOfFurnitures = 0;

      for(let i = 0; i < furnitureListElements.length; i++) {

          if(furnitureListElements[i].children[4].checked) {

              result.totalPrice += +furnitureListElements[i].children[2].textContent.split(': ')[1];
              result.averageDecoration += +furnitureListElements[i].children[3].textContent.split(': ')[1];
              result.furnitureNames.push(furnitureListElements[i].children[0].textContent.split(': ')[1]);
              numberOfFurnitures++;
          }
      }

      result.averageDecoration = result.averageDecoration / numberOfFurnitures; 

      textArea.value += `Bought furniture: ${result.furnitureNames.join(', ')}\n`;
      textArea.value += `Total price: ${result.totalPrice.toFixed(2)}\n`;
      textArea.value += `Average decoration factor: ${result.averageDecoration}`;
  });
}