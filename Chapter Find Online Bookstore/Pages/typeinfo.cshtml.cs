using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class typeinfoModel : PageModel
    {
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
        [BindProperty]
        public string AAid { get; set; }

        [BindProperty]
        public string Scearsh { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Tid { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TypeName { get; set; }
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public DataTable Table3 { get; set; }
        public DataTable Table4 { get; set; }
        private readonly ILogger<typeinfoModel> _logger;

        public typeinfoModel(ILogger<typeinfoModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Table = t1.booksByCategories(Tid);
            Table1 = t1.CollectionByCategories(Tid);
            Table2 = t1.GetCategoryByID(Tid);
            Table3 = t1.GetAuthorsByCategoryID(Tid);


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

        public IActionResult OnPostAuthor()
        {

            return RedirectToPage("/author", new { AAid = AAid });
        }
    }
}
