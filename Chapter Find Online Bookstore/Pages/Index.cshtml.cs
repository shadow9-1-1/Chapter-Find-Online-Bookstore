using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class IndexModel : PageModel
    {
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public DataTable Table3 { get; set; }
        public DataTable Table4 { get; set; }

        [BindProperty]
        public string Scearsh { get; set; }
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
        public string Tid { get; set; }
        [BindProperty]
        public string TypeName { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }


        public void OnGet()
        {
            Table = t1.GetBooks();
            Table1 = t1.GetCollection();
            Table2 = t1.ShowTable("Categories");
            Table3 = t1.ShowTable("StaffShow");
            Table4 = t1.ShowTable("Categories");

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
        public IActionResult OnPostTypes()
        {
            return RedirectToPage("/typeinfo", new { Tid = Tid, TypeName = TypeName });
        }
    }
}
