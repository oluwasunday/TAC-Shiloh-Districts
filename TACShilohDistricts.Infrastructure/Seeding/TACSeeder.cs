using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.Entities;
using TACShilohDistricts.Infrastructure.Data;

namespace TACShilohDistricts.Infrastructure.Seeding
{
    public class TACSeeder
    {
        public static async Task SeedData(TACShilohContext dbContext)
        {
            await dbContext.Database.EnsureCreatedAsync();

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

            await dbContext.SaveChangesAsync();
        }
    }
}
