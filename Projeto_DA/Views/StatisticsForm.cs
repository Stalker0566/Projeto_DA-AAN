using System;
using System.Drawing;
using System.Windows.Forms;
using Projeto_DA.Controllers;

namespace Projeto_DA.Views
{
    public partial class StatisticsForm : Form
    {
        private StatisticsController _controller;

        public StatisticsForm()
        {
            InitializeComponent();
            _controller = new StatisticsController();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            var data = _controller.GetDashboardData();

            lblUsers.Text = $"Total de Utilizadores: {data.TotalUsers}";
            lblBudget.Text = $"Orçamento deste Mês: {data.BudgetAmount:F2} €";
            lblSpent.Text = $"Gasto este Mês: {data.TotalSpent:F2} €";
            lblRemaining.Text = $"Orçamento Restante: {data.RemainingBudget:F2} €";

            // se o orçamento restante for negativo, mostramos em vermelho, caso contrário, em verde claro
            if (data.RemainingBudget < 0)
            {
                lblRemaining.ForeColor = Color.Red;
            }
            else
            {
                lblRemaining.ForeColor = Color.LightGreen;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}