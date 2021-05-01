using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class PlanEdit
    {
        public int PlanId { get; set; }
        public int? GoalId { get; set; }

        [Display(Name = "Name of Plan")]
        public string PlanName { get; set; }
        [Display(Name = "Essential Spending")]
        public decimal Essentials { get; set; }
        [Display(Name = "Splurge Money")]
        public decimal Discretionary { get; set; }
        [Display(Name = "Savings Per Year")]
        public decimal YearlySaving { get; set; }
        [Display(Name = "Savings Per Month")]
        public decimal MonthlySaving { get; set; }
        [Display(Name = "Recommendations")]
        public string Considerations { get; set; }
        [Display(Name = "Risk Ratio")]
        public decimal RiskRatio { get; set; }
    }
}
