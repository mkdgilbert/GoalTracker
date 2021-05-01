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
    //public enum PropertyType 
    //{
    //    House = 1,
    //    Car,
    //    Boat,
    //}
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        [Required]
        public decimal HouseAppraisal { get; set; }

        [Required]
        public decimal HouseDebt { get; set; }
        [Required]
        public decimal TotalDebt { get; set; }
        [Required]
        public decimal AvailableCash { get; set; }
        [Required]
        public decimal YearlyIncome { get; set; }
       
        public decimal TotalEquity
        {
            get { return HouseAppraisal - HouseDebt; }
        }
        public decimal TotalAssets 
        {
            get { return TotalEquity + AvailableCash; }
        }


        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
