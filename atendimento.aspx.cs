using System;
using System.Collections.Generic;
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
    }
}