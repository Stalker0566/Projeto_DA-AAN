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
                    PlannedQuantity = isPlanned ? quantity : 0,
                    BoughtQuantity = quantity,
                    UnitPrice = price,
                    IsPlanned = isPlanned,
                    Notes = notes
                };
                context.PurchaseItems.Add(item);

                // Atualizar o utilizador que alterou a compra
                var purchase = context.Purchases.Find(purchaseId);
                if (purchase != null)
                {
                    purchase.ModifiedById = SessionManager.CurrentUserId;
                }

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
                    // Atualizar o utilizador que alterou a compra
                    var purchase = context.Purchases.Find(item.PurchaseId);
                    if (purchase != null)
                    {
                        purchase.ModifiedById = SessionManager.CurrentUserId;
                    }

                    context.PurchaseItems.Remove(item);
                    context.SaveChanges();
                }
            }
        }
    }
}