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
                var p = context.Purchases.Find(id);
                if (p != null)
                {
                    context.Purchases.Remove(p);
                    context.SaveChanges();
                }
            }
        }

        public void ExportToCSV(string filePath)
        {
            using (var context = new AppDbContext())
            {
                // abrimos o contexto e buscamos todas as compras fechadas, incluindo os itens de cada compra e os artigos relacionados para obter os nomes dos artigos
                var closedPurchases = context.Purchases
                    .Include(p => p.PurchaseItems) // puxamos os itens de cada compra
                        .ThenInclude(pi => pi.Article) // puxamos os artigos relacionados a cada item para obter o nome do artigo
                    .Where(p => p.IsClosed == true)
                    .ToList();

                // abrimos  o arquivo para escrita usando StreamWriter, especificando o caminho do arquivo e a codificação UTF-8
                using (var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
                {
                    // 1. escrevemos a linha de cabeçalho com os nomes das colunas, separados por ponto e vírgula
                    writer.WriteLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;Quantidade Adquirida;Preco Unitario;Artigo Previsto;Quantidade Prevista;ArtigoNaoPrevisto/Notas");

                    // 2. passamos por cada compra fechada e, para cada item de compra, extraímos as informações necessárias, formatamos em uma linha separada por ponto e vírgula e escrevemos no arquivo
                    foreach (var purchase in closedPurchases)
                    {
                        foreach (var item in purchase.PurchaseItems)
                        {
                            string nomeCompra = purchase.Name;
                            string dataCriacao = purchase.CreatedDate.ToString("dd/MM/yyyy HH:mm");
                            string dataFechada = purchase.CreatedDate.ToString("dd/MM/yyyy HH:mm"); // se quiser mostrar a data de fechamento, você pode adicionar um campo ClosedDate na entidade Purchase e usar aqui
                            string nomeArtigo = item.Article.Name;
                            string qtdAdquirida = item.BoughtQuantity.ToString();
                            string preco = item.UnitPrice.ToString("F2");
                            string previsto = item.IsPlanned ? "Sim" : "Nao";
                            string qtdPrevista = item.PlannedQuantity.ToString();
                            string notas = item.Notes != null ? item.Notes : "";

                            // colamos todas as informações em uma linha, separando por ponto e vírgula, para seguir o formato CSV
                            string line = $"{nomeCompra};{dataCriacao};{dataFechada};{nomeArtigo};{qtdAdquirida};{preco};{previsto};{qtdPrevista};{notas}";

                            writer.WriteLine(line); // escrevemos a linha no arquivo
                        }
                    }
                }
            }
        }
    }
}