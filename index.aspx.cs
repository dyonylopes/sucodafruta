﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabor_da_Fruta
{
    public partial class index : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        Int32 id;
        string nomeUsuario, nivelUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
           

            nomeUsuario = Request.QueryString["nome"];
            nivelUsuario = Request.QueryString["nivel"];

            if(nomeUsuario == null) //não deixa entrar sem login
            {
                Response.Redirect("login.aspx");
            }

            Listar();
            //DANDO NIVEL DE PERMISSÃO AO USUARIO
            if(nivelUsuario == "admin")
            {
                btnNovo.Enabled = true;
            }

            DesabilitarCampos();


            if(cbCategoria.Text == "")
            {

                CarregarCategorias();

            }

            if (cbFornecedor.Text == "")
            {

                CarregarFornecedores();

            }



        }

        private void CarregarFornecedores()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT * FROM  fornecedores order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                cbFornecedor.Enabled = true;
                cbFornecedor.DataSource = dt; //receber na Datatable
                cbFornecedor.DataTextField = "nome";
                cbFornecedor.DataValueField = "id"; //savar no id
                cbFornecedor.DataBind(); // Atualizar dados           

            }
            else
            {

                cbFornecedor.Enabled = false;
                lblMensagemOK.Text = "Não possuem fornecedores cadastradas !!!";



            }






            con.FecharCon();
        }

        

        private void CarregarCategorias()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT * FROM categorias order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                cbCategoria.Enabled = true;
                cbCategoria.DataSource = dt; //receber na Datatable
                cbCategoria.DataTextField = "nome";
                cbCategoria.DataValueField = "id";
                cbCategoria.DataBind(); // Atualizar dados           

            }
            else
            {

                cbCategoria.Enabled = false;
                lblMensagemOK.Text = "Não possuem categorias cadastradas !!!";
             


            }






            con.FecharCon();
        }



    

        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon(); //Inner join para pegar de outras tabelas mudo o prefixo
            sql = "SELECT p.id, p.nome, p.descricao, p.valor, p.quantidade, p.categoria, p.id_fornecedor, f.nome as nomeForm, f.telefone FROM  produtos as p INNER JOIN fornecedores as f ON p.id_fornecedor = f.id order by p.nome asc";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                grid.Visible = true;
                grid.DataSource = dt; //receber na Datatable
                grid.DataBind(); // Atualizar dados           

            }
            else
            {
                
                lblMensagemOK.Text = "Não possuem produtos cadastrados !!!";
                btnBuscar.Enabled = false; //se não tiver produtos cadastrados busar fica inativo
                txtbuscar.Enabled = false;
                grid.Visible = false;


            }            


            con.FecharCon();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtnome.Text =="")
            {
               lblMensagemErro.Text = "Preencha o campo Nome!";               
               txtnome.Focus();
                return;



            }
            if(txtdescricao.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Descrição!";               
                txtdescricao.Focus();
                return;


            }
            if (txtvalor.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Valor!";
                txtvalor.Focus();
                return;

            }
            if (txtquantidade.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Quantidade!";
                txtquantidade.Focus();
                return;

            }

            Salvar();

          
        }

        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "INSERT INTO produtos (nome, descricao, valor, quantidade, categoria, id_fornecedor) VALUES (@nome, @descricao, @valor, @quantidade, @categoria, @id_fornecedor)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtnome.Text);
            cmd.Parameters.AddWithValue("@descricao", txtdescricao.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtvalor.Text));
            cmd.Parameters.AddWithValue("@quantidade", txtquantidade.Text);
            cmd.Parameters.AddWithValue("@categoria", cbCategoria.SelectedItem.Text); //associação de tabelas
            cmd.Parameters.AddWithValue("@id_fornecedor", cbFornecedor.SelectedItem.Value); //relacionamento de tabelas


            cmd.ExecuteNonQuery();
            lblMensagemOK.Text = "Salvo com Sucesso !!";
            Listar();
            con.FecharCon();

            btnSalvar.Enabled = false;
            btnBuscar.Enabled = true;
            txtbuscar.Enabled = true;
            ApagarCampos();
        }

        private void LimparCampos()
        {
            txtnome.Text = "";
            txtdescricao.Text = "";
            txtvalor.Text = "";
            txtquantidade.Text = "";
            lblMensagemErro.Text = "";
            lblMensagemOK.Text = "";




        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            btnSalvar.Enabled = true; //botão novo habilita botão salvar
            LimparCampos();
            HabilitarCampos();
            btnBuscar.Enabled = false;
            txtbuscar.Enabled = false;
        }

        protected void txtnome_TextChanged(object sender, EventArgs e)
        {
            lblMensagemErro.Text = ""; //Limpar mensagem de erro
            txtnome.Focus();
        }

        protected void txtdescricao_TextChanged(object sender, EventArgs e)
        {
            lblMensagemErro.Text = "";
            txtdescricao.Focus();
        }

        protected void txtvalor_TextChanged(object sender, EventArgs e)
        {
            lblMensagemErro.Text = "";
            txtvalor.Focus();
        }


        private void ApagarCampos() // médoto criado para apagar caixar depois da digitação
        {
            txtnome.Text = "";
            txtdescricao.Text = "";
            txtvalor.Text = "";
            txtquantidade.Text = "";
            
        }


        private void HabilitarCampos()
        {
            txtnome.Enabled = true;
            txtdescricao.Enabled = true;
            txtvalor.Enabled = true;
            txtquantidade.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtnome.Enabled = false;
            txtdescricao.Enabled = false;
            txtvalor.Enabled = false;
            txtquantidade.Enabled = false;
        }

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32((sender as Button).CommandArgument); //pegar o ID da grid
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT * FROM produtos where id = @id"; //parametro id recebe parametro
            cmd = new MySqlCommand(sql, con.con);
           cmd.Parameters.AddWithValue("@id", id); //sempre tem que jogar abaixo do MySqlCommand
            da.SelectCommand = cmd;
            da.Fill(dt);
            txtnome.Text = dt.Rows[0][1].ToString();
            txtdescricao.Text = dt.Rows[0][2].ToString();
            txtvalor.Text = dt.Rows[0][3].ToString();   // para pegar os dados do banco e editar
            txtquantidade.Text = dt.Rows[0][4].ToString();

            if(dt.Rows[0][5].ToString() != "")          //condição para linha única   
            cbCategoria.SelectedItem.Text = dt.Rows[0][5].ToString();
            if (dt.Rows[0][6].ToString() != "0")          // [] posicão da coluna
                cbFornecedor.SelectedItem.Text = dt.Rows[0][6].ToString();


            idproduto.Value = dt.Rows[0][0].ToString();

            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

            HabilitarCampos();
            con.FecharCon();


        }




        protected void txtquantidade_TextChanged(object sender, EventArgs e)
        {
            lblMensagemErro.Text = "";
        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            if (txtnome.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Nome!";
                txtnome.Focus();
                return;

            }
            if (txtdescricao.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Descrição!";
                txtdescricao.Focus();
                return;

            }
            if (txtvalor.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Valor!";
                txtvalor.Focus();
                return;

            }
            if (txtquantidade.Text == "") 
            {
                lblMensagemErro.Text = "Preencha o campo Quantidade!";
                txtquantidade.Focus();
                return;

            }

            if (idproduto.Value != "")// se for diferente de vazio edita.
            {

                Editar();

            }


            



        }

        private void Editar()  //método botão editar
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "UPDATE produtos SET nome = @nome, descricao = @descricao, valor = @valor, quantidade = @quantidade, categoria = @categoria, id_fornecedor = @id_fornecedor where id =@id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtnome.Text);
            cmd.Parameters.AddWithValue("@descricao", txtdescricao.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtvalor.Text));
            cmd.Parameters.AddWithValue("@quantidade", txtquantidade.Text);
            cmd.Parameters.AddWithValue("@categoria", cbCategoria.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@id_fornecedor", cbFornecedor.SelectedItem.Value); //relacionamento de tabelas
            cmd.Parameters.AddWithValue("@id", idproduto.Value);
            
            cmd.ExecuteNonQuery();
            lblMensagemOK.Text = "Editado com Sucesso !!";
            Listar();
            con.FecharCon();

            btnEditar.Enabled = false;
            DesabilitarCampos();
            ApagarCampos();








        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idproduto.Value != "")
            {
                Excluir();
            }

        }

        private void Excluir()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "DELETE FROM produtos where id = @id";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@id", idproduto.Value);

            cmd.ExecuteNonQuery();
            lblMensagemOK.Text = "Excluído com Sucesso !!";
            Listar();
            con.FecharCon();

            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            DesabilitarCampos();
            ApagarCampos();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensagemOK.Text = "";
            Buscar();
        }

        private void Buscar() //método buscar
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT p.id, p.nome, p.descricao, p.valor, p.quantidade, p.categoria, p.id_fornecedor, f.nome as nomeForm, f.telefone FROM  produtos as p INNER JOIN fornecedores as f ON p.id_fornecedor = f.id where p.nome LIKE @nome order by p.nome asc"; //LIKE É VALOR APROXIMADO
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtbuscar.Text + "%"); // "%" CONCATENA VALOR APROXIMADO.
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                grid.Visible = true;
                grid.DataSource = dt; //receber na Datatable
                grid.DataBind(); // Atualizar dados           

            }
            else
            {

                lblMensagemOK.Text = "Este Produto não foi encontrado !!!";
                Listar();

            }


            con.FecharCon();
            
        }

        protected void btnResrva_Click(object sender, EventArgs e)
        {

        }

        protected void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}