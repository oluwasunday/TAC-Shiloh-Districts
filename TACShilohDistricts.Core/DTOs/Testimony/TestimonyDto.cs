using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACShilohDistricts.Core.DTOs.Testimony
{
    public class TestimonyDto
    {
        public string Title { get; set; }
        public string TestifyerName { get; set; }
        public string Description { get; set; }
        public string? TestifyerPictureUrl { get; set; }
        public bool IsApproved { get; set; } = true;
        public string? TestifyerLocation { get; set; }
    }
}
