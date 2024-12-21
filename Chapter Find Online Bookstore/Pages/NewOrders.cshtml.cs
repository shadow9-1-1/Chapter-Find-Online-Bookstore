using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Chapter_Find_Online_Bookstore.Pages
{
    [Authorize(Roles = "admin")]
    public class NewOrdersModel : PageModel
    {
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public DataTable Table3 { get; set; }

        private readonly ILogger<NewOrdersModel> _logger;

        public NewOrdersModel(ILogger<NewOrdersModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        public void OnGet()
        {
            Table = t1.GetNewOrdersWithDetails();
            
        }
    }
}
