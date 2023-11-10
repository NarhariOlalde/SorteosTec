// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#loginModal').modal('show');
});

document.addEventListener('DOMContentLoaded', function () {
    var myRadios = document.getElementsByName('sexo');
    var setCheck;
    var x = 0;
    for (x = 0; x < myRadios.length; x++) {
        myRadios[x].onclick = function () {
            if (setCheck != this) {
                setCheck = this;
            } else {
                this.checked = false;
                setCheck = null;
            }
        };
    }
});
