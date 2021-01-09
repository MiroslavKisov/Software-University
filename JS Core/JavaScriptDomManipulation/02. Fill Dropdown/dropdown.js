function addItem() {
    let itemText = document.getElementById('newItemText').value;
    let itemValue = document.getElementById('newItemValue').value;

    let menu = document.getElementById('menu');
    let option = document.createElement('option');

    option.textContent = itemText;
    option.value = itemValue;

    menu.appendChild(option);

    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}