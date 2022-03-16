using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Title = "Title 1",
                            Description = "Description 1",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-10),
                            Rate = 5,
                            Genre = "Fantasy",
                            CoverUrl = "https://www.gstatic.com/webp/gallery/1.jpg",
                            DateAdded = DateTime.Now.AddDays(-10)
                        },
                        new Book
                        {
                            Title = "Title 2",
                            Description = "Description 2",
                            IsRead = false,
                            Genre = "Detective",
                            CoverUrl = "https://www.gstatic.com/webp/gallery/2.jpg",
                            DateAdded = DateTime.Now
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
