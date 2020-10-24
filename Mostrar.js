function myFunction() {
    var x = document.getElementById("txtSenha");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

function myFunction2() {
    var x = document.getElementById("txtSenha");
    if (x.type === "text") {
        x.type = "password";
    } else {
        x.type = "text";
    }
}



<script type="text/javascript">
    var obj = document.getElementById("txtSenha");
    var newObj = document.createElement('input');
    newObj.setAttribute('type', 'password');
    newObj.setAttribute('id', obj.getAttribute('id'));
    newObj.setAttribute('name', obj.getAttribute('name'));
    obj.parentNode.replaceChild(newObj, obj);
    newObj.focus();
</script>






<script type="text/javascript">
    function password() {
        document.getElementById('<%= txt.Senha %>').type = 'password';
       }
   </script>