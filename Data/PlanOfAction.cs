using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GoalTracker.Models;

namespace Data
{    
    public class PlanOfAction
    {
        [Key]
        public int PlanId { get; set; }

        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Asset))]
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set;  }

        [ForeignKey(nameof(Goal))]
        public int? GoalId { get; set; }
        public virtual Goal Goal { get; set; }


        [Required]
        public string PlanName { get; set; }

        public decimal RiskRatio 
        {
            get { return Asset.TotalDebt / Asset.TotalAssets; }
        }

        public string Considerations 
        {
            get 
            {
                if (RiskRatio >= 1)
                {
                    return "Safe";
                }
                return "At Risk";
            }
        }
        public decimal Essentials
        {
            get
            {
                return Asset.YearlyIncome * .5m;

            }
        }
        public decimal Discretionary
        {
            get
            {
                return Asset.YearlyIncome * .3m;
            }
        }

        public decimal YearlySaving
        {
            get
            {
                return Asset.YearlyIncome * .2m;
            }
        }
        public decimal MonthlySaving
        {
            get
            {
                return YearlySaving / 12;
            }
        }
    }
}
