using System.ComponentModel.DataAnnotations;

namespace TACShilohDistricts.Core.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        [Timestamp]
        public string? RowVersion { get; set; }
    }
}
