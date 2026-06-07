using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_DA.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsClosed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ClosedDate { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public int? ModifiedById { get; set; }
        public User ModifiedBy { get; set; }

        public int? ClosedById { get; set; }
        public User ClosedBy { get; set; }

        public List<PurchaseItem> Items { get; set; } = new List<PurchaseItem>();
    }
}
