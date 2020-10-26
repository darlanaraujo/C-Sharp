using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.DAL
{
    class LoginDalComandos
    {
        public bool tem = false;
        public String mensagem = ""; //Se a mensagem estiver vazia está Ok.
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool verificarLogin(String login, String senha)
        {
            //Comando sql para verificar se tem no banco
            cmd.CommandText = "select * from nomeDaTabela where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();

                if (dr.HasRows) //Se o Login e Senha for encontrato
                {
                    tem = true;
                }
            }
            catch (SqlException)
            {
                this.mensagem = "Erro ao conectar o banco de dados!";
            }


            return tem;
        }

        public String cadastrar(String email, String senha, String confSenha)
        {
            //Nesse metodo vamos usar comando para cadastrar no banco 
            return mensagem;
        }
    }
}
