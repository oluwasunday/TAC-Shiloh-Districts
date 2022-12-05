using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACShilohDistricts.Core.Entities
{
    public class PrayerRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrayerRequestId { get; set; }
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
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        
        public string? RowVersion { get; set; } = "row-" + DateTime.Now.Ticks.ToString();
    }
}
