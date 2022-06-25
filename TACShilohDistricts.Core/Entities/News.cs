using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.Enums;

namespace TACShilohDistricts.Core.Entities
{
    public class News : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? NewsPictureUrl { get; set; }

        // navitional property
        public ICollection<Comment>? Comments { get; set; }
    }

    public class Events : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? NewsPictureUrl { get; set; }
        public EventCategory EventCategory { get; set; }
    }
}
