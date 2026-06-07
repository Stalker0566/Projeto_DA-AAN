using System;
using System.Windows.Forms;
using Projeto_DA.Controllers;

namespace Projeto_DA.Views
{
    public partial class PurchasesForm : Form
    {
        private PurchaseController _controller;

        public PurchasesForm()
        {
            InitializeComponent();
            _controller = new PurchaseController();
        }

        private void PurchasesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvPurchases.DataSource = _controller.GetAll();
            if (dgvPurchases.Columns["ID"] != null)
                dgvPurchases.Columns["ID"].Width = 40;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Insira o nome da compra (ex: Compras de Maio)!");
                return;
            }

            _controller.Add(name);
            txtName.Clear();
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.CurrentRow != null)
            {
                int id = (int)dgvPurchases.CurrentRow.Cells["ID"].Value;
                string estado = dgvPurchases.CurrentRow.Cells["Estado"].Value.ToString();

                if (estado == "Fechada")
                {
                    MessageBox.Show("Esta compra já está fechada!");
                    return;
                }

                var result = MessageBox.Show("Deseja fechar esta compra? Não poderá adicionar mais artigos depois.", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _controller.ClosePurchase(id);
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.CurrentRow != null)
            {
                int id = (int)dgvPurchases.CurrentRow.Cells["ID"].Value;
                var result = MessageBox.Show("Tem a certeza que deseja eliminar esta compra e todos os seus artigos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _controller.Delete(id);
                    LoadData();
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.CurrentRow != null)
            {
                int id = (int)dgvPurchases.CurrentRow.Cells["ID"].Value;
                using (PurchaseDetailsForm details = new PurchaseDetailsForm(id))
                {
                    details.ShowDialog();
                }
            }
        }
    }
}