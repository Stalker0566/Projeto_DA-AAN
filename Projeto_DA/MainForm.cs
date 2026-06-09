using Projeto_DA.Data;
using Projeto_DA.Views;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Projeto_DA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // este metodo e chamado quando a MainForm e carregada
        private void MainForm_Load(object sender, EventArgs e)
        {
            // o nome do usuario logado e exibido no label de boas-vindas
            lblWelcome.Text = $"Bem-vindo, {SessionManager.CurrentUsername}!";

            // metemos a listagem de compras abertas para mostrar as compras que ainda nao foram fechadas
            LoadOpenPurchases();
        }

        private void LoadOpenPurchases()
        {
            using (var context = new AppDbContext())
            {
                // procuramos as compras que ainda nao foram fechadas (IsClosed == false)
                var openPurchases = context.Purchases
                    .Where(p => p.IsClosed == false)
                    .Select(p => new
                    {
                        Código = p.Id,
                        Nome = p.Name,
                        Data_Criação = p.CreatedDate
                    })
                    .ToList();

                // metemos a listagem de compras abertas como fonte de dados do DataGridView
                dataGridViewPurchases.DataSource = openPurchases;
            }
        }

        // --- Event handlers para os botões do menu lateral ---
        // clicando em cada botão, por agora, apenas mostramos uma mensagem indicando que a funcionalidade ainda nao esta implementada



        private void btnArticles_Click(object sender, EventArgs e)
        {
            using (ArticlesForm artForm = new ArticlesForm())
            {
                artForm.ShowDialog();
            }
        }


        private void btnCategories_Click(object sender, EventArgs e)
        {
            using (CategoriesForm catForm = new CategoriesForm())
            {
                catForm.ShowDialog();
            }
        }

        private void btnBudgets_Click(object sender, EventArgs e)
        {
            using (BudgetsForm budgetForm = new BudgetsForm())
            {
                budgetForm.ShowDialog();
            }
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            using (PurchasesForm purForm = new PurchasesForm())
            {
                purForm.ShowDialog();
            }

            // depois de fechar o formulário de compras, recarregamos a listagem de compras abertas para refletir quaisquer mudanças (como uma compra que foi fechada)
            LoadOpenPurchases();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            using (UsersForm f = new UsersForm()) { f.ShowDialog(); }
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            using (StatisticsForm f = new StatisticsForm()) { f.ShowDialog(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}