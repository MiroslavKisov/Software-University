$(() => {

    renderCatTemplate();
    attachEvents();

    function renderCatTemplate() {
        let source = $('#cat-template').html();
        let template = Handlebars.compile(source);

        let html = template({cats : window.cats});

        $('#allCats').append(html);
    }

    function attachEvents() {

        for(const cat of window.cats) {

            $(`#${cat.id}`).prev().on('click', showStatusCode.bind(this, cat.id));
        }
    }

    function showStatusCode(catId) {
        
        $(`#${catId}`).toggle();
    }
})
