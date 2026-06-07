using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Projeto_DA.Data;
using Projeto_DA.Models;

namespace Projeto_DA.Controllers
{
    public class ArticleController
    {
        // obter todos os artigos, com opção de filtrar por categoria (tipo de artigo)
        public List<Article> GetAll(int? categoryId = null)
        {
            using (var context = new AppDbContext())
            {
                // vamos buscar os artigos incluindo o tipo de artigo para evitar problemas de carregamento tardio (lazy loading)
                var query = context.Articles.Include(a => a.ArticleType).AsQueryable();

                // Se um categoryId for fornecido e for maior que 0, filtramos os artigos por esse tipo
                if (categoryId.HasValue && categoryId.Value > 0)
                {
                    query = query.Where(a => a.ArticleTypeID == categoryId.Value);
                }

                return query.ToList();
            }
        }

        public void Add(string name, int categoryId)
        {
            using (var context = new AppDbContext())
            {
                context.Articles.Add(new Article { Name = name, ArticleTypeID = categoryId });
                context.SaveChanges();
            }
        }

        public void Update(int id, string newName, int categoryId)
        {
            using (var context = new AppDbContext())
            {
                var article = context.Articles.Find(id);
                if (article != null)
                {
                    article.Name = newName;
                    article.ArticleTypeID = categoryId;
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var article = context.Articles.Find(id);
                if (article != null)
                {
                    context.Articles.Remove(article);
                    context.SaveChanges();
                }
            }
        }
    }
}