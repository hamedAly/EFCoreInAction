using System.Collections.Generic;
using System.Linq;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
 

namespace EfCoreInAction.Controllers
{
    public class HomeController : Controller
    {
        private readonly EfDBContext _context;

       
        public HomeController(EfDBContext context)   //#A
        {                                              //#A
            _context = context;                        //#A
        }                                              //#A
        [HttpGet]
        public string Index()            
        {
            _context.Books.Count();
            return "hamed";
        }
    }
}
