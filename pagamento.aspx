<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagamento.aspx.cs" Inherits="Sabor_da_Fruta.pagamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
    <link href="../css/bootstrap.min.css" rel="stylesheet" />

    <script src="../css/bootstrap.css"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>

    <script src="../js/Mostrar.js"></script>

    <link href="../css/style.css" rel="stylesheet" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pagamento</title>


</head>
<body>
    <form id="form1" runat="server">

         <style>
            body {
                background: linear-gradient(#DCDCDC, #FFFAFA);
                background-repeat: no-repeat;
                background-size: cover;
                background-position: center;
                background-attachment: fixed;
                color: #000000;
            }
        </style>
      
             <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="fadeIn first">
                <img src="../imagens/sologo.png" class="logoimg" id="icon" />
            </div>

            <h3 class="titulologo">RESTAURANTE SUCO DA FRUTA</h3>

            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
                 
                 <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Link</a>
                    </li>
                     
                    
          
            </li>
      <li class="nav-item active">
          <asp:LinkButton ID="sair" runat="server" Text="Sair" class="nav-link" PostBackUrl="~/login.aspx" />
      </li>
           </ul>
 </div>
        </nav>
       

        <asp:HiddenField ID="idproduto" runat="server" />
        <!-- para ocultar ID do produto -->

        <table>

            <br />



            <tr>
                <td></td>
                <td colspan="2"></td>
                <td colspan="2"></td>

            </tr>




            <tr>
                <td>
                    <asp:Label Text="Numero da Comanda" runat="server" />
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtnumero" runat="server" />
                </td>

                 <tr>

                    <tr>
                        <!-- Botões -->
                        <td colspan="3">

                            <asp:Button ID="btnBuscar" Text="Pesquisar" runat="server" CssClass="btn btn-outline-success my-2 my-sm-0" OnClick="btnBuscar_Click" />

                            <!-- <asp:Button   ID="btnLogin" Text="Login" runat="server" Enabled="True" PostBackUrl="~/Login.aspx" /> <!-- redirecionamento no botão -->
                        </td>


                    </tr>
                    

                

        


              
                    <!-- Para exigir a mensagem de aviso -->

               
                  
        </table>

        <br />
        <br />

         <asp:Label Text="" ID="lblMensagemOK" runat="server" ForeColor="Green" />

                    <asp:Label Text="" ID="lblMensagemErro" runat="server" ForeColor="Red" />


         <div class="container">
            <div class="gridview">
                <asp:GridView ID="grid" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="numero" HeaderText="Numero da Comanda" />
                        <asp:BoundField DataField="produto" HeaderText="Produto" />
                        <asp:BoundField DataField="valor" HeaderText="Valor" />
                        <asp:BoundField DataField="quantidade" HeaderText="Quantidade" />
                        <asp:BoundField DataField="valor_total" HeaderText="Valor Total" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
    </form>
</body>
</html>
