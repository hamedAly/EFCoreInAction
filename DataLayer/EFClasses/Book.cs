using System;


namespace DataLayer
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public virtual ICollection<Tag> Tags  { get; set; }
        public virtual PriceOffer Promotion { get; set; }
        public virtual ICollection<Review> BookReviews { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
