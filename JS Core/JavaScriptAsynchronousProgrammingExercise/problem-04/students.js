function attachEvents() {

    let selectors = {
        id : '#studentId',
        firstName : '#firstName',
        lastName : '#lastName',
        facultyNumber : '#facultyNumber',
        grade : '#grade',
        results : '#results',
        createStudent : '#createStudent',
        showStudents : '#showStudents',
        message : '#message',
        errorMessage : 'errorMessage',
        successMessage : 'successMessage'
    };

    $(selectors.createStudent).on('click', createStudent);
    $(selectors.showStudents).on('click', showStudents);
    let messageDiv = $(selectors.message);


    const baseUrl = 'https://baas.kinvey.com/appdata/';
    const endPoint = 'students'
    const appId = '';
    const username = 'guest';
    const password = 'guest';
    const base64auth = btoa(username + ":" + password);
    const headers = {
        "Authorization": "Basic " + base64auth, "Content-Type": "application/json"
    };

    async function createStudent() {
        
        let id = Number($(selectors.id).val());
        let firstName = $(selectors.firstName).val();
        let lastName = $(selectors.lastName).val();
        let facultyNumber = $(selectors.facultyNumber).val();
        let grade = Number($(selectors.grade).val());

        let student = {
            ID : id,
            FirstName : firstName,
            LastName : lastName,
            FacultyNumber : facultyNumber,
            Grade : grade,
        };

        try {
            await $.ajax({
                method : 'POST',
                url : baseUrl + appId + '/' + endPoint,
                headers : headers,
                data : JSON.stringify(student),
                success : displaySuccessMessage,
            });

        } catch(error) {

            displayErrorMessage();
            console.log(error);
        }

        $(selectors.id).val('');
        $(selectors.firstName).val('');
        $(selectors.lastName).val('');
        $(selectors.facultyNumber).val('');
        $(selectors.grade).val('');
    }

    async function showStudents() {

        try {
            await $.ajax({
                method : 'GET',
                url : baseUrl + appId + '/' + endPoint,
                headers : headers,
                success : displayStudents,
            });
        } catch(error) {

            displayErrorMessage();
            console.log(error);
        }
    }

    function displayStudents(studentsInfo) {
        let studentsTable = $(selectors.results);

        for(const student of studentsInfo.sort((a,b) => a.ID - b.ID)) {
            studentsTable.append(
            `<tr>
                <td>${student.ID}</td>
                <td>${student.FirstName}</td>
                <td>${student.LastName}</td>
                <td>${student.FacultyNumber}</td>
                <td>${student.Grade}</td>
            </tr>`)
        }
    }

    function displayErrorMessage() {

        messageDiv.removeClass(selectors.successMessage);

        messageDiv.addClass(selectors.errorMessage)
        .text('ERROR!')
        .fadeOut(5000);
    }

    function displaySuccessMessage() {

        messageDiv.removeClass(selectors.errorMessage);

        messageDiv.addClass(selectors.successMessage)
        .text('You have succesfully added a student')
        .fadeOut(5000);
    }
}
