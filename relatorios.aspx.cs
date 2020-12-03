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
    public partial class relatorios : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        Int32 id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRelatorios_Click(object sender, EventArgs e)
        {
            Listar();
            Listarpedidos();
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
            sql = "SELECT year(datapedido) AS ano, monthname(datapedido) AS mes, sum((valor*quantidade)) AS valortotal FROM pedidos GROUP BY year(datapedido), monthname(datapedido)";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                grid.Visible = true;
                grid.DataSource = dt; //receber na Datatable
                grid.DataBind(); // Atualizar dados           

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
            sql = "SELECT year(datapedido) AS ano, monthname(datapedido) AS mes, count(id) as numeropedidos From pedidos GROUP BY year(datapedido), monthname(datapedido)";
            cmd = new MySqlCommand(sql, con.con);
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

        protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

       
}