
document.getElementById("date").style.visibility = "hidden";

function validateRSVP() {
    var numError = 0;

    numError += validateFirstName();
    numError += validateLastName();
    numError += validateEmail();

    if (numError > 0) {
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
        document.getElementById("firstName").classList.add("is-invalid");
        return 1
    }
    else {
        return 0;
    }
}

function validateLastName() {
    var lastName = document.getElementById("lastName").value;
    var regEx = /[^a-zA-Z]+/;

    if (regEx.test(lastName)) {
        document.getElementById("lastName").classList.add("is-invalid");
        return 1
    }
    else {
        return 0;
    }
}

function validateEmail() {
    var email = document.getElementById("email").value;
    var regEx = /^([a-zA-Z0-9_\-\.]+)\@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/;

    if (!regEx.test(email)) {
        document.getElementById("email").classList.add("is-invalid");
        return 1
    }
    else {
        return 0;
    }
}

function revealDate() {
    document.getElementById("date").style.visibility = "visible";
    document.getElementById("plusOne").disabled = false;
}

function hideDate() {
    document.getElementById("date").style.visibility = "hidden";
    document.getElementById("plusOne").checked = false;
    document.getElementById("plusOne").disabled = true;
}