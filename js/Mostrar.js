function myFunction() {
    var x = document.getElementById("txtSenha");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}