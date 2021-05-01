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
    public class UserInfoListItem
    {
        public int UserInfoId { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }

    }
}
