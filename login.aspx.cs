using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;





namespace Sabor_da_Fruta
{
    public partial class Login : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        string nomeUsuario, nivelUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {

            panelLogin.Visible = false;
            


        }


    

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                panelLogin.Visible = true;
                lblMensagemErro.Text = "Insira seu usuário!";
                txtUsuario.Focus();
                return;

            }
            if (txtSenha.Text == "")
            {
                panelLogin.Visible = true;
                lblMensagemErro.Text = "Insira sua senha!";
                txtSenha.Focus();
                return;

            }

            Logar();
        }

        private void Logar()
        {
            MySqlCommand cmd;
            MySqlDataReader reader;

            con.AbrirCon(); //usuários do banco
            cmd = new MySqlCommand("SELECT * FROM usuarios where usuario = @usuario and senha = @senha", con.con);
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
            reader = cmd.ExecuteReader(); //extrair dados do usuário

            if(reader.HasRows)
            {

                while (reader.Read())
                {
                    nomeUsuario = reader["nome"].ToString();
                    nivelUsuario = reader["nivel"].ToString();
                    panelLogin.Visible = true;
                    lblMensagemErro.Text = nomeUsuario;




                }
                
                
               // Server.Transfer("index.aspx");
               Response.Redirect("index.aspx?nome=" + nomeUsuario + "&nivel=" + nivelUsuario ); // redirecionamento com parâmetro
                lblMensagemErro.Text = "Logou";
               // panelLogin.Visible = false;
                txtSenha.Text = "";
                txtUsuario.Text = "";

            }
            else
            {
                panelLogin.Visible = true;
                lblMensagemErro.Text = "Dados Incorretos!!";
                txtUsuario.Text = "";
                txtSenha.Text = "";
                txtUsuario.Focus();
            }


        }

    }
}