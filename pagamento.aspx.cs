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
    public partial class pagamento : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        Int32 id;
       // string nomeUsuario, nivelUsuario;



        protected void Page_Load(object sender, EventArgs e)
        {
          //  nomeUsuario = Request.QueryString["nome"];
          //  nivelUsuario = Request.QueryString["nivel"];

          //  if (nomeUsuario == null) //não deixa entrar sem login
          //  {
           //     Response.Redirect("login.aspx");
           // }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensagemOK.Text = "";
            Buscar();
            Buscarcomanda();
            ApagarCampos();
        }

        
        private void Buscar() //método buscar
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT numero, group_concat(nome separator ' , ') as produto, SUM((quantidade * valor)) As valor_total FROM itenspedidos  where numero LIKE @numero GROUP BY NUMERO";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@numero", txtnumero.Text);
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

                lblMensagemOK.Text = "Esta Comanda não foi encontrado !!!";
                Listar();

            }


            con.FecharCon();

        }


        protected void btnSelectPag_Click(object sender, EventArgs e) //botão selecionar pagamento
        {
            
        }






        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon(); //Inner join para pegar de outras tabelas mudo o prefixo
            sql = "SELECT c.numero, group_concat(nome separator ' , ') as produto, i.valor, i.quantidade, SUM((quantidade * valor)) As valor_total FROM itenspedidos i INNER JOIN comanda c USING(NUMERO) GROUP BY C.NUMERO";
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
                grid.Visible = false;


            }


            con.FecharCon();
        }

    
        private void Buscarcomanda() //método buscarcomanda
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT id, numero, nome, descricao, quantidade, valor, observacao, SUM((quantidade * valor)) as Valor_Total FROM itenspedidos where numero LIKE @numero GROUP BY id"; //LIKE É VALOR APROXIMADO
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@numero", txtnumero.Text); // "%" CONCATENA VALOR APROXIMADO.
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

                lblMensagemOK.Text = "Esta Comanda não foi encontrado !!!";


            }


            con.FecharCon();

        }


        protected void btnSelectPed_Click(object sender, EventArgs e) //botão selecionar pagamento
        {

            id = Convert.ToInt32((sender as Button).CommandArgument); //pegar o ID da grid
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT * FROM itenspedidos where id = @id"; //parametro id recebe parametro
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id); //sempre tem que jogar abaixo do MySqlCommand
            da.SelectCommand = cmd;
            da.Fill(dt);
            txtnumero.Text = dt.Rows[0][1].ToString();
            txtnome.Text = dt.Rows[0][2].ToString();
            txtdescricao.Text = dt.Rows[0][3].ToString();
            txtquantidade.Text = dt.Rows[0][4].ToString();   // para pegar os dados do banco e editar
            txtvalor.Text = dt.Rows[0][5].ToString();
            txtobservacao.Text = dt.Rows[0][6].ToString();

            idproduto.Value = dt.Rows[0][0].ToString();


            con.FecharCon();


        }


        protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void ApagarCampos() // médoto criado para apagar caixar depois da digitação
        {
         
            txtnumero.Text = "";


        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}