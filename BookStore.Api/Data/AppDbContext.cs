using BookStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Book>(b =>
            {
                b.Property(p => p.Title).IsRequired().HasMaxLength(250);
                b.Property(p => p.Author).IsRequired().HasMaxLength(150);
                b.Property(p => p.Genre).IsRequired().HasMaxLength(100);
            });

            //seed data
            //modelBuilder.Entity<Book>().HasData(
            //    new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Genre = "Software" },
            //    new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andy Hunt", Genre = "Software" }
            //);
        }
    }
}
