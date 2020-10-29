using ProjetoLogin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogin.Modelo
{
    public class Controle
    {
        public bool tem;
        public String mensagem = "";
        public bool acessar(String login, String senha)
        {
            LoginDalComandos loginDal = new LoginDalComandos();
            tem = loginDal.verificarLogin(login, senha);

            if (!loginDal.mensagem.Equals("")) //aqui compara se a msg está vazia ou não.
            {
                this.mensagem = loginDal.mensagem;
            }
            return tem;
        }
        public String cadastrar(String email, String senha, String confSenha)
        {
            LoginDalComandos loginDal = new LoginDalComandos();
            this.mensagem = loginDal.cadastrar(email, senha, confSenha);

            if (loginDal.tem) //a mensagem que vai vir é de sucesso
            {
                this.tem = true;
            }
            return mensagem;
        } 
    }
}
