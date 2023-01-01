using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace DataLayer
{
    public enum FilterByOptions
    {
        [Display(Name = "All")]
        NoFilter = 0,
        [Display(Name = "By Votes...")]
        ByVotes,
        [Display(Name ="By Tag")]
        ByTags,
        [Display(Name = "By Year published...")]
        ByPublicationYear
    }
    public static class Filter
    {
        public static IQueryable<BookDTO> FilterBy (this IQueryable<BookDTO> books , FilterByOptions filterByOption  , string filterValue="")
        {
            if (string.IsNullOrEmpty( filterValue))
            {
                return books;
            }
            switch (filterByOption)
            {
                
                case FilterByOptions.NoFilter:
                    return books;
                case FilterByOptions.ByVotes:
                    return books.Where(x => x.ReviewsAverageVotes == double.Parse(filterValue));
                case FilterByOptions.ByPublicationYear:
                    return books.Where(x => x.PublishedOn == DateTime.Parse(filterValue));
                case FilterByOptions.ByTags:
                    return books.Where(x => x.TagStrings.Contains(filterValue));
                default:
                    throw new ArgumentOutOfRangeException(nameof(filterByOption), filterByOption, null);
            }
            
        }
    }
}
