using Microsoft.EntityFrameworkCore;
using Projeto_DA.Data;
using System;
using System.Linq;

namespace Projeto_DA.Controllers
{
    public class ShoppingListSuggestion
    {
        public int ArticleId { get; set; }
        public string Artigo { get; set; }
        public int VezesComprado { get; set; }
        public decimal QtdSugerida { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal CustoEstimado { get; set; }
    }

    public class DecisionSupportData
    {
        public decimal OrcamentoSugerido { get; set; }
        public int SemanaAtual { get; set; }
        public decimal OrcamentoRestante { get; set; }
        public decimal CustoTotalSugerido { get; set; }
        public System.Collections.Generic.List<ShoppingListSuggestion> ListaSugerida { get; set; }
    }

    public class StatisticsController
    {
        // -------------------------------------------------------------------
        // SEPARADOR 1-A: listagem de todos os meses com orçamento,
        // total de compras e diferença entre os dois
        // -------------------------------------------------------------------
        public dynamic GetEstatisticasMeses()
        {
            using (var context = new AppDbContext())
            {
                // buscamos todos os orçamentos existentes
                var orcamentos = context.Budgets.ToList();

                // para cada orçamento, calculamos o total gasto nesse mês e ano
                var resultado = orcamentos.Select(b =>
                {
                    // somamos o valor total dos itens comprados nesse mês e ano
                    decimal totalGasto = context.PurchaseItems
                        .Where(pi =>
                            pi.Purchase.CreatedDate.Month == b.Month &&
                            pi.Purchase.CreatedDate.Year == b.Year)
                        .Sum(pi => (decimal?)(pi.BoughtQuantity * pi.UnitPrice)) ?? 0;

                    return new
                    {
                        Mês = b.Month,
                        Ano = b.Year,
                        Orçamento = b.Amount,
                        TotalCompras = totalGasto,
                        Diferença = b.Amount - totalGasto
                    };
                })
                .OrderByDescending(x => x.Ano)
                .ThenByDescending(x => x.Mês)
                .ToList();

                return resultado;
            }
        }

        // -------------------------------------------------------------------
        // SEPARADOR 1-B: listagem de todas as compras fechadas com a
        // percentagem de artigos previstos e não previstos
        // -------------------------------------------------------------------
        public dynamic GetEstatisticasCompras()
        {
            using (var context = new AppDbContext())
            {
                // buscamos todas as compras fechadas com os seus itens
                var comprasFechadas = context.Purchases
                    .Include(p => p.PurchaseItems)
                    .Where(p => p.IsClosed)
                    .ToList();

                // para cada compra fechada calculamos as percentagens
                var resultado = comprasFechadas.Select(p =>
                {
                    int totalItens = p.PurchaseItems.Count;

                    // itens previstos são aqueles marcados como IsPlanned = true
                    int previstos = p.PurchaseItems.Count(pi => pi.IsPlanned);

                    // itens não previstos são os restantes
                    int naoPrevistos = totalItens - previstos;

                    // calculamos as percentagens evitando divisão por zero
                    double pctPrevistos = totalItens > 0 ? Math.Round((double)previstos / totalItens * 100, 1) : 0;
                    double pctNaoPrevistos = totalItens > 0 ? Math.Round((double)naoPrevistos / totalItens * 100, 1) : 0;

                    return new
                    {
                        Compra = p.Name,
                        DataFecho = p.ClosedDate.HasValue ? p.ClosedDate.Value.ToString("dd/MM/yyyy") : "-",
                        TotalItens = totalItens,
                        Previstos = previstos,
                        NaoPrevistos = naoPrevistos,
                        PctPrevistos = pctPrevistos,
                        PctNaoPrevistos = pctNaoPrevistos
                    };
                })
                .OrderByDescending(x => x.DataFecho)
                .ToList();

                return resultado;
            }
        }

