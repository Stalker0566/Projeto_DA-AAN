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
            // Ocultar tabControl1 que não é utilizado
            tabControl1.Visible = false;

            // 1. Carregar dados gerais do painel
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

            // 2. Carregar apoio à decisão (sugestão de orçamento e lista inteligente)
            try
            {
                var decision = _controller.GetDecisionSupport();

                lblDecisionInfo.Text = $"Sugestão para Semana {decision.CurrentWeek}:\nOrç. Sugerido: {decision.SuggestedBudget:F2} €";
                lblDecisionInfo.Location = new Point(850, 20);
                lblDecisionInfo.Size = new Size(310, 60);

                // Configurar DataGridView de sugestões
                dataGridView1.Location = new Point(850, 90);
                dataGridView1.Size = new Size(310, 240);
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.RowHeadersVisible = false;

                // Estilo escuro para o grid condizente com o form
                dataGridView1.BackgroundColor = Color.FromArgb(38, 38, 40);
                dataGridView1.ForeColor = Color.Black; // Texto das células legível em fundo branco/cinza padrão

                dataGridView1.DataSource = decision.SuggestedList;

                if (dataGridView1.Columns["Artigo"] != null)
                    dataGridView1.Columns["Artigo"].HeaderText = "Artigo";
                if (dataGridView1.Columns["VezesComprado"] != null)
                    dataGridView1.Columns["VezesComprado"].HeaderText = "Qtd. Compras";
                if (dataGridView1.Columns["QtdSugerida"] != null)
                    dataGridView1.Columns["QtdSugerida"].HeaderText = "Média Qtd.";
            }
            catch (Exception ex)
            {
                lblDecisionInfo.Text = "Erro ao carregar sugestões.";
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}