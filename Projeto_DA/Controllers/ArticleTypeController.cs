using System.Collections.Generic;
using System.Linq;
using Projeto_DA.Data;
using Projeto_DA.Models;

namespace Projeto_DA.Controllers
{
    public class ArticleTypeController
    {
        // todas as categorias
        public List<ArticleType> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.ArticleTypes.ToList();
            }
        }

        // adicionar nova categoria
        public void Add(string name)
        {
            using (var context = new AppDbContext())
            {
                context.ArticleTypes.Add(new ArticleType { Name = name });
                context.SaveChanges();
            }
        }

        // update nome da categoria
        public void Update(int id, string newName)
        {
            using (var context = new AppDbContext())
            {
                var category = context.ArticleTypes.Find(id);
                if (category != null)
                {
                    category.Name = newName;
                    context.SaveChanges();
                }
            }
        }

        // delete categoria
        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var category = context.ArticleTypes.Find(id);
                if (category != null)
                {
                    context.ArticleTypes.Remove(category);
                    context.SaveChanges();
                }
            }
        }
    }
}