        // -------------------------------------------------------------------
        // SEPARADOR 2 (Apoio à Decisão):
        // a) Sugestão de orçamento para o próximo mês (média dos anteriores)
        // b) Sugestão de lista de compras com base na semana atual do mês,
        //    tendo em conta as listas feitas nessa mesma semana nos meses anteriores
        // -------------------------------------------------------------------
        public DecisionSupportData GetDecisionSupport()
        {
            using (var context = new AppDbContext())
            {
                // --- PARTE A: sugestão de orçamento ---
                // calculamos a média dos orçamentos de todos os meses anteriores
                decimal orcamentoSugerido = 0;
                if (context.Budgets.Any())
                {
                    orcamentoSugerido = context.Budgets.Average(b => b.Amount);
                    orcamentoSugerido = Math.Round(orcamentoSugerido, 2);
                }

                // --- CALCULAR ORÇAMENTO RESTANTE DO MÊS ATUAL ---
                int mesAtual = DateTime.Now.Month;
                int anoAtual = DateTime.Now.Year;

                var budget = context.Budgets.FirstOrDefault(b => b.Month == mesAtual && b.Year == anoAtual);
                decimal budgetAmount = budget != null ? budget.Amount : 0;

                decimal totalSpent = context.PurchaseItems
                    .Where(pi =>
                        pi.Purchase.CreatedDate.Month == mesAtual &&
                        pi.Purchase.CreatedDate.Year == anoAtual)
                    .Sum(pi => (decimal?)(pi.BoughtQuantity * pi.UnitPrice)) ?? 0;

                decimal orcamentoRestante = Math.Round(budgetAmount - totalSpent, 2);

                // --- PARTE B: sugestão de lista de compras ---
                // determinamos em que semana do mês estamos (1ª, 2ª, 3ª ou 4ª)
                int diaAtual = DateTime.Now.Day;
                int semanaAtual = (diaAtual - 1) / 7 + 1;
                if (semanaAtual > 4) semanaAtual = 4; // tudo depois do dia 28 conta como 4ª semana

                // buscamos todos os itens de compras fechadas (histórico)
                var todosItens = context.PurchaseItems
                    .Include(pi => pi.Purchase)
                    .Include(pi => pi.Article)
                    .Where(pi => pi.Purchase.IsClosed)
                    .ToList(); // carregamos em memória para calcular a semana

                // filtramos apenas os itens comprados na mesma semana do mês nos meses anteriores
                var todosItensSugeridos = todosItens
                    .Where(pi =>
                    {
                        // calculamos em que semana do mês foi feita essa compra no passado
                        int semanaItem = (pi.Purchase.CreatedDate.Day - 1) / 7 + 1;
                        if (semanaItem > 4) semanaItem = 4;
                        return semanaItem == semanaAtual;
                    })
                    .GroupBy(pi => new { pi.ArticleId, pi.Article.Name }) // agrupamos por artigo
                    .Select(g =>
                    {
                        decimal avgQty = (decimal)g.Average(pi => (double)pi.BoughtQuantity);
                        decimal avgPrice = (decimal)g.Average(pi => (double)pi.UnitPrice);
                        avgQty = Math.Round(avgQty, 2);
                        avgPrice = Math.Round(avgPrice, 2);

                        return new ShoppingListSuggestion
                        {
                            ArticleId = g.Key.ArticleId,
                            Artigo = g.Key.Name,
                            VezesComprado = g.Count(),
                            QtdSugerida = avgQty,
                            PrecoMedio = avgPrice,
                            CustoEstimado = Math.Round(avgQty * avgPrice, 2)
                        };
                    })
                    .OrderByDescending(x => x.VezesComprado) // os mais comprados primeiro
                    .ToList();

                // filtramos e preenchemos a lista sugerida de acordo com o orçamento restante
                var listaSugerida = new System.Collections.Generic.List<ShoppingListSuggestion>();
                decimal orcamentoDisponivel = orcamentoRestante;
                decimal custoTotalSugerido = 0;

                foreach (var item in todosItensSugeridos)
                {
                    if (listaSugerida.Count >= 10)
                        break;

                    // se o orçamento total não foi configurado (0), sugerimos normalmente.
                    // se foi configurado, apenas sugerimos se couber no orçamento restante (ou se couber na margem disponível)
                    if (budgetAmount == 0 || orcamentoDisponivel >= item.CustoEstimado)
                    {
                        listaSugerida.Add(item);
                        if (budgetAmount > 0)
                        {
                            orcamentoDisponivel -= item.CustoEstimado;
                        }
                        custoTotalSugerido += item.CustoEstimado;
                    }
                }

                return new DecisionSupportData
                {
                    OrcamentoSugerido = orcamentoSugerido,
                    SemanaAtual = semanaAtual,
                    OrcamentoRestante = orcamentoRestante,
                    CustoTotalSugerido = Math.Round(custoTotalSugerido, 2),
                    ListaSugerida = listaSugerida
                };
            }
        }

        // -------------------------------------------------------------------
        // DASHBOARD (usado pelo MainForm / outros): orçamento do mês atual
        // -------------------------------------------------------------------
        public dynamic GetDashboardData()
        {
            using (var context = new AppDbContext())
            {
                int mesAtual = DateTime.Now.Month;
                int anoAtual = DateTime.Now.Year;

                // total de utilizadores registados
                int totalUtilizadores = context.Users.Count();

                // orçamento definido para o mês atual
                var orcamento = context.Budgets
                    .FirstOrDefault(b => b.Month == mesAtual && b.Year == anoAtual);
                decimal valorOrcamento = orcamento != null ? orcamento.Amount : 0;

                // total gasto no mês atual (soma de todos os itens comprados)
                decimal totalGasto = context.PurchaseItems
                    .Where(pi =>
                        pi.Purchase.CreatedDate.Month == mesAtual &&
                        pi.Purchase.CreatedDate.Year == anoAtual)
                    .Sum(pi => (decimal?)(pi.BoughtQuantity * pi.UnitPrice)) ?? 0;

                return new
                {
                    TotalUsers = totalUtilizadores,
                    BudgetAmount = valorOrcamento,
                    TotalSpent = totalGasto,
                    RemainingBudget = valorOrcamento - totalGasto
                };
            }
        }
    }
}