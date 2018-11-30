
function validateRSVP() {
    var errorString = "";

    errorString += validateFirstName();
    errorString += validateLastName();
    errorString += validateEmail();

    if (errorString.length >= 1) {
        alert(errorString);
        return false;
    }
    else {
        return true;
    }

}

function validateFirstName() {
    var firstName = document.getElementById("firstName").value;
    var regEx = /[^a-zA-Z]+/;

    if (regEx.test(firstName)) {
        return "First name entry invalid. \n";
    }
    else {
        return "";
    }
}

function validateLastName() {
    var lastName = document.getElementById("lastName").value;
    var regEx = /[^a-zA-Z]+/;

    if (regEx.test(lastName)) {
        return "Last name entry invalid. \n";
    }
    else {
        return "";
    }
}

function validateEmail() {
    var email = document.getElementById("email").value;
    var regEx = /^([a-zA-Z0-9_\-\.]+)&#64([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/;

    if (!regEx.test(email)) {
        return "Email address invalid. \n";
    }
    else {
        return "";
    }
}