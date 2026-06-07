using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_DA.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public bool IsPlanned { get; set; }
        public decimal PlannedQuantity { get; set; }

        public decimal BoughtQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Notes { get; set; }
    }
}
