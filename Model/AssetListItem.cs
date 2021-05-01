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
    public class AssetListItem
    {
        public int AssetId { get; set; }
        //[Display(Name = "Type of Property")]
        //public PropertyType PropertyType { get; set; }
        [Display(Name = "Available Funds")]
        public decimal AvailableCash { get; set; }
        [Display(Name = "Yearly Income")]
        public decimal YearlyIncome { get; set; }
    }
}
