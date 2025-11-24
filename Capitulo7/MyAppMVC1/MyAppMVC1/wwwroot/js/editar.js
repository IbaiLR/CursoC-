
let btnEditar = document.getElementById('btn-editarPerfil');
    btnEditar.addEventListener('click', () => {

        document.querySelectorAll('input.form-control').forEach(input => {
            input.removeAttribute('disabled');
        });

        let btnSubmit = document.getElementById('btn-submit');
        btnSubmit.style.display = "inline-block";

        btnEditar.style.display = 'none';
    })

