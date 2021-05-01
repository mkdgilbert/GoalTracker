using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class GoalListItem
    {

        public int GoalId { get; set; }

        [Display(Name ="Goal Cost")]
        public decimal GoalCost { get; set; }

        //[Display(Name="Finance Option")]
        //public bool FinanceOption { get; set; }

        //[Display(Name ="Cash Option")]
        //public bool OutOfPocketOption { get; set; }

        [Display(Name = "Name of Goal")]
        public string GoalName { get; set; }

        [Display(Name ="Type of Goal")]
        public string GoalType { get; set; }
        [Display(Name ="Years to Payoff")]
        public double NumberOfYears{ get; set; }
     


        //public int AppUserId { get; set; }
        //public virtual UserInfo AppUser { get; set; }
    }
}
