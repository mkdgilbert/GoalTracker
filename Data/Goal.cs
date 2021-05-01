using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoalTracker.Models;

namespace Data
{
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }

        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }

        //public virtual PlanOfAction PlanOfAction { get; set; }

        [Required]
        public decimal GoalCost { get; set; }
        //[Required]
        //public bool FinanceOption { get; set; }
        //[Required]
        //public bool OutOfPocketOption { get; set; }
        [Required]
        public string GoalName { get; set; }
        [Required]
        public string GoalType { get; set; }
        [Required]
        public double NumberOfYears { get; set; }
        [Required]
        public float InterestRate { get; set; }

        decimal _calculated;
        public decimal TotalAmount
        {
            get
            {
                if (InterestRate > 0)
                {
                    return _calculated = GoalCost * (decimal)Math.Pow(1 + InterestRate / 100, NumberOfYears);
                }
                return GoalCost;
            }
        }
        public decimal CompoundInterest
        {
            get
            {
                if (TotalAmount > GoalCost)
                { return _calculated - GoalCost; }
                return GoalCost;
            }
        }
    }
}
