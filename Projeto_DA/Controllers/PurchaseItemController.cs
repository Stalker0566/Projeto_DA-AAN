using System.Linq;
using Microsoft.EntityFrameworkCore;
using Projeto_DA.Data;
using Projeto_DA.Models;

namespace Projeto_DA.Controllers
{
    public class PurchaseItemController 
    {
        // Получаем все товары конкретной покупки (по её ID)
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
                        Total = pi.BoughtQuantity * pi.UnitPrice
                    }).ToList();
            }
        }

        public void Add(int purchaseId, int articleId, decimal quantity, decimal price)
        {
            using (var context = new AppDbContext())
            {
                var item = new PurchaseItem
                {
                    PurchaseId = purchaseId,
                    ArticleId = articleId,
                    BoughtQuantity = quantity, 
                    UnitPrice = price          
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