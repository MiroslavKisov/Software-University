$(() => {
    
    renderTemplate();
    attachEvents();

    function renderTemplate() {
        let source = $('#monkey-template').html();
        let template = Handlebars.compile(source);

        let rendered = template({monkeys : window.monkeys});

        $('.monkeys').append(rendered);
    }
    
    function attachEvents() {

        for(const monkey of window.monkeys) {

            $(`#${monkey.id}`).prev().on('click', showInfo.bind(this, monkey.id));
        }
    }

    function showInfo(monkeyId) {

        $(`#${monkeyId}`).toggle();
    }
});