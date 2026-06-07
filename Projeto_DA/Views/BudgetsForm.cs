using System;
using System.Windows.Forms;
using Projeto_DA.Controllers;

namespace Projeto_DA.Views
{
    public partial class BudgetsForm : Form
    {
        private BudgetController _budgetController;

        public BudgetsForm()
        {
            InitializeComponent();
            _budgetController = new BudgetController();
        }

        private void BudgetsForm_Load(object sender, EventArgs e)
        {
            // quando o formulário é carregado, chamamos o método LoadData para buscar os orçamentos e mostrar na tabela
            LoadData();
        }

        private void LoadData()
        {
            // get all budgets and bind to DataGridView
            dgvBudgets.DataSource = _budgetController.GetAll();
            if (dgvBudgets.Columns["ID"] != null)
                dgvBudgets.Columns["ID"].Width = 40;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // validamos os campos de entrada para garantir que o mês, ano e valor são números válidos
            if (int.TryParse(txtMonth.Text, out int month) &&
                int.TryParse(txtYear.Text, out int year) &&
                decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                // validamos se o mês está entre 1 e 12
                if (month < 1 || month > 12)
                {
                    MessageBox.Show("Mês inválido! Insira um valor entre 1 e 12.");
                    return;
                }
                // validamos se o ano é um valor razoável (por exemplo, entre 2000 e 2100)
                bool success = _budgetController.Add(month, year, amount);
                if (success)
                {
                    ClearFields();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Já existe um orçamento para este mês e ano!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha os campos apenas com números válidos.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // verificamos se há uma linha selecionada na tabela para editar
            if (dgvBudgets.CurrentRow != null)
            {
                int id = (int)dgvBudgets.CurrentRow.Cells["ID"].Value;

                // validamos os campos de entrada para garantir que o mês, ano e valor são números válidos
                if (int.TryParse(txtMonth.Text, out int month) &&
                    int.TryParse(txtYear.Text, out int year) &&
                    decimal.TryParse(txtAmount.Text, out decimal amount))
                {
                    // validamos se o mês está entre 1 e 12
                    bool success = _budgetController.Update(id, month, year, amount);
                    if (success)
                    {
                        ClearFields();
                        LoadData();
                        MessageBox.Show("Orçamento atualizado!");
                    }
                    else
                    {
                        MessageBox.Show("Já existe outro orçamento para este mês/ano.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // verificamos se há uma linha selecionada na tabela para excluir
            if (dgvBudgets.CurrentRow != null)
            {
                int id = (int)dgvBudgets.CurrentRow.Cells["ID"].Value;
                var result = MessageBox.Show("Tem a certeza?", "Confirmar", MessageBoxButtons.YesNo);
                // se o usuário confirmar a exclusão, chamamos o método Delete do controller para remover o orçamento, limpamos os campos e recarregamos a tabela
                if (result == DialogResult.Yes)
                {
                    _budgetController.Delete(id);
                    ClearFields();
                    LoadData();
                }
            }
        }

        private void dgvBudgets_SelectionChanged(object sender, EventArgs e)
        {
            // quando a seleção na tabela muda, mostramos os detalhes do orçamento selecionado nos campos de texto para facilitar a edição
            if (dgvBudgets.CurrentRow != null)
            {
                txtMonth.Text = dgvBudgets.CurrentRow.Cells["Mês"].Value.ToString();
                txtYear.Text = dgvBudgets.CurrentRow.Cells["Ano"].Value.ToString();
                txtAmount.Text = dgvBudgets.CurrentRow.Cells["Valor"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            // método auxiliar para limpar os campos de entrada após adicionar, editar ou excluir um orçamento
            txtMonth.Clear();
            txtYear.Clear();
            txtAmount.Clear();
        }
    }
}