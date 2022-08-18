function onLoad(event) {
    event.preventDefault();
    const form = document.getElementById('register-form');
    const formData = new FormData(form);

    const username = formData.get('Username');
    const email = formData.get('Email');
    const password = formData.get('Password');
    const confirmPassword = formData.get('ConfirmPassword');

    if (username.length < 5 || username.length > 20) {
        const errorSpan = document.createElement('span');
        errorSpan.textContent = 'Username must be between 5 and 20 characters!';
        event.target.appendChild(errorSpan);
    }
}