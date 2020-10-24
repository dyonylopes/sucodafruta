<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Sabor_da_Fruta.index" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Css | BT -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    
    <scrip src="../css/bootstrap.css"></scrip>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="#">Suco da Fruta</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">Link</a>
      </li>
      <li class="nav-item dropdown">
        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          Dropdown
        </a>
        <div class="dropdown-menu" aria-labelledby="navbarDropdown" />
          <a class="dropdown-item" href="#">Action</a>
          <a class="dropdown-item" href="#">Another action</a>
          <div class="dropdown-divider"></div>
          <a class="dropdown-item" href="#">Something else here</a>
        </div>
      </li>
      <li class="nav-item active">
        <asp:LinkButton ID="sair" runat="server" Text="Sair" class="nav-link" PostBackUrl="~/login.aspx" />
      </li>
    </ul>
    <span class="form-inline my-2 my-lg-0">
      <asp:Textbox ID="txtbuscar" runat="server" class="form-control mr-sm-2"  placeholder="Buscar" aria-label="Search" />
      <asp:Button   ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click"  class="btn btn-outline-success my-2 my-sm-0" />
    </span>
  </div>
</nav>






    
        <div>
            <asp:HiddenField ID="idproduto" runat="server" />  <!-- para ocultar ID do produto -->

            <table>

                <br />

             

                 <tr>
                    <td>
                       
                    </td>
                    <td  colspan="2">
                          
                    </td>
                      <td  colspan="2">
                          
                    </td>
                    
                </tr>


                


                <tr>
                    <td>
                        <asp:Label Text="Produto" runat="server" />  
                    </td>
                    <td  colspan="3">
                          <asp:Textbox ID="txtnome" runat="server" OnTextChanged="txtnome_TextChanged" /> 

                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Descrição" runat="server" />  
                    </td>
                    <td  colspan="3">
                          <asp:Textbox ID="txtdescricao" runat="server" OnTextChanged="txtdescricao_TextChanged" /> 

                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Valor" runat="server" />  
                    </td>
                    <td  colspan="3">
                          <asp:Textbox ID="txtvalor" runat="server" OnTextChanged="txtvalor_TextChanged" /> 

                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Quantidade" runat="server" />  
                    </td>
                    <td  colspan="3">
                          <asp:Textbox ID="txtquantidade" runat="server" OnTextChanged="txtquantidade_TextChanged" /> 

                    </td>
                    
                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Categoria" runat="server" />  
                    </td>
                    <td  colspan="2">
                          <asp:DropDownList ID="cbCategoria" runat="server" Width="124px" OnSelectedIndexChanged="cbCategoria_SelectedIndexChanged"> 
                          

                           </asp:DropDownList>

                    </td>
                    
                </tr>




                 <tr>
                    <td>
                        
                    </td>
                    <td  colspan="2">
                          
                          

                           </asp:DropDownList>

                    </td>
                    
                </tr>




                <tr>
                    <td>
                        <asp:Label Text="Fornecedor" runat="server" />  
                    </td>
                    <td  colspan="2">
                          <asp:DropDownList ID="cbFornecedor" runat="server" Width="124px" > 
                          

                           </asp:DropDownList>

                    </td>
                    
                </tr>




                 <tr>
                    <td>
                        
                    </td>
                    <td  colspan="2">
                          
                          

                           

                    </td>
                    
                </tr>


                <tr> <!-- Botões -->
                    <td colspan="3">
                        <asp:Button   ID="btnNovo" Text="Novo" runat="server" OnClick="btnNovo_Click" Enabled="False" /> 
                        <asp:Button   ID="btnSalvar" Text="Salvar" runat="server" OnClick="btnSalvar_Click" Enabled="False" style="height: 26px" />  
                        <asp:Button   ID="btnEditar" Text="Editar" runat="server" Enabled="False" OnClick="btnEditar_Click" />  
                        <asp:Button   ID="btnExcluir" Text="Deletar" runat="server" Enabled="False" OnClick="btnExcluir_Click" /> 
                        <asp:Button   ID="btnLogin" Text="Login" runat="server" Enabled="True" PostBackUrl="~/Login.aspx" /> <!-- redirecionamento no botão -->
                    </td>
                  
                </tr>
                <!-- Para exigir a mensagem de aviso --> 

                 <tr>
                    <td colspan="3">
                        <asp:Label Text="" ID="lblMensagemOK" runat="server" ForeColor="Green" />
                      </td>                                     
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label Text="" ID="lblMensagemErro" runat="server" ForeColor="Red" />
                    </td>                                     
                </tr>


            </table>

            <br /><br />

            <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged">
            <Columns>
                <asp:BoundField Datafield="nome" HeaderText="Produto"/>
                <asp:BoundField Datafield="valor" HeaderText="Valor"/>
                <asp:BoundField Datafield="quantidade" HeaderText="Quantidade"/>
                <asp:BoundField Datafield="descricao" HeaderText="Descrição"/>
                <asp:BoundField Datafield="categoria" HeaderText="Categoria"/>
                <asp:BoundField Datafield="id_fornecedor" HeaderText="ID Fornecedor"/>
                 <asp:BoundField Datafield="nomeForm" HeaderText="Fornecedor"/>  
                 <asp:BoundField Datafield="telefone" HeaderText="Telefone"/>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button  ID="btnSelecionar" Text="Selecionar" CommandArgument='<%# Eval("id") %>' runat="server" OnClick ="btnSelecionar_Click" />
                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>
                </asp:GridView>
        </div>
    </form>
 </body>
</html>
