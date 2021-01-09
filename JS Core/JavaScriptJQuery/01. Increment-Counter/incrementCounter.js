function increment(selector) { 
    let textArea = $('<textarea>').prop('disabled', true).addClass('counter').val(0);
    textArea.appendTo(selector);

    let incrementBtn = $('<button>').addClass('btn').attr('id', 'incrementBtn').text('Increment').click(incrementValue);
    incrementBtn.appendTo(selector);

    let addBtn = $('<button>').addClass('btn').attr('id', 'addBtn').text('Add').click(addItem);
    addBtn.appendTo(selector);

    let unorderedList = $('<ul>').addClass('results');
    unorderedList.appendTo(selector);

    function incrementValue() {
        let value = Number(textArea.val());
        value++;
        textArea.val(value);
    }

    function addItem() {
        let listItem = $('<li>').text(textArea.val());
        listItem.appendTo(unorderedList);
    }
}
