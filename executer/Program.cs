
using Microsoft.EntityFrameworkCore;
using DataLayer;

var dbcontextOptionBuilder = new  DbContextOptionsBuilder<EfDBContext>();

string connectionString = "";
connectionString ="Server=.\\; Database = EfCoreInActionDb; Trusted_Connection = True;TrustServerCertificate=True; User ID = haly; pwd = 123";
// use UseLazyLoadingProxies() extention method when configure lazy loading for entities
dbcontextOptionBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
 EfDBContext _efdbContext = new EfDBContext(dbcontextOptionBuilder.Options);
using (_efdbContext)
{
    var count =_efdbContext.Books.Count();
    // as no tracking dosen't track the element in the list 
    var listofBooks = _efdbContext.Books.AsNoTracking().ToList();
    // get related data using include 
    var relatedDate = _efdbContext.Books.AsNoTracking().Include(c => c.BookReviews.Where(r=>r.ReviewId==2)).FirstOrDefault();
    // by default the related data dosn't quered else you request it 

    //get related data using eager loading and get related data using thenInclude 
    var GetRelatedDataUsingInClude = _efdbContext.Books.AsNoTracking().Include(r => r.BookAuthors).ThenInclude(a=>a.Author).ToList();

    // get related date if exist if case relation one to one or one to zero  if zero the object return with null
    var getRelatedDataIfExist = _efdbContext.Books.AsNoTracking().Include(b=>b.Promotion).ToList();


    // get all related data for the book
    // related to promotion one to one 
    // related to Reviews one to many 
    // related to Authors many to many 

    var getRelatedDataToTheBook = _efdbContext.Books
        .Include(p => p.Promotion)
        .Include(R => R.BookReviews)
        .Include(b => b.BookAuthors)
        .ThenInclude(Au => Au.Author)
        .ToList();
    var GerRelatedDataAndUsingOrder = _efdbContext.Books.AsNoTracking().Include(b => b.BookAuthors.OrderBy(x => x.Order)).ToList();
    Console.WriteLine(count);


    // Excplict loading

    // first Get the primary data
    var book = _efdbContext.Books.FirstOrDefault();
    

    // then get the related collectoin data without assign to any variables  
    // if primary entity linked to list use collection
    // if primary entity linked to one object use reference 
    // then call the method load
    
    _efdbContext.Entry(book).Collection(b => b.BookAuthors).Load();
    foreach (var bookAuthor in book.BookAuthors)
    {
        // you can load the relationship 
        _efdbContext.Entry(bookAuthor).Reference(bookAuthor => bookAuthor.Author).Load();
        
    }
    var boo = _efdbContext.Entry(book).Collection(b => b.BookReviews).Query().Where(review=>review.Comment=="Nice book").ToList();


    // the third type is select loading 

    var _book = _efdbContext.Books.Select(b => new
    {
        b.Title,
        b.BookId,
        reviewsNo = b.BookReviews.Count()
    }).ToList();


    // the fourth way lazy loading
    // after configure the entity navigational property with virtial and use uselazyLoadingProxies extention method
    var lazybook = _efdbContext.Books.FirstOrDefault();
    var reviews = lazybook.BookReviews.ToList();



    // client vs server evaluation cod e
    var clientVsServerEval = _efdbContext.Books.Select(book => new
    {
        book.BookId,
        book.Title,
        _bookReviews = string.Join(", ", book.BookReviews.Select(review => review.Comment).ToList())
    });
    foreach (var item in clientVsServerEval)
    {
        Console.WriteLine(item.Title + " " + item._bookReviews);
    }

    var bookssss= _efdbContext.Books.Map().FilterBy(FilterByOptions.NoFilter).Sort(OrderByOption.ByVote).ToList();
    
}

Console.ReadKey();




