using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Assignments
{
    public class EFC1
    {
        static void Main(string[] args)
        {
            //ensuring database was created
            using var db = new BookStoreContext();
            var testCat = new BookCategory {Name = "Action", Description = "Story books", IsActive = true };
            db.Categories.Add(testCat);
            db.SaveChanges();
     
            var result = db.Categories.First();
            Console.WriteLine($"Database created -> Test Category: {result.Name}");
        }
    }
    public class Book
    {
        public int BookId { get; set; }
        public string Title {  get; set; }
        public string ISBN { get; set; }
        public int NumOfPages { get; set; }
        public int YearPublished { get; set; }
        public bool InStock { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Biography { get; set; }
        public DateTime DoB { get; set; }
    }

    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCategory> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=BookStore; Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}
