using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data;

namespace Model
{
    public class AssetEdit
    {

        public int AssetId { get; set; }
        [Display(Name = "Appraised Value")]
        public decimal HouseAppraisal { get; set; }

        [Display(Name = "Remaining Balance")]
        public decimal HouseDebt { get; set; }
        [Display(Name ="All Debt Owed")]
        public decimal TotalDebt { get; set; }
        [Display(Name = "Available Funds")]
        public decimal AvailableCash { get; set; }
        [Display(Name = "Yearly Income")]
        public decimal YearlyIncome { get; set; }
        public decimal TotalEquity { get; set; }
        public decimal TotalAssets { get; set; }

    }
}
