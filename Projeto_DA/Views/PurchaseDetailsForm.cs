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
        private StatisticsController _statisticsController;

        public PurchaseDetailsForm(int purchaseId) // construtor recebe o ID da compra para carregar os detalhes
        {
            InitializeComponent();
            _typeController = new ArticleTypeController();
            _purchaseId = purchaseId;
            _itemController = new PurchaseItemController();
            _articleController = new ArticleController();
            _statisticsController = new StatisticsController();
        }

        private void PurchaseDetailsForm_Load(object sender, EventArgs e)
        {
            // associar eventos dos botoes que foram gerados no designer
            btnRemoveItem.Click += btnRemoveItem_Click;
            btnFecharCompra.Click += btnFecharCompra_Click;
            btnSugestao.Click += btnSugestao_Click;

            // carregamos os tipos de artigos para o combo box
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "ID";
            cmbCategories.DataSource = _typeController.GetAll();

            LoadItems();
            CalculateTotal();
            CheckBudget();
            CheckIfClosed();
        }

        private void CheckIfClosed()
        {
            using (var context = new Data.AppDbContext())
            {
                var purchase = context.Purchases.Find(_purchaseId);
                if (purchase != null && purchase.IsClosed)
                {
                    btnAddItem.Enabled = false;
                    btnRemoveItem.Enabled = false;
                    btnFecharCompra.Enabled = false;
                    btnSugestao.Enabled = false;
                    txtQuantity.Enabled = false;
                    txtPrice.Enabled = false;
                    cmbArticles.Enabled = false;
                    cmbCategories.Enabled = false;
                    chkNotPlanned.Enabled = false;
                    txtNotes.Enabled = false;
                    btnFecharCompra.Text = "Compra Fechada";
                }
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow != null)
            {
                // Verifica se o ID do item é válido
                int index = dgvItems.CurrentRow.Index;
                var cells = dgvItems.CurrentRow.Cells;
                if (cells["ID"].Value != null && int.TryParse(cells["ID"].Value.ToString(), out int itemId))
                {
                    _itemController.Delete(itemId);
                    LoadItems();
                    CalculateTotal();
                    CheckBudget();
                }
            }
        }

        private void btnFecharCompra_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja fechar esta compra? Não poderá adicionar mais artigos depois.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (var context = new Data.AppDbContext())
                {
                    var p = context.Purchases.Find(_purchaseId);
                    var currentUser = context.Users.Find(SessionManager.CurrentUserId);

                    if (p != null)
                    {
                        p.IsClosed = true;
                        p.ClosedDate = DateTime.Now;
                        p.ClosedBy = currentUser;
                        context.SaveChanges();
                    }
                }
                LoadItems();
                CalculateTotal();
                CheckBudget();
                CheckIfClosed();
            }
        }

        private void LoadItems()
        {
            dgvItems.DataSource = _itemController.GetByPurchase(_purchaseId);

            if (dgvItems.Columns["Quantidade"] != null)
                dgvItems.Columns["Quantidade"].DefaultCellStyle.Format = "F2";
            if (dgvItems.Columns["Preço"] != null)
                dgvItems.Columns["Preço"].DefaultCellStyle.Format = "F2";
            if (dgvItems.Columns["Total"] != null)
                dgvItems.Columns["Total"].DefaultCellStyle.Format = "F2";
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            // 1. Verifica se um artigo foi selecionado
            int articleId = 0;
            if (cmbArticles.SelectedValue is int id)
            {
                articleId = id;
            }
            else if (cmbArticles.SelectedValue is Projeto_DA.Models.Article art)
            {
                articleId = art.ID;
            }
            else if (cmbArticles.SelectedValue != null && int.TryParse(cmbArticles.SelectedValue.ToString(), out int parsedId))
            {
                articleId = parsedId;
            }
            else
            {
                MessageBox.Show("Por favor, selecione um artigo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Leitura segura de números (TryParse)
            if (!decimal.TryParse(txtQuantity.Text, out decimal qty) || !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Por favor, insira números válidos na Quantidade e no Preço!", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Recolha dos restantes dados
            bool isPlanned = !chkNotPlanned.Checked;
            string notes = txtNotes.Text.Trim();

            // 4. Gravação na base de dados
            _itemController.Add(_purchaseId, articleId, qty, price, isPlanned, notes);

            // 5. Limpa os campos após inserção com sucesso
            txtNotes.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            chkNotPlanned.Checked = false;

            // 6. Atualiza todos os dados no ecrã
            LoadItems();
            CalculateTotal();
            CheckBudget();
        }


        private void CheckBudget()
        {
            using (var context = new Projeto_DA.Data.AppDbContext())
            {
                var purchase = context.Purchases.Find(_purchaseId);
                if (purchase == null) return;

                int purchaseMonth = purchase.CreatedDate.Month;
                int purchaseYear = purchase.CreatedDate.Year;

                // 1. procuramos o orçamento para o mês e ano desta compra. Se não existir, consideramos que o orçamento é zero
                var budget = context.Budgets.FirstOrDefault(b => b.Month == purchaseMonth && b.Year == purchaseYear);
                decimal budgetAmount = budget != null ? budget.Amount : 0;

                // 2. contamos o total gasto de todas as compras deste mesmo mês e ano
                decimal totalSpent = context.PurchaseItems
                    .Where(pi =>
                        pi.Purchase.CreatedDate.Month == purchaseMonth &&
                        pi.Purchase.CreatedDate.Year == purchaseYear)
                    .Sum(pi => (decimal?)(pi.BoughtQuantity * pi.UnitPrice)) ?? 0;

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

            lblTotal.Text = $"Total da Compra: {total:F2} €";
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategories.SelectedValue != null)
            {
                int typeId = 0;
                bool ok = false;
                if (cmbCategories.SelectedValue is int id)
                {
                    typeId = id;
                    ok = true;
                }
                else if (cmbCategories.SelectedValue is Projeto_DA.Models.ArticleType articleType)
                {
                    typeId = articleType.ID;
                    ok = true;
                }
                else if (int.TryParse(cmbCategories.SelectedValue.ToString(), out id))
                {
                    typeId = id;
                    ok = true;
                }

                if (ok)
                {
                    // buscamos os artigos filtrados pelo tipo selecionado e preenchemos o combo box de artigos
                    using (var context = new Projeto_DA.Data.AppDbContext())
                    {
                        var filteredArticles = context.Articles
                            .Where(a => a.ArticleTypeID == typeId)
                            .ToList();

                        cmbArticles.DataSource = null; // Clear first to force rebind
                        cmbArticles.DisplayMember = "Name";
                        cmbArticles.ValueMember = "ID";
                        cmbArticles.DataSource = filteredArticles;
                    }
                }
                else
                {
                    cmbArticles.DataSource = null;
                }
            }
            else
            {
                cmbArticles.DataSource = null;
            }
        }

        private void btnSugestao_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Deseja preencher automaticamente a lista com sugestões baseadas no seu orçamento restante e histórico de artigos mais comprados para esta semana?", 
                "Sugerir Artigos", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Obtemos as sugestões
                    var dados = _statisticsController.GetDecisionSupport();
                    
                    if (dados.ListaSugerida == null || dados.ListaSugerida.Count == 0)
                    {
                        MessageBox.Show(
                            "Não existem artigos sugeridos para adicionar (ou o orçamento restante é insuficiente ou não há histórico).",
                            "Sem Sugestões",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }

                    int adicionadosCount = 0;
                    foreach (var item in dados.ListaSugerida)
                    {
                        // Evita adicionar duplicados na compra atual
                        bool jaExiste = false;
                        foreach (DataGridViewRow row in dgvItems.Rows)
                        {
                            if (row.Cells["Artigo"].Value != null && 
                                row.Cells["Artigo"].Value.ToString() == item.Artigo)
                            {
                                jaExiste = true;
                                break;
                            }
                        }

                        if (!jaExiste)
                        {
                            _itemController.Add(_purchaseId, item.ArticleId, item.QtdSugerida, item.PrecoMedio, true, "Sugestão Automática");
                            adicionadosCount++;
                        }
                    }

                    if (adicionadosCount > 0)
                    {
                        MessageBox.Show(
                            $"{adicionadosCount} artigos sugeridos foram adicionados com sucesso!", 
                            "Sucesso", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                        LoadItems();
                        CalculateTotal();
                        CheckBudget();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Todos os artigos sugeridos já estão presentes na lista de compras.",
                            "Informação",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao gerar e aplicar sugestão: " + ex.Message,
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
