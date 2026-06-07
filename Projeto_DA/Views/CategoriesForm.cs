using System;
using System.Windows.Forms;
using Projeto_DA.Controllers;

namespace Projeto_DA.Views
{
    public partial class CategoriesForm : Form
    {
        private ArticleTypeController _controller;

        public CategoriesForm()
        {
            InitializeComponent();
            _controller = new ArticleTypeController();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // get all categories and bind to DataGridView
            dgvCategories.DataSource = _controller.GetAll();
            dgvCategories.Columns["Id"].Width = 50; // metemos a coluna Id mais estreita
            dgvCategories.Columns["Name"].HeaderText = "Nome da Categoria"; // mudamos o header da coluna Name para algo mais amigavel

            // escondemos a coluna de artigos relacionados, se existir, porque nao queremos mostrar isso aqui
            if (dgvCategories.Columns["Articles"] != null)
                dgvCategories.Columns["Articles"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Insira o nome da categoria!");
                return;
            }

            _controller.Add(name);
            txtName.Clear();
            LoadData(); // atualizamos a listagem para mostrar a nova categoria
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                int id = (int)dgvCategories.CurrentRow.Cells["Id"].Value;
                string newName = txtName.Text.Trim();

                if (!string.IsNullOrEmpty(newName))
                {
                    _controller.Update(id, newName);
                    txtName.Clear();
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                int id = (int)dgvCategories.CurrentRow.Cells["Id"].Value;

                var confirmResult = MessageBox.Show("Tem a certeza que deseja eliminar esta categoria?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        _controller.Delete(id);
                        LoadData();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro: Esta categoria já está a ser usada por um artigo e não pode ser apagada.");
                    }
                }
            }
        }

        // este metodo é chamado quando a seleção no DataGridView muda, e serve para mostrar o nome da categoria selecionada na caixa de texto para facilitar a edição
        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                txtName.Text = dgvCategories.CurrentRow.Cells["Name"].Value.ToString();
            }
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}