using BookdLilitsProject.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookdLilitsProject.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applictaionBulder)
        {
            using (var serviceScope = applictaionBulder.ApplicationServices.CreateScope())
            {
                var contaxt = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!contaxt.Books.Any())
                {
                    contaxt.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUral = "https.....",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2st Book Title",
                        Description = "2st Book Description",
                        IsRead = false,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUral = "https.....",
                        DateAdded = DateTime.Now
                    });

                    contaxt.SaveChanges();
                }
            }
        }
    }
    
}
