using System;
using System.Windows.Forms;
using Projeto_DA.Controllers;

namespace Projeto_DA.Views
{
    public partial class UsersForm : Form
    {
        private UserController _controller;

        public UsersForm()
        {
            InitializeComponent();
            _controller = new UserController();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvUsers.DataSource = _controller.GetAll();
            if (dgvUsers.Columns["ID"] != null)
                dgvUsers.Columns["ID"].Width = 50;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            if (_controller.Add(user, pass))
            {
                ClearFields();
                LoadData();
            }
            else
            {
                MessageBox.Show("Este nome de utilizador já existe!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int id = (int)dgvUsers.CurrentRow.Cells["ID"].Value;
                string user = txtUsername.Text.Trim();
                string pass = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass)) return;

                if (_controller.Update(id, user, pass))
                {
                    ClearFields();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Este nome já está em uso!");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int id = (int)dgvUsers.CurrentRow.Cells["ID"].Value;
                try
                {
                    if (MessageBox.Show("Tem a certeza?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _controller.Delete(id);
                        ClearFields();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                txtUsername.Text = dgvUsers.CurrentRow.Cells["Nome"].Value.ToString();
                txtPassword.Text = dgvUsers.CurrentRow.Cells["Senha"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}