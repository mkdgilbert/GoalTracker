using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class GoalCreate
    {
        public decimal GoalCost { get; set; }
        //public bool FinanceOption { get; set; }
        //public bool OutOfPocketOption { get; set; }

        [Display(Name ="Goal Name")]
        [MinLength(4, ErrorMessage = "Please enter at least 4 characters.")]
        [MaxLength(35, ErrorMessage = "There are too many characters in this field. Max 35 char.")]
        public string GoalName { get; set; }

        [Display(Name = "Type of Goal")]
        public string GoalType { get; set; }
        [Display(Name = "Years to Payoff")]
        public double NumberOfYears { get; set; }
        [Display(Name = "Interest Rate")]
        public float InterestRate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CompoundInterest { get; set; }

    }
}
