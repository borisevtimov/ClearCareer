function onCreate(event) {
    removeErrors(event.target);
    const formData = new FormData(event.target);
    let isValid = true;

    const title = formData.get('Title');
    const image = formData.get('Image');
    const categories = formData.get('Categories');
    const description = formData.get('Description');
    const requirements = formData.get('Requirements');
    const salary = formData.get('Salary');

    // title validation
    if (title.length == 0) {
        const errorSpan = createErrorAnimationWithMessage('Title is required!',
            document.getElementById('create-title'));
        appendElementBefore(errorSpan, document.getElementById('create-title'));
        isValid = false;
    }
    else if (title.length > 80) {
        const errorSpan = createErrorAnimationWithMessage('Title must be less than 80 characters!',
            document.getElementById('create-title'));
        appendElementBefore(errorSpan, document.getElementById('create-title'));
        isValid = false;
    }

    //categories validation
    if (categories.length == 0) {
        const errorSpan = createErrorAnimationWithMessage('Categories are required!',
            document.getElementById('create-category'));
        appendElementBefore(errorSpan, document.getElementById('create-category'));
        isValid = false;
    }

    //description validation
    if (description.length == 0) {
        const errorSpan = createErrorAnimationWithMessage('Description is required!',
            document.getElementById('create-description'));
        appendElementBefore(errorSpan, document.getElementById('create-description'));
        isValid = false;
    }
    else if (description.length < 5) {
        const errorSpan = createErrorAnimationWithMessage('Description must be at least 5 characters!',
            document.getElementById('create-description'));
        appendElementBefore(errorSpan, document.getElementById('create-description'));
        isValid = false;
    }

    //salary validation
    if (salary.length != 0) {
        if (isNaN(salary)) {
            const errorSpan = createErrorAnimationWithMessage('Salary must be a number!',
                document.getElementById('create-salary'));
            appendElementBefore(errorSpan, document.getElementById('create-salary'));
            isValid = false;
        }
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
    const textareas = form.querySelectorAll('textarea');

    for (let i = 0; i < spans.length; i++) {
        form.removeChild(spans[i]);
    }

    for (let i = 0; i < textareas.length; i++) {
        textareas[i].style.border = 'none';
    }

    for (let i = 0; i < inputs.length; i++) {
        inputs[i].style.border = 'none';
    }
}