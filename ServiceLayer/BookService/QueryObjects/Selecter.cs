using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataLayer
{
    // this is the query which will send to the repo pattern 
    public static class Selecter
    {
        public static IQueryable<BookDTO> Map(this IQueryable<Book> books)
        {
            return books.Select(b => new BookDTO
            {
                BookId = b.BookId,
                Title = b.Title,
                PublishedOn = b.PublishedOn,
                Price = b.Price,
                ActualPrice = b.Promotion != null ? b.Promotion.NewPrice : b.Price,
                PromotionPromotionalText = b.Promotion != null ? b.Promotion.TextPromotion : string.Empty,
                ReviewsCount = b.BookReviews.Count,
                AuthorsOrdered = string.Join(",", b.BookAuthors.OrderBy(b => b.Order).Select(b => b.Author).ToList()),
                TagStrings = b.Tags.Select(x => x.TagName).ToArray()
            });
        }
    }
}
