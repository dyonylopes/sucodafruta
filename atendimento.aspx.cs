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
        private bool dataEntrada;

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
                CarregarNumComanda();

            }
            else
            {

                lblMensagemOK.Text = "Este Produto não foi encontrado !!!";
                Listar();

            }


            CarregarNumComanda();
            con.FecharCon();

        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            cbQuantidade.Text = dt.Rows[0][4].ToString();

            if (dt.Rows[0][5].ToString() != "")          //condição para linha única   

                if (dt.Rows[0][6].ToString() != "0")          // [] posicão da coluna



                    idproduto.Value = dt.Rows[0][0].ToString();



            HabilitarCampos();
            con.FecharCon();
        }

        private void HabilitarCampos()
        {
            txtnome.Enabled = false; // nome
            txtdescricao.Enabled = false; // descricao
            txtvalor.Enabled = false; // valor
            cbQuantidade.Enabled = true;

        }

        private void DesabilitarCampos()
        {

            txtnome.Enabled = false; // nome
            txtdescricao.Enabled = false; // descricao
            txtvalor.Enabled = false; // valor
            cbQuantidade.Enabled = false;

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
            
            if (txtnome.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Nome! 111";
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
            if (cbQuantidade.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Quantidade!";
                cbQuantidade.Focus();
                return;

            }
            if (txtobservacao.Text == "")
            {
                lblMensagemErro.Text = "Preencha o campo Quantidade!";
                txtobservacao.Focus();
                return;

            }

            Salvar();

        }
        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "INSERT INTO itenspedidos (numero, nome, descricao, quantidade, valor, observacao, datapedido) VALUES (@numero, @nome, @descricao, @quantidade, @valor, @observacao,now())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@numero",  Convert.ToInt32(cbComanda.SelectedItem.Text));
            //  cmd.Parameters.AddWithValue("@numero", Convert.ToInt32(txtnumero.Text));
           // cmd.Parameters.AddWithValue("@numero", cbComanda.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@nome", txtnome.Text);
            cmd.Parameters.AddWithValue("@descricao", txtdescricao.Text);
            cmd.Parameters.AddWithValue("@quantidade", cbQuantidade.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtvalor.Text));
            cmd.Parameters.AddWithValue("@observacao", txtobservacao.Text);
            

            cmd.ExecuteNonQuery();
            lblMensagemOK.Text = "Salvo com Sucesso !!";
            Listarpedidos();
            con.FecharCon();
            CarregarNumComanda();
            ApagarCampos();
        }
        private void ApagarCampos() // médoto criado para apagar caixar depois da digitação
        {
            txtnome.Text = "";
            txtdescricao.Text = "";
            txtvalor.Text = "";
            cbQuantidade.Text = "";
            txtobservacao.Text = "";
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void CarregarNumComanda()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT * FROM comanda order by numero asc";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                cbComanda.Enabled = true;
                cbComanda.DataSource = dt; //receber na Datatable
                cbComanda.DataTextField = "numero";
                cbComanda.DataValueField = "id_comanda";
                cbComanda.DataBind(); // Atualizar dados           

            }
            else
            {

                cbComanda.Enabled = false;
                lblMensagemOK.Text = "Não possuem comandas cadastradas !!!";



            }






            con.FecharCon();
        }





        private void Listarpedidos()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon(); //Inner join para pegar de outras tabelas mudo o prefixo
            sql = "SELECT id, numero, nome, descricao, quantidade, valor, observacao FROM itenspedidos order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                gridview1.Visible = true;
                gridview1.DataSource = dt; //receber na Datatable
                gridview1.DataBind(); // Atualizar dados           

            }
            else
            {

                lblMensagemOK.Text = "Não possuem comandas cadastrados !!!";
                btnBuscar.Enabled = false; //se não tiver produtos cadastrados busar fica inativo
                txtbuscar.Enabled = false;
                gridview1.Visible = false;


            }


            con.FecharCon();
        }

   

        protected void cbComanda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }






}