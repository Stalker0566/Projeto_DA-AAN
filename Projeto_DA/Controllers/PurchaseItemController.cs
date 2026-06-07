using System.Linq;
using Microsoft.EntityFrameworkCore;
using Projeto_DA.Data;
using Projeto_DA.Models;

namespace Projeto_DA.Controllers
{
    public class PurchaseItemController 
    {
        // recebemos o id da compra e devolvemos os itens dessa compra, incluindo o nome do artigo, quantidade, preço unitário e total
        public dynamic GetByPurchase(int purchaseId)
        {
            using (var context = new AppDbContext())
            {
                return context.PurchaseItems
                    .Include(pi => pi.Article)
                    .Where(pi => pi.PurchaseId == purchaseId)
                    .Select(pi => new {
                        ID = pi.Id,
                        Artigo = pi.Article.Name,
                        Quantidade = pi.BoughtQuantity,
                        Preço = pi.UnitPrice,
                        Total = pi.BoughtQuantity * pi.UnitPrice,
                        // adicionamos o tipo do item (previsto ou não previsto) e as notas
                        Tipo = pi.IsPlanned ? "Previsto" : "Não Previsto",
                        Notas = pi.Notes
                    }).ToList();
            }
        }
        // adicionamos um novo item à compra, recebendo o id da compra, id do artigo, quantidade, preço, se é previsto ou não e as notas
        public void Add(int purchaseId, int articleId, decimal quantity, decimal price, bool isPlanned, string notes)
        {
            using (var context = new AppDbContext())
            {
                var item = new PurchaseItem
                {
                    PurchaseId = purchaseId,
                    ArticleId = articleId,
                    // se o item for previsto, a quantidade planejada é a quantidade passada, caso contrário, é zero, pois não há planejamento para itens não previstos
                    PlannedQuantity = isPlanned ? quantity : 0,
                    BoughtQuantity = quantity, // aquilo que realmente foi comprado, que pode ser diferente do planejado, mas para simplificar, vamos assumir que é o mesmo valor passado
                    UnitPrice = price,
                    IsPlanned = isPlanned, // guarda se o item é previsto ou não, o que pode ser útil para análises futuras ou para diferenciar itens na interface do usuário
                    Notes = notes          // guardamos as notas para o item, que podem ser usadas para observações ou detalhes adicionais sobre o item da compra
                };
                context.PurchaseItems.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var item = context.PurchaseItems.Find(id);
                if (item != null)
                {
                    context.PurchaseItems.Remove(item);
                    context.SaveChanges();
                }
            }
        }
    }
}