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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.AuthorId);

            modelBuilder.Entity<Log>().HasKey(n => n.Id);
        }

        // 3 adding Sql Table named Props

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> BookAuthors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        // 4 appsetting.json
        // 5 startup.cs

        public DbSet<Log> Logs { get; set; }
    }
}
