using System;
using System.Linq;
using System.Windows.Forms;
using Projeto_DA.Controllers;
using Projeto_DA.Models;

namespace Projeto_DA.Views
{
    public partial class ArticlesForm : Form
    {
        private ArticleController _articleController;
        private ArticleTypeController _categoryController;

        public ArticlesForm()
        {
            InitializeComponent();
            _articleController = new ArticleController();
            _categoryController = new ArticleTypeController();
        }

        private void ArticlesForm_Load(object sender, EventArgs e)
        {
            LoadCategories(); // primeiro carregamos as categorias para preencher os combo boxes
            LoadData();       // depois carregamos os artigos para mostrar na tabela, ja com a opcao de filtrar por categoria
        }

        private void LoadCategories()
        {
            var categories = _categoryController.GetAll();

            // preenchemos o combo box de categorias para adicionar/editar artigos
            cmbCategory.DataSource = categories.ToList();
            cmbCategory.DisplayMember = "Name"; // oque o utilizador vê
            cmbCategory.ValueMember = "ID";   // oque o programa usa para identificar a categoria

            // preenchemos o combo box de filtro, adicionando uma opção "Todos" no início da lista
            var filterCategories = categories.ToList();
            filterCategories.Insert(0, new ArticleType { ID = 0, Name = "Todos" });
            cmbFilter.DataSource = filterCategories;
            cmbFilter.DisplayMember = "Name";
            cmbFilter.ValueMember = "ID";
        }

        private void LoadData()
        {
            int? filterId = null;

            // vemos se o utilizador selecionou um filtro de categoria (diferente de "Todos") e, se sim, usamos esse filtro para buscar os artigos
            if (cmbFilter.SelectedValue != null && cmbFilter.SelectedValue is int selectedId && selectedId > 0)
            {
                filterId = selectedId;
            }

            var articles = _articleController.GetAll(filterId);

            // formatormos os dados para exibir na tabela, mostrando o nome do artigo e o nome da categoria em vez dos IDs
            var displayList = articles.Select(a => new
            {
                Id = a.ID,
                Nome = a.Name,
                Categoria = a.ArticleType?.Name
            }).ToList();

            dgvArticles.DataSource = displayList;
            dgvArticles.Columns["Id"].Width = 50;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name) || cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Preencha o nome e selecione uma categoria!");
                return;
            }

            _articleController.Add(name, (int)cmbCategory.SelectedValue);
            txtName.Clear();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvArticles.CurrentRow != null)
            {
                int id = (int)dgvArticles.CurrentRow.Cells["Id"].Value;
                string newName = txtName.Text.Trim();

                if (!string.IsNullOrEmpty(newName) && cmbCategory.SelectedValue != null)
                {
                    _articleController.Update(id, newName, (int)cmbCategory.SelectedValue);
                    txtName.Clear();
                    LoadData();
                    MessageBox.Show("Artigo atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvArticles.CurrentRow != null)
            {
                int id = (int)dgvArticles.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show("Tem a certeza que deseja eliminar este artigo?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _articleController.Delete(id);
                        LoadData();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao eliminar o artigo. Pode estar associado a uma compra.");
                    }
                }
            }
        }

        private void dgvArticles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticles.CurrentRow != null)
            {
                // preenchemos a caixa de texto com o nome do artigo selecionado para facilitar a edição
                txtName.Text = dgvArticles.CurrentRow.Cells["Nome"].Value.ToString();

                // procuramos o nome da categoria do artigo selecionado e selecionamos essa categoria no combo box para facilitar a edição
                string categoryName = dgvArticles.CurrentRow.Cells["Categoria"].Value?.ToString();
                if (categoryName != null)
                {
                    cmbCategory.SelectedIndex = cmbCategory.FindStringExact(categoryName);
                }
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // quando o filtro de categoria for alterado, recarregamos os artigos para mostrar apenas os artigos da categoria selecionada (ou todos se "Todos" estiver selecionado)
            LoadData();
        }
    }
}