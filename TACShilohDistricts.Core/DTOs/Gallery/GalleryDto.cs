using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACShilohDistricts.Core.DTOs.Gallery
{
    public class GalleryDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string? ImageTitle { get; set; }
        public string? PublicId { get; set; }
        public string? Category { get; set; }
    }
}
