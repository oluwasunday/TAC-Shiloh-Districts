using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.Entities;

namespace TACShilohDistricts.Infrastructure.Data
{
    public class TACShilohContext : IdentityDbContext<AppUser>
    {
        public TACShilohContext(DbContextOptions<TACShilohContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Testimony> Testimonies { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<PrayerRequest> PrayerRequests { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<NewsAndEvents> NewsAndEvents { get; set; }
    }
}
