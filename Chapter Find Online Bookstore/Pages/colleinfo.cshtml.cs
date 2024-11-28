using Chapter_Find_Online_Bookstore.Model;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class colleinfoModel : PageModel
    {
        [BindProperty]
        public string Scearsh { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ccid { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Aid { get; set; }

        [BindProperty(SupportsGet = true)]
        public string collectionkid { get; set; }


        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        private readonly ILogger<colleinfoModel> _logger;

        public colleinfoModel(ILogger<colleinfoModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        public void OnGet()
        {
            Table = t1.GetCollectionByID(collectionkid);
            Table1 = t1.SimilarCollection(Aid, ccid);
        }



        public IActionResult OnPostSubmit()
        {
            return RedirectToPage("/Scearsh", new { Scearsh = Scearsh });
        }
        public void OnPostCollection()
        {

            Table = t1.GetCollectionByID(collectionkid);
            Table1 = t1.SimilarCollection(Aid, ccid);
        }
    }
}
