using Projeto_DA.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_DA.Views
{

    public partial class PurchaseDetailsForm : Form
    {
        private int _purchaseId;
        private PurchaseItemController _itemController;
        private ArticleController _articleController;
        private ArticleTypeController _typeController;

        public PurchaseDetailsForm(int purchaseId) // construtor recebe o ID da compra para carregar os detalhes
        {
            InitializeComponent();
            _typeController = new ArticleTypeController();
            _purchaseId = purchaseId;
            _itemController = new PurchaseItemController();
            _articleController = new ArticleController();
        }

        private void PurchaseDetailsForm_Load(object sender, EventArgs e)
        {
            // carregamos os tipos de artigos para o combo box
            cmbCategories.DataSource = _typeController.GetAll();
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "ID";



            LoadItems();
            CalculateTotal();
            CheckBudget();
        }

        private void LoadItems()
        {
            dgvItems.DataSource = _itemController.GetByPurchase(_purchaseId);


        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // 1. Проверяем, выбран ли вообще товар
            if (cmbArticles.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione um artigo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int articleId = (int)cmbArticles.SelectedValue;

            // 2. Безопасное чтение чисел (TryParse)
            if (!decimal.TryParse(txtQuantity.Text, out decimal qty) || !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Por favor, insira números válidos na Quantidade e no Preço!", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Собираем остальные данные
            bool isPlanned = !chkNotPlanned.Checked;
            string notes = txtNotes.Text.Trim();

            // 4. Отправляем в базу
            _itemController.Add(_purchaseId, articleId, qty, price, isPlanned, notes);

            // 5. Очищаем поля после успешного добавления
            txtNotes.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            chkNotPlanned.Checked = false;

            // 6. Обновляем всё на экране
            LoadItems();
            CalculateTotal();
            CheckBudget();
        }


        private void CheckBudget()
        {
            using (var context = new Projeto_DA.Data.AppDbContext())
            {
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;

                // 1. procuramos o orçamento para o mês atual. Se não existir, consideramos que o orçamento é zero
                var budget = context.Budgets.FirstOrDefault(b => b.Month == currentMonth && b.Year == currentYear);
                decimal budgetAmount = budget != null ? budget.Amount : 0;

                // 2. contamos o total gasto somando o valor total de cada item da compra (quantidade x preço) que está na DataGridView. Se a célula "Total" estiver vazia, consideramos que o valor é zero.
                decimal totalSpent = 0;
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    if (row.Cells["Total"].Value != null)
                    {
                        totalSpent += Convert.ToDecimal(row.Cells["Total"].Value);
                    }
                }

                // 3. contamos o orçamento restante subtraindo o total gasto do orçamento disponível
                decimal remaining = budgetAmount - totalSpent;

                // 4. output para o ecra
                lblRemainingBudget.Text = $"Orçamento Restante: {remaining:F2} €";

                // 5. alert     
                if (remaining < 0)
                {
                    lblRemainingBudget.ForeColor = System.Drawing.Color.Red;
                    MessageBox.Show("Atenção! Ultrapassou o orçamento mensal disponível!", "Aviso de Orçamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblRemainingBudget.ForeColor = System.Drawing.Color.LightGreen;
                }
            }
        }
        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {


                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }

            lblTotal.Text = $"Total da Compra: {total:C2}";
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategories.SelectedValue != null && cmbCategories.SelectedValue is int typeId)
            {
                // buscamos os artigos filtrados pelo tipo selecionado e preenchemos o combo box de artigos
                using (var context = new Projeto_DA.Data.AppDbContext())
                {
                    var filteredArticles = context.Articles
                        .Where(a => a.ArticleTypeID == typeId)
                        .Select(a => new { ID = a.ID, Name = a.Name })
                        .ToList();

                    cmbArticles.DataSource = filteredArticles;
                    cmbArticles.DisplayMember = "Name";
                    cmbArticles.ValueMember = "ID";
                }
            }
        }
    }
}
