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
            dgvPurchases.DefaultCellStyle.ForeColor = Color.Black;
            if (dgvPurchases.Columns["ID"] != null)
                dgvPurchases.Columns["ID"].Width = 40;

            // dark mode styles data grid view
            dgvPurchases.BackgroundColor = Color.FromArgb(28, 28, 30);
            dgvPurchases.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvPurchases.DefaultCellStyle.ForeColor = Color.White;
            dgvPurchases.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dgvPurchases.DefaultCellStyle.SelectionForeColor = Color.White;


            dgvPurchases.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgvPurchases.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPurchases.EnableHeadersVisualStyles = false;
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


        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            // abrimos um SaveFileDialog para o usuário escolher onde salvar o ficheiro CSV
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Ficheiros CSV (*.csv)|*.csv";
                sfd.FileName = "Compras_Fechadas.csv"; // Nome do ficheiro por defeito
                sfd.Title = "Guardar ficheiro de compras fechadas";

                // se o usuário clicar em "Salvar", chamamos o método do controller para exportar as compras fechadas para o caminho escolhido pelo usuário
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // chamamos o método do controller para exportar as compras fechadas para o caminho escolhido pelo usuário
                        _controller.ExportToCSV(sfd.FileName);
                        MessageBox.Show("Ficheiro exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao exportar o ficheiro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        
    }
}