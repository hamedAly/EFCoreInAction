using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace DataLayer
{
    // apply query object ( send query object to function to apply linq operator )
    // using extention method to build chain 


    public enum OrderByOption
    {
        [Display(Name = "sort by...")]
        SimplerOrder,
        [Display(Name = "Votes ↑")]
        ByVote,
        [Display(Name = "Publication Date ↑")]  
        ByPublicationDate,
        [Display(Name = "Price ↓")]
        ByPriceLowestFirst,
        [Display(Name = "Price ↑")]
        ByPriceHigestFirst
    }
    public static class Sorter
    {
        public static IQueryable<BookDTO> Sort (this IQueryable<BookDTO> books , OrderByOption OrderByoption)
        {
            switch (OrderByoption)
            {
                case OrderByOption.SimplerOrder:
                    return books.OrderByDescending(x => x.BookId);
                     
                case OrderByOption.ByVote:
                    return books.OrderByDescending(x => x.ReviewsAverageVotes);
                     
                case OrderByOption.ByPublicationDate:
                    return books.OrderByDescending(x => x.PublishedOn);
                    
                case OrderByOption.ByPriceLowestFirst:
                    return books.OrderBy(x => x.Price);

                case OrderByOption.ByPriceHigestFirst:
                    return books.OrderByDescending(x => x.Price);
                default:
                    throw
                       new ArgumentOutOfRangeException(nameof(OrderByoption), OrderByoption, null);
            }
           
        }
    }
}
