using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.DAL
{
    class Conexao
    {
        SqlConnection con = new SqlConnection();
        public Conexao()
        {
            //É preciso baixar ou ter o Microsoft SQL Server Management Studio
            //Para criar o banco de dados.
            con.ConnectionString = @""; //endereço do banco de dados.
        }

        public SqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
