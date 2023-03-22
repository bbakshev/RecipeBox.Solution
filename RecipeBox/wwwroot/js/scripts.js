function showModal(type) {
  document.body.classList.add('veiled');
  let modalElement = document.getElementById(`${type}-modal`);
  modalElement.classList.remove('obscured');
}

function hideModal(type) {
  document.body.classList.remove('veiled');
  document.getElementById(`${type}-modal`).classList.add('obscured');
}