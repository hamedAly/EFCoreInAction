using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int Order { get; set; }
        virtual public Book Book { get; set; }
        virtual public Author Author { get; set; }
    }
}
