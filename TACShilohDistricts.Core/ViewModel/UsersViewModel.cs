using TACShilohDistricts.Core.DTOs.AppUserDtos;
using TACShilohDistricts.Core.DTOs.Gallery;
using TACShilohDistricts.Core.DTOs.Testimony;
using TACShilohDistricts.Core.Entities;

namespace TACShilohDistricts.Core.ViewModel
{
    public class UsersViewModel
    {
        public IEnumerable<AddUserResponseDto> AddUserResponse { get; set; }
        public string Email { get; set; }
    }
    
    public class ContactsViewModel
    {
        public IEnumerable<ContactUs> Contacts { get; set; }
        public string Email { get; set; }
    }
    
    public class NewsEventsViewModel
    {
        public IEnumerable<NewsAndEvents> NewsAndEvents { get; set; }
        public string Email { get; set; }
    }
    
    public class PrayerRequestViewModel
    {
        public IEnumerable<PrayerRequest> PrayerRequests { get; set; }
        public string Email { get; set; }
    }
    
    public class TestimonyViewModel
    {
        public IEnumerable<TestimonyDto> Testimonies { get; set; }
        public string Email { get; set; }
    }
    
    public class GalleryViewModel
    {
        public IEnumerable<GalleryDto> Galleries { get; set; }
        public string Email { get; set; }
    }
}
