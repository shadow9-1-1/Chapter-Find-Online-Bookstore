using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class allcollectionModel : PageModel
    {
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public DataTable Table3 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ccid { get; set; }

        [BindProperty(SupportsGet = true)]
        public string collectionkid { get; set; }

        [BindProperty]
        public string Scearsh { get; set; }
        [BindProperty]
        public string Aid { get; set; }

        private readonly ILogger<allcollectionModel> _logger;

        public allcollectionModel(ILogger<allcollectionModel> logger, dbclass t1)
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
        }

        public IActionResult OnPostSubmit()
        {
            return RedirectToPage("/Scearsh", new { Scearsh = Scearsh });
        }

        public IActionResult OnPostCollection()
        {

            return RedirectToPage("/colleinfo", new { collectionkid = collectionkid, ccid = ccid, Aid = Aid });
        }
    }
}
