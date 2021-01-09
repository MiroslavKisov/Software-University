function create(arr) {
    for(let i = 0; i < arr.length; i++) {
        let div = $('<div>').on('click', showContent);
        let p = $('<p>').text(arr[i]).css('display', 'none');

        div.append(p);
        $('#content').append(div);
    }

    function showContent() {
        let p = $(this).children().css('display', 'block');
    }
}