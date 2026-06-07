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

        public PurchaseDetailsForm(int purchaseId) // construtor recebe o ID da compra para carregar os detalhes
        {
            InitializeComponent();
            _purchaseId = purchaseId;
            _itemController = new PurchaseItemController();
            _articleController = new ArticleController();
        }

        private void PurchaseDetailsForm_Load(object sender, EventArgs e)
        {
            // carregamos os artigos para preencher o combo box de seleção de artigos ao adicionar um item à compra
            cmbArticles.DataSource = _articleController.GetAll();
            cmbArticles.DisplayMember = "Name";
            cmbArticles.ValueMember = "ID";

            LoadItems();
        }

        private void LoadItems()
        {
            dgvItems.DataSource = _itemController.GetByPurchase(_purchaseId);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int articleId = (int)cmbArticles.SelectedValue;
            int qty = int.Parse(txtQuantity.Text);
            decimal price = decimal.Parse(txtPrice.Text);

            _itemController.Add(_purchaseId, articleId, qty, price);
            LoadItems();
        }
        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                // Проверяем, что в колонке "Total" есть число
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            
            lblTotal.Text = $"Total da Compra: {total:C2}";
        }
    }
}
