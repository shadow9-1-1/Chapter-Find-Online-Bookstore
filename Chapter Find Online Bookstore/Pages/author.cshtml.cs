using Chapter_Find_Online_Bookstore.Model;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class authorModel : PageModel
    {
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public DataTable Table3 { get; set; }
        public DataTable Table4 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string AAid { get; set; }

        [BindProperty]
        public string bookid { get; set; }
        [BindProperty]
        public string categoryid { get; set; }
        [BindProperty]
        public string collectionkid { get; set; }
        [BindProperty]
        public string ccid { get; set; }
        [BindProperty]
        public string Aid { get; set; }


        private readonly ILogger<authorModel> _logger;

        public authorModel(ILogger<authorModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        [BindProperty]
        public string Scearsh { get; set; }

        public void OnGet()
        {
            Table = t1.GetBooksByAuthorID(AAid);
            Table1 = t1.GetCollectionByAuthorID(AAid);
            Table2 = t1.GetAuthorByID(AAid);
        }


        public IActionResult OnPostSubmit()
        {
            return RedirectToPage("/Scearsh", new { Scearsh = Scearsh });
        }

        public IActionResult OnPostBook()
        {

            return RedirectToPage("/bookinfo", new { bookid = bookid, categoryid = categoryid, Aid = Aid });
        }
        public IActionResult OnPostCollection()
        {

            return RedirectToPage("/colleinfo", new { collectionkid = collectionkid, ccid = ccid, Aid = Aid });
        }
    }
}
