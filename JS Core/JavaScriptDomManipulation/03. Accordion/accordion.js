function toggle() {
    let button = $('.button');
    let textPanel = $('#extra');
    
    if(textPanel.css('display') === 'none') {

        textPanel.css('display', 'block');
        button.text('Less');

    } else if(textPanel.css('display') === 'block') {

        textPanel.css('display', 'none');
        button.text('More');
    }
}