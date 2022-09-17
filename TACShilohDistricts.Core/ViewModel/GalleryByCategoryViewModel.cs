using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.DTOs.Gallery;

namespace TACShilohDistricts.Core.ViewModel
{
    public class GalleryByCategoryViewModel
    {
        public IEnumerable<GalleryDto>? Galleries { get; set; }
    }
}
