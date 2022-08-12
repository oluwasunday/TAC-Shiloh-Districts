using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACShilohDistricts.Core.DTOs
{
    public class PrayerRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress (ErrorMessage = "Enter valid email")]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Request { get; set; }
    }
}
