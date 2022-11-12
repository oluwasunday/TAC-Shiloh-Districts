using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.Enums;

namespace TACShilohDistricts.Core.ViewModel
{
    public class NewsAndEventsViewModel
    {
        public NewsAndEventsVM NewsAndEventsById { get; set; }
        public IEnumerable<NewsAndEventsVM> NewsAndEvents { get; set; }
        public IEnumerable<EventCategory> Categories { get; set; }
    }

    public class NewsAndEventsVM
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string NewsPictureUrl { get; set; }
        public EventCategory EventCategory { get; set; }
        public DateTime DateOfEvents { get; set; }
    }
}
