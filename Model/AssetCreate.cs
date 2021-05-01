using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data;

namespace Model
{
    public class AssetCreate
    {
        
        //[Display(Name = "Type of Property")]
        //public PropertyType PropertyType { get; set; }
        [Display(Name = "Available Funds")]
        public decimal AvailableCash { get; set; }
        [Display(Name = "Yearly Income")]
        public decimal YearlyIncome { get; set; }
       
        [Display(Name ="Appraised Value")]
        public decimal HouseAppraisal { get; set; }

        [Display(Name ="Remaining Balance")]
        public decimal HouseDebt { get; set; }
        
        public decimal TotalDebt { get; set; }
        public decimal TotalEquity { get; set; }
        public decimal TotalAssets { get; set; }

    }
}
