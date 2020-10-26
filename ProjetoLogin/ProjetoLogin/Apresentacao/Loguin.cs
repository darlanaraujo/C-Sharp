/* VIDEO AULA DESSE PROJETO
 * https://www.youtube.com/watch?v=iuei9xD0mA4&t=576s
 */

using ProjetoLogin.Apresentacao;
using ProjetoLogin.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoLogin
{
    public partial class Loguin : Form
    {
        public Loguin()
        {
            InitializeComponent();
        }

        private void btnCadastreSe_Click(object sender, EventArgs e)
        {
            Cadastre_se cad = new Cadastre_se();
            cad.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Loguin_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.acessar(txbLogin.Text, txbSenha.Text);

            if (controle.mensagem.Equals(""))
            {
                if (controle.tem)
                {
                    //Caixa de mensagem caso o login ocorra bem.
                    //MessageBox.Show("Logado com sucesso!", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //Caso o login e senha sejam encontrados no banco, o código abaixo leva a proxima tela
                    Principal home = new Principal();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Login ou Senha incorreto! Tente novamente.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }
    }
}
