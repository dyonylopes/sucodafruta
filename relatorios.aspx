﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relatorios.aspx.cs" Inherits="Sabor_da_Fruta.relatorios" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="../css/bootstrap.min.css" rel="stylesheet" />

    <script src="../css/bootstrap.css"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>

    <script src="../js/Mostrar.js"></script>

    <link href="../css/style.css" rel="stylesheet" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Relatorios</title>


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

                    <span class="form-inline my-2 my-lg-0">                 
                            <asp:Button ID="btnRelatorios" Text="Relatorios" runat="server" OnClick="btnRelatorios_Click" class="btn btn-outline-success my-2 my-sm-0" />
                        </span>


                        
                    </li>
                </ul>

                <asp:LinkButton ID="LinkButton1" runat="server" Text="Sair" class="nav-link" PostBackUrl="~/login.aspx" />
               
                        
                   
            </div>
        </nav>

        <br />
        <br />
        <h1> Recebimento Mensal</h1>
        <br />
        <!-- gridview recebimentos -->
         <div class="container">
            <div class="gridview">
                <asp:GridView ID="grid" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged">
                  
                    <Columns>
                        <asp:BoundField DataField="ano" HeaderText="Ano" />
                        
                        <asp:BoundField DataField="mes" HeaderText="Mês" />

                        <asp:BoundField DataField="valortotal" HeaderText="Recebimentos R$ " />
                       
                                                                                                                                             
                    </Columns>
                </asp:GridView>
            </div>
        
        </div>
         <br />
        <br />
        
        <h1> Pedidos por mês</h1>
        <br />
        <!-- gridview recebimentos -->
         <div class="container">
            <div class="gridview">
                <asp:GridView ID="gridview1" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="false" OnSelectedIndexChanged="gridview1_SelectedIndexChanged">
                  
                    <Columns>
                        <asp:BoundField DataField="ano" HeaderText="Ano" />
                        
                        <asp:BoundField DataField="mes" HeaderText="Mês" />

                        <asp:BoundField DataField="numeropedidos" HeaderText="Número de Pedidos realizados" />

                       
                       
                                                                                                                                             
                    </Columns>
                </asp:GridView>
            </div>
        </div>
         <br />
         <br />

         <h1> Produtos Vendidos</h1>
        <br />
        <!-- gridview recebimentos -->
         <div class="container">
            <div class="gridview">
                <asp:GridView ID="gridview2" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="false" OnSelectedIndexChanged="gridview2_SelectedIndexChanged">
                  
                    <Columns>
                        <asp:BoundField DataField="ano" HeaderText="Ano" />
                        
                        <asp:BoundField DataField="mes" HeaderText="Mês" />

                        <asp:BoundField DataField="nome" HeaderText="Nome do Produto" />

                         <asp:BoundField DataField="quantidade" HeaderText="Quantidade Vendido" />
                       
                                                                                                                                             
                    </Columns>
                </asp:GridView>
            </div>
        </div>





        </form>
</body>
</html>
