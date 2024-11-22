using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class AuthorsModel : PageModel
    {
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public DataTable Table3 { get; set; }

        [BindProperty]
        public string Scearsh { get; set; }
        [BindProperty]
        public string AAid { get; set; }


        private readonly ILogger<AuthorsModel> _logger;

        public AuthorsModel(ILogger<AuthorsModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }


        public void OnGet()
        {
            Table = t1.GetBooks();
            Table1 = t1.GetCollection();
            Table2 = t1.ShowTable("Categories");
            Table3 = t1.GetAuthors();

        }
        public IActionResult OnPostSubmit()
        {
            return RedirectToPage("/Scearsh", new { Scearsh = Scearsh });
        }
        public IActionResult OnPostAuthor()
        {

            return RedirectToPage("/author", new { AAid = AAid });
        }
    }
}
