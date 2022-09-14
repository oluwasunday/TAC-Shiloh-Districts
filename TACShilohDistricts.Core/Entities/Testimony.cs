namespace TACShilohDistricts.Core.Entities
{
    public class Testimony : BaseEntity
    {
        public string? Title { get; set; }
        public string? TestifyerName { get; set; }
        public string? Description { get; set; }
        public string? TestifyerPictureUrl { get; set; }
        public bool IsApproved { get; set; }
    }
}
