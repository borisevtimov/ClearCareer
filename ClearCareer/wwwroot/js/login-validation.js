function onLogin(event) {
    removeErrors(event.target);
    const formData = new FormData(event.target);
    let isValid = true;

    const usernameOrEmail = formData.get('UsernameOrEmail');
    const password = formData.get('Password');

    // username validation
    if (usernameOrEmail.length == 0) {
        const errorSpan = createErrorAnimationWithMessage('Username or email is required!',
            document.getElementById('login-username'));
        appendElementBefore(errorSpan, document.getElementById('login-username'));
        isValid = false;
    }

    // password validation
    if (password.length == 0) {
        const errorSpan = createErrorAnimationWithMessage('Password is required!',
            document.getElementById('login-password'));
        appendElementBefore(errorSpan, document.getElementById('login-password'));
        isValid = false;
    }

    return isValid;
}

function createErrorAnimationWithMessage(errorMessage, input) {
    const errorSpan = document.createElement('span');
    errorSpan.textContent = errorMessage;
    errorSpan.style.color = 'red';
    input.style.border = '1px solid red';
    return errorSpan;
}

function appendElementBefore(newElement, nextElement) {
    event.target.insertBefore(newElement, nextElement);
}

function removeErrors(form) {
    const spans = form.querySelectorAll('span');
    const inputs = form.querySelectorAll('input');

    for (let i = 0; i < spans.length; i++) {
        form.removeChild(spans[i]);
    }

    for (let i = 0; i < inputs.length; i++) {
        inputs[i].style.border = 'none';
    }
}