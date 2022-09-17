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
            var baseDir = Directory.GetCurrentDirectory();

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
                        ImageUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/one_empgdi.jpg",
                        PublicId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    },
                    new Gallery
                    {
                        Category = "Sunday Service - Sunday 22 Sept 2022",
                        Id = 7,
                        ImageTitle = "Elder Akobi",
                        ImageUrl = "https://res.cloudinary.com/dkoncept/image/upload/v1663414316/TAC%20Shiloh%20District/one_empgdi.jpg",
                        PublicId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    }
                };

                await dbContext.Galleries.AddRangeAsync(galleries);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
