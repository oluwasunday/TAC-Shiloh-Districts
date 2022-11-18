using System.ComponentModel.DataAnnotations;

namespace TACShilohDistricts.Core.DTOs
{
    public class NewsAndEventsDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string NewsPictureUrl { get; set; }
        public string EventCategory { get; set; }
        public DateTime DateOfEvents { get; set; }
    }
}
