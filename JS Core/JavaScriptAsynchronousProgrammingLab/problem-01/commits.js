function loadCommits() {
    let username = $('#username').val();
    let repository = $('#repo').val();
    let commitsList = $('#commits');

    let url = `https://api.github.com/repos/${username}/${repository}/commits`;

    $.get(url)
        .then(displayCommits)
        .catch(displayError);

    function displayCommits(data) {
        let commits = data;

        for(const commit of commits) {
            commitsList.append($('<li>').text(`${commit.commit.author.name}: ${commit.commit.message}`));
        }
    }

    function displayError(error) {
        commitsList.append($('<li>').text(`Error: ${error.status} (${error.statusText})`));
    }
}   