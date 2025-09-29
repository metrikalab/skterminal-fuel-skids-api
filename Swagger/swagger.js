window.onload = function () {
    var token = prompt("Ingrese su token JWT");

    if (token) {
        var authorizeButton = document.querySelector(".authorize-wrapper .authorize");
        authorizeButton.addEventListener("click", function () {
            var input = document.querySelector(".authorize-wrapper input[name=token]");
            input.value = "Bearer " + token;
            var form = document.querySelector(".authorize-wrapper form");
            form.submit();
        });
    }
};
