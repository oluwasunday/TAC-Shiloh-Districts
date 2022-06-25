using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACShilohDistricts.Core.Entities
{
    public class ContactUs : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
    }
}
