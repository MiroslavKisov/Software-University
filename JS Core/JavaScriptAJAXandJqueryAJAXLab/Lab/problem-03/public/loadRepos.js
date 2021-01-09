function loadRepos() {
    $('#repos').empty();

    let url = "https://api.github.com/users/" + 
    $("#username").val() + "/repos";

    $.ajax({
        method: 'GET',
        url : url,
        success : displayRepos,
        error : displayError,
    });

    function displayRepos(data) {
        $('#repos').empty();

        for(const repo of data) {
            let anchor = $('<a>').text(repo.full_name);
            anchor.attr('href', repo.html_url);
            $('#repos').append($('<li>').append(anchor));
        }
    }

    function displayError(error) {
        $('#repos').empty();

        $('#repos').append($('<li>').text('Error'));
    }
}