using System;
using System.Windows.Forms;
using Projeto_DA.Controllers;

namespace Projeto_DA.Views
{
    public partial class LoginForm : Form
    {
        private AuthController _authController;

        public LoginForm()
        {
            InitializeComponent();
            _authController = new AuthController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isSuccess = _authController.Login(username, password);

            if (isSuccess)
            {
                this.DialogResult = DialogResult.OK; // damos OK para indicar que o login foi bem-sucedido
                this.Close(); // fechamos o formulário de login
            }
            else
            {
                MessageBox.Show("Email ou Password Errados.", "Erro de Autorizacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();  // fechamos a aplicação quando o utilizador clicar no botão de sair
        }
    }
}