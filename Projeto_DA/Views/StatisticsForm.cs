using System;
using System.Windows.Forms;
using Projeto_DA.Controllers;

namespace Projeto_DA.Views
{
    public partial class StatisticsForm : Form
    {
        // controlador de estatísticas
        private StatisticsController _controller;

        public StatisticsForm()
        {
            InitializeComponent();
            _controller = new StatisticsController();
        }

        // -------------------------------------------------------------------
        // Evento de carregamento do formulário
        // -------------------------------------------------------------------
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            // carregamos os dados do separador 1 (estatísticas)
            CarregarEstatisticasMeses();
            CarregarEstatisticasCompras();
        }

        // -------------------------------------------------------------------
        // TAB 1-A: carrega a listagem de todos os meses com orçamento,
        // total de compras e diferença
        // -------------------------------------------------------------------
        private void CarregarEstatisticasMeses()
        {
            try
            {
                // pedimos os dados ao controlador e ligamos à tabela
                dgvMeses.DataSource = _controller.GetEstatisticasMeses();

                // renomear as colunas para português
                if (dgvMeses.Columns["Mês"] != null)
                    dgvMeses.Columns["Mês"].HeaderText = "Mês";
                if (dgvMeses.Columns["Ano"] != null)
                    dgvMeses.Columns["Ano"].HeaderText = "Ano";
                if (dgvMeses.Columns["Orçamento"] != null)
                {
                    dgvMeses.Columns["Orçamento"].HeaderText = "Orçamento (€)";
                    dgvMeses.Columns["Orçamento"].DefaultCellStyle.Format = "F2";
                }
                if (dgvMeses.Columns["TotalCompras"] != null)
                {
                    dgvMeses.Columns["TotalCompras"].HeaderText = "Total Compras (€)";
                    dgvMeses.Columns["TotalCompras"].DefaultCellStyle.Format = "F2";
                }
                if (dgvMeses.Columns["Diferença"] != null)
                {
                    dgvMeses.Columns["Diferença"].HeaderText = "Diferença (€)";
                    dgvMeses.Columns["Diferença"].DefaultCellStyle.Format = "F2";
                }
            }
            catch (Exception ex)
            {
                // em caso de erro, mostramos uma mensagem informativa
                MessageBox.Show("Erro ao carregar estatísticas de meses: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------------------
        // TAB 1-B: carrega a listagem de compras fechadas com percentagens
        // de artigos previstos e não previstos
        // -------------------------------------------------------------------
        private void CarregarEstatisticasCompras()
        {
            try
            {
                // pedimos os dados ao controlador e ligamos à tabela
                dgvComprasFechadas.DataSource = _controller.GetEstatisticasCompras();

                // renomear as colunas para português
                if (dgvComprasFechadas.Columns["Compra"] != null)
                    dgvComprasFechadas.Columns["Compra"].HeaderText = "Nome da Compra";
                if (dgvComprasFechadas.Columns["DataFecho"] != null)
                    dgvComprasFechadas.Columns["DataFecho"].HeaderText = "Data Fecho";
                if (dgvComprasFechadas.Columns["TotalItens"] != null)
                    dgvComprasFechadas.Columns["TotalItens"].HeaderText = "Total Itens";
                if (dgvComprasFechadas.Columns["Previstos"] != null)
                    dgvComprasFechadas.Columns["Previstos"].HeaderText = "Previstos";
                if (dgvComprasFechadas.Columns["NaoPrevistos"] != null)
                    dgvComprasFechadas.Columns["NaoPrevistos"].HeaderText = "Não Previstos";
                if (dgvComprasFechadas.Columns["PctPrevistos"] != null)
                    dgvComprasFechadas.Columns["PctPrevistos"].HeaderText = "% Previstos";
                if (dgvComprasFechadas.Columns["PctNaoPrevistos"] != null)
                    dgvComprasFechadas.Columns["PctNaoPrevistos"].HeaderText = "% Não Previstos";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estatísticas de compras: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------------------
        // TAB 2: botão "Gerar Sugestão de Lista de Compras"
        // carrega o orçamento sugerido e a lista sugerida para a semana atual
        // -------------------------------------------------------------------
        private void btnGerarSugestao_Click(object sender, EventArgs e)
        {
            try
            {
                // pedimos os dados de apoio à decisão ao controlador
                var dados = _controller.GetDecisionSupport();

                // mostramos o orçamento sugerido para o próximo mês
                lblOrcamentoSugerido.Text = $"Orçamento Sugerido para o Próximo Mês: {dados.OrcamentoSugerido:F2} €";

                // mostramos o orçamento restante
                lblOrcamentoRestante.Text = $"Orçamento Restante do Mês Atual: {dados.OrcamentoRestante:F2} €";

                // mostramos a semana atual do mês
                lblSemanaAtual.Text = $"Semana atual do mês: {dados.SemanaAtual}ª semana — sugestões baseadas no histórico desta semana";

                // mostramos o custo total sugerido
                lblCustoTotal.Text = $"Custo Estimado Total da Lista Sugerida: {dados.CustoTotalSugerido:F2} €";

                // ligamos a lista sugerida à tabela
                dgvListaSugerida.DataSource = dados.ListaSugerida;

                // renomear colunas para português e configurar visibilidade
                if (dgvListaSugerida.Columns["ArticleId"] != null)
                    dgvListaSugerida.Columns["ArticleId"].Visible = false;

                if (dgvListaSugerida.Columns["Artigo"] != null)
                    dgvListaSugerida.Columns["Artigo"].HeaderText = "Artigo";
                if (dgvListaSugerida.Columns["VezesComprado"] != null)
                    dgvListaSugerida.Columns["VezesComprado"].HeaderText = "Nº de Compras";
                if (dgvListaSugerida.Columns["QtdSugerida"] != null)
                {
                    dgvListaSugerida.Columns["QtdSugerida"].HeaderText = "Quantidade Média";
                    dgvListaSugerida.Columns["QtdSugerida"].DefaultCellStyle.Format = "F2";
                }
                if (dgvListaSugerida.Columns["PrecoMedio"] != null)
                {
                    dgvListaSugerida.Columns["PrecoMedio"].HeaderText = "Preço Médio (€)";
                    dgvListaSugerida.Columns["PrecoMedio"].DefaultCellStyle.Format = "F2";
                }
                if (dgvListaSugerida.Columns["CustoEstimado"] != null)
                {
                    dgvListaSugerida.Columns["CustoEstimado"].HeaderText = "Custo Estimado (€)";
                    dgvListaSugerida.Columns["CustoEstimado"].DefaultCellStyle.Format = "F2";
                }

                // se a lista estiver vazia, informamos o utilizador
                if (dgvListaSugerida.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Não existem dados históricos suficientes para sugerir uma lista ou o orçamento restante é insuficiente.\nRealize algumas compras primeiro!",
                        "Sem dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar sugestão: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}