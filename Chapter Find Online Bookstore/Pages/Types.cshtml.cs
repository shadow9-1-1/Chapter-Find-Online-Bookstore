using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class TypesModel : PageModel
    {
        [BindProperty]
        public string Scearsh { get; set; }
        [BindProperty]
        public string Tid { get; set; }
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public DataTable Table3 { get; set; }
        public DataTable Table4 { get; set; }
        private readonly ILogger<TypesModel> _logger;

        public TypesModel(ILogger<TypesModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        public void OnGet()
        {
            Table4 = t1.ShowTable("Categories");
        }

        public IActionResult OnPostSubmit()
        {
            return RedirectToPage("/Scearsh", new { Scearsh = Scearsh });
        }
        public IActionResult OnPostTypes()
        {
            return RedirectToPage("/typeinfo", new { Tid = Tid });
        }
    }
}
