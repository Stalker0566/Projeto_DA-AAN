using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_DA.Models
{
    public class ArticleType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Propriedade de navegacao
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
