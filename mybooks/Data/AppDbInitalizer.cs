using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data
{
    public class AppDbInitalizer { 

        public static void Seed(IApplicationBuilder applicationBuilder) 
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any()) {

                    context.Books.AddRange(

                        new Models.Book(){
                            Title ="Book Title",
                            Description = "Book Descption",
                            Isread = true,
                            DateRead = DateTime.Now.AddDays(-10),
                            Rate = 4,
                            Genre = "Biogrpahy",
                            Author = "First Author",
                            CoverUrl = "https/..",
                            DateAdded = DateTime.Now
                        },
                        new Models.Book() {
                            Title = "Book Title 2",
                            Description = "Book Descption 2",
                            Isread = false,
                            Genre = "Biogrpahy",
                            Author = "Second Author",
                            CoverUrl = "https/..",
                            DateAdded = DateTime.Now
                        }
                    
                    );

                    context.SaveChanges();

                }

            }
        }
    
    }
}
