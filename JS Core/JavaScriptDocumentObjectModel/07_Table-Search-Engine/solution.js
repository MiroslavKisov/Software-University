function solve() {
    
    let button = document.getElementById('searchBtn');
    button.addEventListener('click', search);

    function search() {

        let searchField = document.getElementById('searchField');
        let searchValue = searchField.value.toLowerCase();
        let tableRows = Array.from(document.getElementsByTagName('tr')).slice(2);

        tableRows.forEach(x => x.setAttribute('class', ''));

        for(let i = 0; i < tableRows.length; i++) {

            let currentRow = tableRows[i].textContent.toLowerCase().trim();
            currentRow = currentRow.replace(/(\r\n|\n|\r)/gm, "");

            if(currentRow.includes(searchValue)) {

                tableRows[i].setAttribute('class', 'select');
            }
        }

        searchField.value = '';
    }
}