using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class GoalEdit
    {
        public int GoalId { get; set; }
        public decimal GoalCost { get; set; }
        //public bool FinanceOption { get; set; }
        //public bool OutOfPocketOption { get; set; }
        public string GoalName { get; set; }
        public string GoalType { get; set; }
        public double NumberOfYears { get; set; }
        [Display(Name = "Interest Rate")]
        public float InterestRate { get; set; }
        [Display(Name = "Total with Interest")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Accrued Interest Amount")]
        public decimal CompoundInterest { get; set; }

    }
}
