using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
 
namespace DataLayer
{
    public class EfDBContext : DbContext
    {
         public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }

        public EfDBContext(DbContextOptions<EfDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(B => new {B.BookId, B.AuthorId});
            modelBuilder.Entity<BookAuthor>().HasOne(b=>b.Book).WithMany(a=>a.BookAuthors).HasForeignKey(b=>b.BookId);
            modelBuilder.Entity<BookAuthor>().HasOne(b => b.Author).WithMany(a => a.BookAuthors).HasForeignKey(b => b.AuthorId);
        }
    }
}