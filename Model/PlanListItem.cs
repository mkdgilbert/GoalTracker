using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class PlanListItem
    {
        public int PlanId { get; set; }
        public int? GoalId { get; set; }
        [Display(Name = "Name of Plan")]
        public string PlanName { get; set; }
        //public decimal Essentials { get; set; }
        //public decimal Discretionary { get; set; }
        //public decimal YearlySaving { get; set; }
        //public decimal MonthlySaving { get; set; }
    }
}
