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
            cmd.CommandText = "select * from logins where email = @login and senha = @senha";
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
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro ao conectar o banco de dados!";
            }


            return tem;
        }

        public String cadastrar(String email, String senha, String confSenha)
        {
            tem = false;
            //Nesse metodo vamos usar comando para cadastrar no banco 
            if (senha.Equals(confSenha))
            {
                cmd.CommandText = "insert into logins values (@e, @s);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@s", senha);

                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensagem = "Cadastrado com sucesso!";
                    tem = true;
                }
                catch (SqlException)
                {
                    this.mensagem = "Erro ao conectar o banco de dados!";
                }
            }
            else
            {
                this.mensagem = "Erro! Senha incorreta.";
            }
            
            return mensagem;
        }
    }
}
