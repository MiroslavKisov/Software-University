function attachEvents() {
    
    $('#btnLoad').on('click', loadContacts);
    $('#btnCreate').on('click', createContact);
    let url = ``;

    function loadContacts() {

        let contactList = $('#phonebook');
        contactList.empty();

        $.ajax({
           method : 'GET',
           url : url + '.json',
           success : displayContacts,
           error : displayError
        });

        function displayContacts(data) {
            let contacts = Object.entries(data);

            for(const contact of contacts) {

                let deleteButton = $('<button>').text('Delete').addClass('.button').on('click', deleteContact.bind(this, contact[0]));
                let contactItem = $('<li>').text(`${contact[1].person}: ${contact[1].phone}`).append(deleteButton);
                contactList.append(contactItem);
            }
        }

    }

    function displayError() {
        $("#phonebook").append($("<li>Error</li>"));
    }

    function deleteContact(key) {
        $.ajax({
            method : 'DELETE',
            url : url + '/' + key + '.json',
            success : loadContacts,
            error : displayError,
        });
    }

    function createContact() {

        let personName = $('#person').val();
        let personPhone = $('#phone').val();

        let personObj = {

            person : personName,
            phone : personPhone,
        };

        $.ajax({
            method : 'POST',
            url : url + '.json',
            data : JSON.stringify(personObj),
            success : loadContacts,
            error : displayError,
        });

        $('#person').val('');
        $('#phone').val('');
    }
}
