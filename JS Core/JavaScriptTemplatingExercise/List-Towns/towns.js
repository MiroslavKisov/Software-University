function attachEvents() {

    let selectors = {
        btnLoadTowns : '#btnLoadTowns',
        towns : '#towns',
        root : '#root',
        townsTemplate : '#towns-template',
    }

    $(selectors.btnLoadTowns).on('click', loadTowns);

    function loadTowns() {

        let townsInfo = $(selectors.towns).val().split(', ').map(townName => {
            return { townName : townName }
        });

        let source = $(selectors.townsTemplate).html();
        let template = Handlebars.compile(source);
        
        let rendered = template({townsInfo});

        $(selectors.root).append(rendered);
    }
}