using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Core.Enums;
using TACShilohDistricts.Infrastructure.Data;

namespace TACShilohDistricts.Infrastructure.Seeding
{
    public class TACSeeder
    {
        public static async Task SeedData(TACShilohContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await dbContext.Database.EnsureCreatedAsync();

            List<string> roles = new List<string> { "Admin", "Pastor", "Prophet", "Elder", "Member" };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(new IdentityRole { Name = role });
            }

            if (!dbContext.Galleries.Any())
            {
                List<Gallery> galleries = new List<Gallery> 
                { 
                    new Gallery
                    {
                        Category = "Prophet's teaching ",
                        Id = 1,
                        ImageTitle = "Prophet's teaching",
                        ImageUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/one_empgdi.jpg",
                        PublicId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Gallery
                    {
                        Category = "Oru shiloh - Oct 2022",
                        Id = 2,
                        ImageTitle = "Pastor on pulpit",
                        ImageUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/two_f5xbi0.jpg",
                        PublicId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Gallery
                    {
                        Category = "Oru Shiloh - sep 2022",
                        Id = 3,
                        ImageTitle = "choir",
                        ImageUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/three_cipskw.jpg",
                        PublicId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Gallery
                    {
                        Category = "Men Convention Sep 2022",
                        Id = 4,
                        ImageTitle = "children ministering",
                        ImageUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/four_h7cz5m.jpg",
                        PublicId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Gallery
                    {
                        Category = "Sunday Service - Sunday 22 Sept 2022",
                        Id = 5,
                        ImageTitle = "choir",
                        ImageUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/one_empgdi.jpg",
                        PublicId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Gallery
                    {
                        Category = "Sunday Service - Sunday 22 Sept 2022",
                        Id = 6,
                        ImageTitle = "Pastor Ankewo",
                        ImageUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/three_cipskw.jpg",
                        PublicId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Gallery
                    {
                        Category = "Sunday Service - Sunday 22 Sept 2022",
                        Id = 7,
                        ImageTitle = "Elder Akobi",
                        ImageUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/two_f5xbi0.jpg",
                        PublicId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    }
                };

                await dbContext.Galleries.AddRangeAsync(galleries);
            }

            if (!dbContext.Testimonies.Any())
            {
                List<Testimony> testimonies = new List<Testimony> 
                { 
                    new Testimony
                    {
                        Description = "The blessed my family with a bouncing baby boy. We thank God for safe delivery. Praise the Lord.",
                        Id = Guid.NewGuid().ToString(),
                        IsApproved = true,
                        TestifyerName = "Bro Sunday Oreofe",
                        TestifyerPictureUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/one_empgdi.jpg",
                        Title = "Bouncing baby boy",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        RowVersion = ASCIIEncoding.ASCII.GetBytes("0x0000000000038B8C").ToString(),
                        TestifyerLocation = "Ilorin, Kwara"
            },
                    new Testimony
                    {
                        Description = "The Lord saved my family from a terror of accident. Our car had a failed break, ran into the bush, but God deliver us safely",
                        Id = Guid.NewGuid().ToString(),
                        IsApproved = true,
                        TestifyerName = "Sis Ojo Abimbola",
                        TestifyerPictureUrl = "https://drive.google.com/file/d/1xy0VTl4KrgFX2iKmKQcmn1qeJi77VQZ0/view?usp=sharing",
                        Title = "Saved fro accident",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        RowVersion = ASCIIEncoding.ASCII.GetBytes("0x0000000000038B8C").ToString(),
                        TestifyerLocation = "Iyana Ipaja, Lagos"
                    },
                    new Testimony
                    {
                        Description = "Family breakthrough",
                        Id = Guid.NewGuid().ToString(),
                        IsApproved = true,
                        TestifyerName = "Pastor Okeowo Adele",
                        TestifyerPictureUrl = "https://drive.google.com/file/d/1gDVcMgVD3WPYivRrLVr0l-NRio8uxrpd/view?usp=sharing",
                        Title = "Breakthrough",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        RowVersion = ASCIIEncoding.ASCII.GetBytes("0x0000000000038B8C").ToString(),
                        TestifyerLocation = "Benin, Edo"
                    }
                };

                await dbContext.Testimonies.AddRangeAsync(testimonies);
            }

            if (!dbContext.NewsAndEvents.Any())
            {
                List<NewsAndEvents> newsAndEvents = new List<NewsAndEvents> 
                { 
                    new NewsAndEvents
                    {
                        Description = "The Apostolic Church LAWNA General Thanksgiving date has been scheduled and will be glorious.",
                        Id = Guid.NewGuid().ToString(),
                        NewsPictureUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/one_empgdi.jpg",
                        Title = "Lawna General Thanksgiving 2022",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        RowVersion = DateTime.Now.Ticks.ToString(),
                        EventCategory = EventCategory.Lawna,
                        DateOfEvents = new DateTime(DateTime.Now.Year, 12, 18, 8, 0, 0)
                    },
                    new NewsAndEvents
                    {
                        Description = "The last Shiloh Night (Oru Shiloh) in the year 2022 will be extremely powerful. You can't afford to miss it.",
                        Id = Guid.NewGuid().ToString(),
                        NewsPictureUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/one_empgdi.jpg",
                        Title = "Oru Shiloh, Dec 2022",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        RowVersion = DateTime.Now.Ticks.ToString(),
                        EventCategory = EventCategory.Shiloh,
                        DateOfEvents = new DateTime(DateTime.Now.Year, 12, 2, 20, 0, 0)
                    },
                    new NewsAndEvents
                    {
                        Description = "The blessed my family with a bouncing baby boy. We thank God for safe delivery. Praise the Lord.",
                        Id = Guid.NewGuid().ToString(),
                        NewsPictureUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/one_empgdi.jpg",
                        Title = "Chrismas Carol",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        RowVersion = DateTime.Now.Ticks.ToString(),
                        EventCategory = EventCategory.Shiloh,
                        DateOfEvents = new DateTime(DateTime.Now.Year, 12, 24, 20, 0, 0)
                    }
                };

                await dbContext.NewsAndEvents.AddRangeAsync(newsAndEvents);
            }

            if (!dbContext.AppUsers.Any())
            {
                var user = new AppUser
                {
                    Id = "c180ffc1-d941-4b47-97b2-377baa9e87f7",
                    FirstName = "tacn-shiloh",
                    LastName = "Admin",
                    UserName = "tacnshilohadmin",
                    Email = "tacnshilohdistrict@gmail.com",
                    PhoneNumber = "09043546576",
                    Gender = "Male",
                    Age = 34,
                    IsActive = true,
                    PublicId = Guid.NewGuid().ToString(),
                    PictureUrl = "http://placehold.it/32x32",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(user, "Password@123");
                await userManager.AddToRoleAsync(user, "Admin");
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
