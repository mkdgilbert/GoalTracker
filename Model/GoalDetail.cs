using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class GoalDetail
    {
        public int GoalId { get; set; }

        [Display(Name="Cost of Goal")]
        public decimal GoalCost { get; set; }

        //[Display(Name ="Finance Option")]
        //public bool FinanceOption { get; set; }
        //[Display(Name ="Cash Option")]
        //public bool OutOfPocketOption { get; set; }
        [Display(Name ="Goal Name")]
        public string GoalName { get; set; }

        [Display(Name ="Type of Goal")]
        public string GoalType { get; set; }

        [Display(Name ="Years to complete")]
        public double NumberOfYears { get; set; }

        [Display(Name = "Interest Rate")]
        public float InterestRate { get; set; }

        [Display(Name = "Total with Interest")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Accrued Interest")]
        public decimal CompoundInterest { get; set; }
    }
}
