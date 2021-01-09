function solve() {

    let buttons = document.getElementsByTagName('button');
    let tableBody = document.getElementsByTagName('tbody')[0];
    let userInfo = document.getElementsByTagName('input');

    let userData = [];

    buttons[0].addEventListener('click', (e) => {

        e.preventDefault();

        let user = {

            username: '',
            password: '',
            email: '',
            topics: []
        };

        user.username = userInfo[0].value;
        user.password = userInfo[1].value;
        user.email = userInfo[2].value;

        for(let i = 3; i < userInfo.length; i++) {

            if(userInfo[i].checked) {
                user.topics.push(userInfo[i].value);
            }
        }

        userData.push(user);

        let tableRow = document.createElement('tr');

        let usernameData = document.createElement('td');
        usernameData.textContent = user.username;

        let emailData = document.createElement('td');
        emailData.textContent = user.email;

        let topicsData = document.createElement('td');
        topicsData.textContent = user.topics.join(' ');

        tableRow.appendChild(usernameData);
        tableRow.appendChild(emailData);
        tableRow.appendChild(topicsData);

        tableBody.appendChild(tableRow);
    });

    buttons[1].addEventListener('click', (e) => {

        e.preventDefault();
        let searchValue = userInfo[7].value.toLowerCase();

        let tableRows = tableBody.children;
        Array.from(tableRows).forEach(x => x.style.visibility = 'hidden');

        for(let i = 0; i < tableRows.length; i++) {

            let tableData = tableRows[i].children;

            for(let j = 0; j < tableData.length; j++) {

                if(tableData[j].textContent.toLowerCase().includes(searchValue)) {

                    tableRows[i].style.visibility = 'visible';
                }
            }
        }
    });
}