function onCreate(event) {
    removeErrors(event.target);
    const formData = new FormData(event.target);
    let isValid = true;

    const title = formData.get('Title');
    const imageUrl = formData.get('ImageUrl');
    const categories = formData.get('Categories');
    const description = formData.get('Description');
    const requirements = formData.get('Requirements');
    const salary = formData.get('Salary');

    // username validation
    if (username.length == 0) {
        const errorSpan = createErrorAnimationWithMessage('Username is required!',
            document.getElementById('register-username'));
        appendElementBefore(errorSpan, document.getElementById('register-username'));
        isValid = false;
    }
    else if (username.includes(' ')) {
        const errorSpan = createErrorAnimationWithMessage('Username cannot contain empty characters!',
            document.getElementById('register-username'));
        appendElementBefore(errorSpan, document.getElementById('register-username'));
        isValid = false;
    }
    else if (username.length < 5 || username.length > 20) {
        const errorSpan = createErrorAnimationWithMessage('Username must be between 5 and 20 characters!',
            document.getElementById('register-username'));
        appendElementBefore(errorSpan, document.getElementById('register-username'));
        isValid = false;
    }

    // email validation
    const emailRegex = /^[a-z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-z0-9-]+(?:\.[a-z0-9-]+)*$/;

    if (email.length == 0) {
        const errorSpan = createErrorAnimationWithMessage('Email is required!',
            document.getElementById('register-email'));
        appendElementBefore(errorSpan, document.getElementById('register-email'));
        isValid = false;
    }
    else if (email.length < 5 || email.length > 50) {
        const errorSpan = createErrorAnimationWithMessage('Email must be between 5 and 50 characters!',
            document.getElementById('register-email'));
        appendElementBefore(errorSpan, document.getElementById('register-email'));
        isValid = false;
    }
    else if (email.includes(' ')) {
        const errorSpan = createErrorAnimationWithMessage('Email cannot contain empty characters!',
            document.getElementById('register-email'));
        appendElementBefore(errorSpan, document.getElementById('register-email'));
        isValid = false;
    }
    else if (!email.match(emailRegex)) {
        const errorSpan = createErrorAnimationWithMessage('Enter a valid email!',
            document.getElementById('register-email'));
        appendElementBefore(errorSpan, document.getElementById('register-email'));
        isValid = false;
    }

    // password validation
    if (password.length == 0) {
        const errorSpan = createErrorAnimationWithMessage('Password is required!',
            document.getElementById('register-password'));
        appendElementBefore(errorSpan, document.getElementById('register-password'));
        isValid = false;
    }
    else if (password.includes(' ')) {
        const errorSpan = createErrorAnimationWithMessage('Password cannot contain empty characters!',
            document.getElementById('register-password'));
        appendElementBefore(errorSpan, document.getElementById('register-password'));
        isValid = false;
    }
    else if (password.length < 5 || password.length > 20) {
        const errorSpan = createErrorAnimationWithMessage('Password must be between 5 and 20 characters!',
            document.getElementById('register-password'));
        appendElementBefore(errorSpan, document.getElementById('register-password'));
        isValid = false;
    }
    else if (password != confirmPassword) {
        const errorSpan = createErrorAnimationWithMessage('Passwords do not match!',
            document.getElementById('register-repass'));
        appendElementBefore(errorSpan, document.getElementById('register-repass'));
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

    if (spans.length != 0) {
        for (let i = 0; i < spans.length; i++) {
            form.removeChild(spans[i]);
            inputs[i].style.border = 'none';
        }
    }
}