using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.Enums;

namespace TACShilohDistricts.Core.Entities
{
    public class News : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string NewsPictureUrl { get; set; }

        // navitional property
        public ICollection<Comment>? Comments { get; set; }
    }

    public class Events : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string NewsPictureUrl { get; set; }
        public EventCategory EventCategory { get; set; }
    }
}
