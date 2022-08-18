function onLoad(event) {
    const formData = new FormData(event.target);

    const username = formData.get('Username');
    const email = formData.get('Email');
    const password = formData.get('Password');
    const confirmPassword = formData.get('ConfirmPassword');

    if (username.length < 5 || username.length > 20) {
        const errorSpan = document.createElement('span');
        errorSpan.textContent = 'Username must be between 5 and 20 characters!';
        event.target.appendChild(errorSpan);
    }

    if (email.length < 5 || email.length > 20) {
        const errorSpan = document.createElement('span');
        errorSpan.textContent = 'Email must be between 5 and 20 characters!';
        event.target.appendChild(errorSpan);
    }

    if (password.length < 5 || password.length > 20) {
        const errorSpan = document.createElement('span');
        errorSpan.textContent = 'Password must be between 5 and 20 characters!';
        event.target.appendChild(errorSpan);
    }

    if (confirmPassword != password) {
        const errorSpan = document.createElement('span');
        errorSpan.textContent = 'Passwords do not match!';
        event.target.appendChild(errorSpan);
    }
}