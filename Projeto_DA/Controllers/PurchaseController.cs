using Microsoft.EntityFrameworkCore;
using Projeto_DA.Data;
using Projeto_DA.Models;
using System;
using System.IO;
using System.Linq;

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
                var currentUser = context.Users.Find(SessionManager.CurrentUserId); // encontramos o usuário atual para registrar quem fechou a compra

                if (p != null)
                {
                    p.IsClosed = true;
                    p.ClosedDate = DateTime.Now; // escrevemos a data de fechamento
                    p.ClosedBy = currentUser;    // escrevemos detalhes de quem fechou a compra
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var p = context.Purchases
                               .Include(purchase => purchase.PurchaseItems)
                               .FirstOrDefault(purchase => purchase.Id == id);
                               
                if (p != null)
                {
                    // Apagamos primeiro todos os items desta compra (para evitar o erro de Foreign Key "FK_PurchaseItems_Purchases_PurchaseId")
                    if (p.PurchaseItems != null && p.PurchaseItems.Any())
                    {
                        context.PurchaseItems.RemoveRange(p.PurchaseItems);
                    }

                    // Agora já podemos apagar a compra em si
                    context.Purchases.Remove(p);
                    context.SaveChanges();
                }
            }
        }

        public void ExportToCSV(string filePath)
        {
            using (var context = new AppDbContext())
            {
                var closedPurchases = context.Purchases
                    .Include(p => p.PurchaseItems)
                        .ThenInclude(pi => pi.Article)
                    .Where(p => p.IsClosed == true)
                    .ToList();

                using (var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // 1. escrevemos a linha de cabeçalho com os nomes exatos exigidos pelo enunciado
                    writer.WriteLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                    // 2. escrevemos cada item de cada compra fechada no ficheiro
                    foreach (var purchase in closedPurchases)
                    {
                        foreach (var item in purchase.PurchaseItems)
                        {
                            string nomeCompra = purchase.Name;
                            string dataCriacao = purchase.CreatedDate.ToString("dd/MM/yyyy HH:mm");
                            string dataFechada = purchase.ClosedDate.HasValue ? purchase.ClosedDate.Value.ToString("dd/MM/yyyy HH:mm") : "";
                            string nomeArtigo = item.Article.Name;
                            string artigoPrevisto = item.IsPlanned ? "Sim" : "Nao";
                            string artigoNaoPrevisto = !item.IsPlanned ? (string.IsNullOrEmpty(item.Notes) ? "Sim" : item.Notes) : "Nao";
                            string qtdPrevista = item.PlannedQuantity.ToString("F2");
                            string qtdAdquirida = item.BoughtQuantity.ToString("F2");
                            string precoUnitario = item.UnitPrice.ToString("F2");

                            string line = $"{nomeCompra};{dataCriacao};{dataFechada};{nomeArtigo};{artigoPrevisto};{artigoNaoPrevisto};{qtdPrevista};{qtdAdquirida};{precoUnitario}";
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}