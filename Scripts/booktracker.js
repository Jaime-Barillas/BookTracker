function showModal() {
    let modal = document.querySelector("div.modal");

    modal.classList.replace('modal-hide', 'modal-show');
}

function hideModal() {
    let modal = document.querySelector("div.modal");

    modal.classList.replace('modal-show', 'modal-hide');
}