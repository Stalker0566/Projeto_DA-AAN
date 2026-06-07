using System;
using System.Linq;
using Projeto_DA.Data;
using Projeto_DA.Models;

namespace Projeto_DA.Controllers
{
    public class PurchaseController
    {
        public dynamic GetAll()
        {
            using (var context = new AppDbContext())
            {
                // vamos buscar todas as compras e retornar uma lista de objetos anônimos com as informações necessárias
                return context.Purchases
                    .Select(p => new
                    {
                        ID = p.Id, // se você quiser mostrar o ID, caso contrário, pode omitir
                        Nome = p.Name,
                        Data = p.CreatedDate,
                        Estado = p.IsClosed ? "Fechada" : "Aberta" // fechado ou aberto
                    })
                    .OrderByDescending(p => p.Data) // filtrar por data decrescente
                    .ToList();
            }
        }

        public void Add(string name)
        {
            using (var context = new AppDbContext())
            {
                
                var currentUser = context.Users.Find(SessionManager.CurrentUserId);

                var purchase = new Purchase
                {
                    Name = name,
                    CreatedDate = DateTime.Now,
                    IsClosed = false,
                    CreatedBy = currentUser
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();
            }
        }

        public void ClosePurchase(int id)
        {
            using (var context = new AppDbContext())
            {
                var p = context.Purchases.Find(id);
                if (p != null)
                {
                    p.IsClosed = true; // fechamos a compra, marcando o campo IsClosed como true
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var p = context.Purchases.Find(id);
                if (p != null)
                {
                    context.Purchases.Remove(p);
                    context.SaveChanges();
                }
            }
        }
    }
}