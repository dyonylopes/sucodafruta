<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Sabor_da_Fruta.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Css | BT -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/estiloLogin.css" rel="stylesheet" />
    <scrip src="../css/bootstrap.css"></scrip>
    <scrip src="../jQuery/Content/Scripts/jquery-3.5.1.min.js"> </scrip>
    <script src="../js/Mostrar.js"></script>



<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="WaterMark.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $("[id*=txtUsuario], [id*=txtSenha]").WaterMark();            
        });
    </script>

</head>
<body>
    <form id="frmLogin" runat="server" class="container">
        
        <style>
            body {
                background: url("imagens/restaurante.jpeg");
                background-repeat: no-repeat;
                background-size: cover;
                background-position: center;
                background-attachment: fixed;
            }
        </style>
            
  <div class="wrapper fadeInDown">
  <div id="formContent">
    <!-- Tabs Titles -->

    <!-- Icon -->
    <div class="fadeIn first">
      <img src="../imagens/logo.png"  class="container" id="icon" alt="Faça seu Login" />
    </div>
      <!-- Alert -->
      <asp:Panel ID="panelLogin" runat="server" >
      <div class="alert alert-danger" role="alert">
          <asp:Label Text="" ID="lblMensagemErro" runat="server" />
      </div>
      </asp:Panel>
    <!-- Login Form -->
    
     <asp:Textbox ID="txtUsuario" runat="server" class="fadeIn second"  placeholder="Usuário" />

      
      <asp:Textbox ID="txtSenha"  runat="server"  placeholder="Senha" TextMode="Password"/>

      <br />

      

      <asp:CheckBox  runat="server" onclick="myFunction()"  Text = " Mostrar"/>

          
      
    
      
      <asp:Button ID="btnLogin" runat="server" class="fadeIn fourth" text="Login" OnClick="btnLogin_Click" />

      


   

    <!-- Remind Passowrd -->
    <div id="formFooter">
      <asp:LinkButton ID="LinkRecp" class="underlineHover" runat="server" Text="" href="#" />
    </div>

  
</div>


        </div>
    </form>
</body>
</html>
