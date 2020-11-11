<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Sabor_da_Fruta.index" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Css | BT -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />

    <script src="../css/bootstrap.css"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>

    <script src="../js/Mostrar.js"></script>

    <link href="../css/style.css" rel="stylesheet" />

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro</title>
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
                        <a class="nav-link" href="index.aspx">Home <span class="sr-only">(current)</span></a>
                    </li>
                   
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Cadastros
                        </a>
                        <div class="dropdown-menu" aria-labelledby="Dropdown" />
                        <!-- <a class="dropdown-item" href="#">Comanda</a> -->
                        <a class="dropdown-item" data-toggle="modal" data-target="#ModalCategorias">Categorias</a>
                        <a class="dropdown-item" data-toggle="modal" data-target="#ModalFornecedores">Fornecedores</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" data-toggle="modal" data-target="#ModalProdutos">Produtos</a>
                        <a class="dropdown-item" data-toggle="modal" data-target="#ModalUsuarios">Usuários</a>
            </div>
            </li>
            <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Consultar
                        </a>
                        <div class="dropdown-menu" aria-labelledby="Dropdown" />
                        <!-- <a class="dropdown-item" href="#">Comanda</a> -->
                        <a class="dropdown-item" data-toggle="modal" data-target="#ModalCategorias">Categorias</a>
                        <a class="dropdown-item" data-toggle="modal" data-target="#ModalFornecedores">Fornecedores</a>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" data-toggle="modal" data-target="#ModalProdutosCad">Produtos</a>
                        <a class="dropdown-item" data-toggle="modal" data-target="#ModalUsuarios">Usuários</a>
            </div>
            </li>
      <li class="nav-item active">
          <asp:LinkButton ID="sair" runat="server" Text="Sair" class="nav-link" PostBackUrl="~/login.aspx" />
      </li>
            </ul>
    <span class="form-inline my-2 my-lg-0">
        <asp:TextBox ID="txtbuscar" runat="server" class="form-control mr-sm-2" placeholder="Buscar" aria-label="Search" />
        <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" class="btn btn-outline-success my-2 my-sm-0" />
    </span>
            </div>
        </nav>






        <h1>Cadastrar produto</h1>
        <div>
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
                        <asp:Label Text="Produto" runat="server" />
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtnome" runat="server" OnTextChanged="txtnome_TextChanged" />
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Descrição" runat="server" />
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtdescricao" runat="server" OnTextChanged="txtdescricao_TextChanged" />

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Valor" runat="server" />
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtvalor" runat="server" OnTextChanged="txtvalor_TextChanged" />

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Quantidade" runat="server" />
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtquantidade" runat="server" OnTextChanged="txtquantidade_TextChanged" />

                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Label Text="Categoria" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="cbCategoria" runat="server" Width="124px" OnSelectedIndexChanged="cbCategoria_SelectedIndexChanged" />




                    </td>

                </tr>




                <tr>
                    <td></td>
                    <td colspan="2"></asp:DropDownList>

                    </td>

                </tr>




                <tr>
                    <td>
                        <asp:Label Text="Fornecedor" runat="server" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="cbFornecedor" runat="server" Width="124px" OnSelectedIndexChanged="cbFornecedor_SelectedIndexChanged">
                        </asp:DropDownList>

                    </td>

                </tr>




                <tr>
                    <td></td>
                    <td colspan="2"></td>

                </tr>


                <tr>
                    <!-- Botões -->
                    <td colspan="3">
                        <asp:Button ID="btnNovo" Text="Novo" runat="server" CssClass="btn btn-outline-primary my-2 my-sm-0" OnClick="btnNovo_Click" Enabled="False" />
                        <asp:Button ID="btnSalvar" Text="Salvar" runat="server" CssClass="btn btn-outline-success my-2 my-sm-0" OnClick="btnSalvar_Click" Enabled="False" />
                        <asp:Button ID="btnEditar" Text="Editar" runat="server" CssClass="btn btn-outline-info my-2 my-sm-0" Enabled="False" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnExcluir" Text="Deletar" runat="server" CssClass="btn btn-outline-danger my-2 my-sm-0" Enabled="False" OnClick="btnExcluir_Click" />
                        <!-- <asp:Button   ID="btnLogin" Text="Login" runat="server" Enabled="True" PostBackUrl="~/Login.aspx" /> <!-- redirecionamento no botão -->
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

            <br />
            <br />

            <h2>Tabela de produtos</h2>  <!-- mudei para grid2 -->

            <div class="container">
                <div class="gridview">
                    <asp:GridView ID="grid" runat="server" CssClass="table table-striped table-dark" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="nome" HeaderText="Produto" />
                            <asp:BoundField DataField="valor" HeaderText="Valor" />
                            <asp:BoundField DataField="quantidade" HeaderText="Quantidade" />
                            <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                            <asp:BoundField DataField="categoria" HeaderText="Categoria" />
                            <asp:BoundField DataField="id_fornecedor" HeaderText="ID Fornecedor" />
                            <asp:BoundField DataField="nomeForm" HeaderText="Fornecedor" />
                            <asp:BoundField DataField="telefone" HeaderText="Telefone" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnSelecionar" Text="Selecionar" CssClass="btn btn-outline-danger my-2 my-sm-0" CommandArgument='<%# Eval("id") %>' runat="server" OnClick="btnSelecionar_Click" />
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>




      



















        <!-- Modal  Produtos -->

        <div class="border border-dark">
            <div class="modal" id="ModalProdutos">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <!-- Modal Header -->


                        <div class="modal-header">

                            <h4 class="modal-title">Cadastro de Produtos</h4>

                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>



                        <!-- Modal body -->
                        <div class="modal-body">

                            <asp:TextBox placeholder="Nome do Produto..." ID="txtnome2" CssClass="form-control" runat="server" />
                            <br />
                            <asp:TextBox placeholder="Descrição do Produto..." ID="txtdescricao2" CssClass="form-control" runat="server" />
                            <br />
                            <asp:TextBox placeholder="Valor do Produto..." ID="txtvalor2" CssClass="form-control" runat="server" />
                            <br />
                            <label>Quantidade:</label>
                            <asp:TextBox type="number" min="0" MaxLength="10" ID="txtquantidade2" CssClass="form-control" runat="server" />
                            <br />

                            <asp:Label Text="Categoria" runat="server" />

                            <asp:DropDownList ID="cbCategoria2" runat="server" Width="224px" OnSelectedIndexChanged="cbCategoria_SelectedIndexChanged" />
                            <br />
                            <br />
                            <asp:Label Text="Fornecedor" runat="server" />
                           
                            <asp:DropDownList ID="cbFornecedor2" runat="server" Width="224px" OnSelectedIndexChanged="cbCategoria_SelectedIndexChanged" />
                            <br />

                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">

                            <asp:Button runat="server" ID="btnSalvar2" CssClass="btn btn-success" Text="Salvar" OnClick="btnSalvar2_Click" />
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>



                    </div>
                </div>
            </div>


        </div>






        <!-- Modal  Usuários -->

        <div class="border border-dark">
            <div class="modal" id="ModalUsuarios">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Cadastro de Usuários</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">

                            <asp:TextBox placeholder="Nome do Usuário..." ID="txtNomeUsuario" CssClass="form-control" runat="server" />
                            <br />
                            <asp:TextBox placeholder="Login do Usuário..." ID="txtLogin" CssClass="form-control" runat="server" />
                            <br />
                            <asp:TextBox placeholder="Senha..." ID="txtSenha" CssClass="form-control" runat="server" TextMode="Password" />
                            <br />
                            <asp:Label Text="Nível" runat="server" />

                            <asp:DropDownList ID="cbNivel" runat="server" Width="224px" OnSelectedIndexChanged="cbCategoria_SelectedIndexChanged" />


                            <asp:CheckBox runat="server" onclick="myFunction()" Text=" Mostrar" />



                            <br />

                            <asp:Label Text="" ID="lblUsuario" runat="server" ForeColor="Green" />
                            <br />


                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">

                            <asp:Button runat="server" ID="btnCadUsuario" CssClass="btn btn-success" Text="Salvar" OnClick="btnCadUsuario_Click" />
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>




        <!-- Modal Categorias -->
        <div class="border border-dark">
            <div class="modal" id="ModalCategorias">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <!-- Modal Header -->
                        <div class="modal-header">
                            <h4 class="modal-title">Cadastro de Categoria</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>

                        <!-- Modal body -->
                        <div class="modal-body">

                            <asp:TextBox placeholder="Nome da categoria..." ID="txtNomeCategoria" CssClass="form-control" runat="server" />
                                                  
                        </div>
                         <br />

                            <asp:Label Text="" ID="lblCategorias" runat="server" ForeColor="Green" />
                            <br />

                        <!-- Modal footer -->
                        <div class="modal-footer">

                            <asp:Button runat="server" ID="btnCadCadastro" CssClass="btn btn-success" Text="Salvar" OnClick="btnCadCadastro_Click" />
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>






    </form>














</body>
</html>
