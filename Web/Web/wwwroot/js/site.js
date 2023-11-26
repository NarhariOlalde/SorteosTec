// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    // Asignar evento click al botón de inicio de sesión
    $('#loginButton').on('click', function () {
        $('#loginModal').modal('show');
    });

    $('#openRegisterModal').on('click', function () {
        // Espera un poco para abrir el modal de registro después de cerrar el de inicio de sesión
        setTimeout(function () {
            $('#registerModal').modal('show');
        }, 500); // Ajuste de tiempo
    });

    // Asignar evento click al enlace del perfil de usuario para abrir el modal
    $('a[data-bs-target="#userProfileModal"]').on('click', function () {
        $('#userProfileModal').modal('show');
    });


    var pageData = $('#page-data');
    if (pageData.length > 0 && pageData.data('registro-exitoso')) {
        $('#registroExitosoModal').modal('show');
    }

    var pageDataLogin = $('#page-data-login');
    if (pageDataLogin.length > 0 && pageDataLogin.data('inicio-sesion-exitoso')) {
        $('#inicioSesionExitosoModal').modal('show');
    }

    var pageDataError = $('#page-data-error');
    console.log("Error Data Length:", pageDataError.length); // Para depuración
    console.log("Error Data:", pageDataError.data('error-contraseña'));
    if (pageDataError.length > 0 && pageDataError.data('error-contraseña')) {
        $('#errorContraseñaModal').modal('show');
    }
});

// User register form
document.getElementById('numeroTarjetaVisual').addEventListener('input', function (e) {
    var value = e.target.value.replace(/\D/g, ''); // Elimina todo lo que no sea número
    var formattedValue = '';

    // Agrega espacios antes y después de cada guión
    for (var i = 0; i < value.length; i++) {
        if (i > 0 && i % 4 === 0) {
            formattedValue += ' - ';
        }
        formattedValue += value[i];
    }

    // Actualiza el campo visual y el campo oculto
    e.target.value = formattedValue;
    document.getElementById('numeroTarjeta').value = value; // Valor sin guiones ni espacios
});

// Form validations for bootstrap
(() => {
    'use strict';

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation');

    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            // Validación adicional para el número de tarjeta
            const numeroTarjeta = document.getElementById('numeroTarjeta').value;
            if (numeroTarjeta.length !== 16) {
                // Muestra el mensaje de error
                const errorDiv = document.getElementById('errorTarjeta');
                errorDiv.style.display = 'block';

                // Previene el envío del formulario
                event.preventDefault();
                event.stopPropagation();
            } else {
                // Si el número de tarjeta es válido, asegúrate de ocultar el mensaje de error
                const errorDiv = document.getElementById('errorTarjeta');
                errorDiv.style.display = 'none';
            }



            if (!form.checkValidity()) {
                event.preventDefault();
                event.stopPropagation();
            }

            form.classList.add('was-validated');
        }, false);
    });
})();


// // Dark mode
const temaOscuro = () => {
    document.querySelector('body').setAttribute("data-bs-theme", "dark");
    document.querySelector("#color-icon").setAttribute("class", "text-light bi bi-sun-fill");
}

const temaClaro = () => {
    document.querySelector('body').setAttribute("data-bs-theme", "light");
    document.querySelector("#color-icon").setAttribute("class", "text-light bi bi-moon-fill");
}

const cambiarTema = () => {
    document.body.classList.toggle("dark-theme");
}

// /*!
//  * Color mode toggler for Bootstrap's docs (https://getbootstrap.com/)
//  * Copyright 2011-2023 The Bootstrap Authors
//  * Licensed under the Creative Commons Attribution 3.0 Unported License.
//  */

// (() => {
//     'use strict'

//     const getStoredTheme = () => localStorage.getItem('theme')
//     const setStoredTheme = theme => localStorage.setItem('theme', theme)

//     const getPreferredTheme = () => {
//         const storedTheme = getStoredTheme()
//         if (storedTheme) {
//             return storedTheme
//         }

//         return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light'
//     }

//     const setTheme = theme => {
//         if (theme === 'auto' && window.matchMedia('(prefers-color-scheme: dark)').matches) {
//             document.documentElement.setAttribute('data-bs-theme', 'dark')
//         } else {
//             document.documentElement.setAttribute('data-bs-theme', theme)
//         }
//     }

//     setTheme(getPreferredTheme())

//     const showActiveTheme = (theme, focus = false) => {
//         const themeSwitcher = document.querySelector('#bd-theme')

//         if (!themeSwitcher) {
//             return
//         }

//         const themeSwitcherText = document.querySelector('#bd-theme-text')
//         const activeThemeIcon = document.querySelector('.theme-icon-active use')
//         const btnToActive = document.querySelector(`[data-bs-theme-value="${theme}"]`)
//         const svgOfActiveBtn = btnToActive.querySelector('svg use').getAttribute('href')

//         document.querySelectorAll('[data-bs-theme-value]').forEach(element => {
//             element.classList.remove('active')
//             element.setAttribute('aria-pressed', 'false')
//         })

//         btnToActive.classList.add('active')
//         btnToActive.setAttribute('aria-pressed', 'true')
//         activeThemeIcon.setAttribute('href', svgOfActiveBtn)
//         const themeSwitcherLabel = `${themeSwitcherText.textContent} (${btnToActive.dataset.bsThemeValue})`
//         themeSwitcher.setAttribute('aria-label', themeSwitcherLabel)

//         if (focus) {
//             themeSwitcher.focus()
//         }
//     }

//     window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', () => {
//         const storedTheme = getStoredTheme()
//         if (storedTheme !== 'light' && storedTheme !== 'dark') {
//             setTheme(getPreferredTheme())
//         }
//     })

//     window.addEventListener('DOMContentLoaded', () => {
//         showActiveTheme(getPreferredTheme())

//         document.querySelectorAll('[data-bs-theme-value]')
//             .forEach(toggle => {
//                 toggle.addEventListener('click', () => {
//                     const theme = toggle.getAttribute('data-bs-theme-value')
//                     setStoredTheme(theme)
//                     setTheme(theme)
//                     showActiveTheme(theme, true)
//                 })
//             })
//     })
// })()