function validate() {
	let submitButton = $('#submit').on('click', submitForm);
	let inputIsCompanyCheckbox = $('#company').on('click', showCompanyInfo);

	function showCompanyInfo() {
		let companyInfoFieldSet = $('#companyInfo');

		if($(this).prop('checked')) {
			companyInfoFieldSet.css('display', 'inline-block');
		} else {
			companyInfoFieldSet.css('display', '');
		}
	}

	function submitForm(event) {
		event.preventDefault();

		let inputUsername = $('#username');
		let inputEmail = $('#email').css('border', '');
		let inputPassword = $('#password');
		let inputConfirmPassword = $('#confirm-password');
		let inputCompanyNumber = $('#companyNumber');

		let usernamePattern = /^([A-Za-z0-9]{3,20})$/;
		let passwordPattern = /^([^!@#$%\^&][A-Za-z0-9_]{4,14})$/;
		let emailPattern = /@.*?[.]+/;

		let isUsernameValid = usernamePattern.test(inputUsername.val());
		let isEmailValid = emailPattern.test(inputEmail.val());

		let isPasswordValid = (passwordPattern.test(inputPassword.val()))  ? true : false;

	    let isConfirmPasswordValid = (passwordPattern.test(inputConfirmPassword.val())) ? true : false;

		let arePasswordsEqual = (inputPassword.val() === inputConfirmPassword.val()) ? true : false;

		let isCompanyNumberValid;
		let isCompany = inputIsCompanyCheckbox.prop('checked');

		if(isCompany === true) {
			isCompanyNumberValid = (inputCompanyNumber.val() >= 1000 
								&& inputCompanyNumber.val() <= 9999) ? true : false;
		}

		if(isUsernameValid !== true) {
			inputUsername.css('border-color', 'red');
		}

		if(isEmailValid !== true) {
			inputEmail.css('border-color', 'red');
		}

		if(isPasswordValid !== true) {
			inputPassword.css('border-color', 'red');
		}

		if(isConfirmPasswordValid !== true) {
			inputConfirmPassword.css('border-color', 'red');
		}

		if(arePasswordsEqual !== true) {
			inputPassword.css('border-color', 'red');
			inputConfirmPassword.css('border-color', 'red');
		}

		if(isCompanyNumberValid !== true && isCompany === true) {
			inputCompanyNumber.css('border-color', 'red');
		}

		let isFormValid;

		if(isCompany === true) {
			isFormValid = (isUsernameValid && isEmailValid && isPasswordValid && isConfirmPasswordValid && arePasswordsEqual && isCompanyNumberValid) ? true : false;

		} else {
			isFormValid = (isUsernameValid && isEmailValid && isPasswordValid &&  isConfirmPasswordValid && arePasswordsEqual) ? true : false;			

		}

		if(isFormValid === true) {
			$('#valid').css('display', 'inline-block');
		}
	}
}
