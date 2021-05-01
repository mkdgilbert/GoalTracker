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
    public class UserInfo
    {
        [Key]
        public int UserInfoId { get; set; }

        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
       
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }


    }
}
