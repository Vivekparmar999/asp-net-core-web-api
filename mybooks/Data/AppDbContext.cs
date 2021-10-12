using Microsoft.EntityFrameworkCore;
using mybooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks
{
    //  1  add DbCobtext
    public class AppDbContext : DbContext
    {

        //2 adding Constructor
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // 3 adding Sql Table named Props

        public DbSet<Book> Books { get; set; }

        // 4 appsetting.json
        // 5 startup.cs
    }
}
