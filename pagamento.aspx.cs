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
        // Buscar menu 
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            lblMensagemOK.Text = "";
            Buscar();
            Buscarcomanda();
            ApagarCampos();
        }

        //método buscar do menu trazendo numero comanda / produto / valor total da comanda
        private void Buscar() 
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT numero, group_concat(nome separator ' , ') as produto, SUM((quantidade * valor)) As valor_total FROM itenspedidos  where numero LIKE @numero GROUP BY NUMERO";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@numero", txtbuscar.Text);
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

                lblMensagemErro.Text = "Esta Comanda não foi encontrado !!!";
                Listar();

            }


            con.FecharCon();

        }
        //método buscarcomanda do menu trazendo todos os itens do pedido
        private void Buscarcomanda() //método buscarcomanda
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter da = new MySqlDataAdapter(); //armazenar informações do mysql
            DataTable dt = new DataTable(); //para receber dados do mysql

            con.AbrirCon();
            sql = "SELECT id, numero, nome, descricao, quantidade, valor, observacao, SUM((quantidade * valor)) as Valor_Total FROM itenspedidos where numero LIKE @numero GROUP BY id"; //LIKE É VALOR APROXIMADO
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@numero", txtbuscar.Text); 
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                gridview1.Visible = true;
                gridview1.DataSource = dt; //receber na Datatable
                gridview1.DataBind(); // Atualizar dados           

            }
            


            con.FecharCon();

        }


      

      

        // listar do buscar menu para trazer todas as comanda ativas
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

                lblMensagemErro.Text = "Não possuem comandas ativas !!!";
     
               


            }


            con.FecharCon();
        }


       

        // botao select da gridview
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

            btnSalvar.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            con.FecharCon();


        }


        protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void ApagarCampos() // médoto criado para apagar caixar depois da digitação
        {

            txtbuscar.Text = ""; 


        }

        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // botão  Liberar 
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        // botão editar
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }
        // botão limpar
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idproduto.Value != "")
            {
                Excluir();
            }
        }

        // metodo salvar para o botao liberar
        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();
            sql = "INSERT INTO pedidos (numero, nome, descricao, quantidade, valor, observacao, datapedido) VALUES (@numero, @nome, @descricao, @quantidade, @valor, @observacao,now())";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@numero", txtnumero.Text);
            //  cmd.Parameters.AddWithValue("@numero", Convert.ToInt32(txtnumero.Text));
            // cmd.Parameters.AddWithValue("@numero", cbComanda.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@nome", txtnome.Text);
            cmd.Parameters.AddWithValue("@descricao", txtdescricao.Text);
            cmd.Parameters.AddWithValue("@quantidade", txtquantidade.Text);
            cmd.Parameters.AddWithValue("@valor", Convert.ToDouble(txtvalor.Text));
            cmd.Parameters.AddWithValue("@observacao", txtobservacao.Text);

            cmd.ExecuteNonQuery();
            lblMensagemOK.Text = "Liberado com Sucesso !!";
            con.FecharCon();

            btnSalvar.Enabled = true;
            
            

        }


        // metodo editar para o botao editar
        private void Editar()  //método botão editar
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "UPDATE itenspedidos SET numero = @numero, quantidade = @quantidade, observacao = @observacao where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@numero",Convert.ToInt32(txtnumero.Text));


            cmd.Parameters.AddWithValue("@quantidade", txtquantidade.Text);

            cmd.Parameters.AddWithValue("@observacao", txtobservacao.Text);
            cmd.Parameters.AddWithValue("@id", idproduto.Value);

            cmd.ExecuteNonQuery();
            lblMensagemOK.Text = "Editado com Sucesso !!";
            Listar();
            con.FecharCon();

            btnEditar.Enabled = false;
            DesabilitarCampos();
            ApagarCampos1();
        }

        // metodo excluir para o botao limpar
        private void Excluir()
        {
            string sql;
            MySqlCommand cmd;

            con.AbrirCon();

            sql = "DELETE FROM itenspedidos where id = @id";
            cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@id", idproduto.Value);

            cmd.ExecuteNonQuery();
            lblMensagemOK.Text = "Excluído com Sucesso !!";
            Listar();
            con.FecharCon();

           
            ApagarCampos1();
        }


        private void ApagarCampos1() // médoto criado para apagar caixar depois da digitação
        {
            txtnome.Text = "";
            txtdescricao.Text = "";
            txtvalor.Text = "";
            txtquantidade.Text = "";
            txtobservacao.Text = "";
            
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
        }

       
    }
}