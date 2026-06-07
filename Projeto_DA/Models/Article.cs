using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_DA.Models
{
    public class Article
    {
        public int ID { get; set;  }
        public string Name { get; set; }

        public int ArticleTypeID { get; set; } 
        public ArticleType ArticleType { get; set; }
    }
}
