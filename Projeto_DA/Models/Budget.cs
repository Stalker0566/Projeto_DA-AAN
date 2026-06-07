using System;
using System.Collections.Generic;
using System.Text;


namespace Projeto_DA.Models
{
    public class Budget
    {
        public int ID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }

        public int CreateById { get; set; }
        public User CreatedBy { get; set; }

        public int? ModifiedById { get; set; }
        public User ModifiedBy { get; set; }
    }
}
