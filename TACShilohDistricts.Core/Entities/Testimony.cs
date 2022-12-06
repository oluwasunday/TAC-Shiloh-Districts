using System.ComponentModel.DataAnnotations;

namespace TACShilohDistricts.Core.Entities
{
    public class Testimony : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string TestifyerName { get; set; }
        [Required]
        public string Description { get; set; }
        public string? TestifyerPictureUrl { get; set; }
        public string? TestifyerLocation { get; set; }
        public bool IsApproved { get; set; } = true;
    }
}
