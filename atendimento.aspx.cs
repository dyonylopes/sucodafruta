using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sabor_da_Fruta
{
    public partial class atendimento : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        Int32 id;
        string nomeUsuario, nivelUsuario;

    

        protected void Page_Load(object sender, EventArgs e)
        {
            nomeUsuario = Request.QueryString["nome"];
            nivelUsuario = Request.QueryString["nivel"];

            if (nomeUsuario == null) //não deixa entrar sem login
            {
                Response.Redirect("login.aspx");
            }
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

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

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
































    }






}