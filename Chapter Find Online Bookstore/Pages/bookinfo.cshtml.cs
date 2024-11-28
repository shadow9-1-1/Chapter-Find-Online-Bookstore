using Chapter_Find_Online_Bookstore.Model;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class bookinfoModel : PageModel
    {
        [BindProperty]
        public string Scearsh { get; set; }

        [BindProperty(SupportsGet = true)]
        public string bookid { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Aid { get; set; }
        [BindProperty(SupportsGet = true)]
        public string categoryid { get; set; }
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        private readonly ILogger<bookinfoModel> _logger;

        public bookinfoModel(ILogger<bookinfoModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        public void OnGet()
        {
            Table = t1.GetBookByID(bookid);
            Table1 = t1.Similarbooks(Aid, categoryid);
        }

        public IActionResult OnPostSubmit()
        {
            return RedirectToPage("/Scearsh", new { Scearsh = Scearsh });
        }

        public void OnPostBook()
        {

            Table = t1.GetBookByID(bookid);
            Table1 = t1.Similarbooks(Aid, categoryid);
        }
    }
}
