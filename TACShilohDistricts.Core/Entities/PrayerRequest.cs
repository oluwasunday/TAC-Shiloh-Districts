using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACShilohDistricts.Core.Entities
{
    public class PrayerRequest : BaseEntity
    {
        public new int Id { get; set; } 
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [EmailAddress (ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        [MaxLength (100)]
        public string Subject { get; set; }
        [Required]
        public string Request { get; set; }
    }
}
