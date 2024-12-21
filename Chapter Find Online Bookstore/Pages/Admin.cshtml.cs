using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Chapter_Find_Online_Bookstore.Pages
{
    [Authorize(Roles = "admin")]
    public class AdminModel : PageModel
    {
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public DataTable Table3 { get; set; }
        public DataTable Table4 { get; set; }
        public int books { get; set; }

        private readonly ILogger<AdminModel> _logger;

        public AdminModel(ILogger<AdminModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Table = t1.GetNewOrders();
            Table1 = t1.GetAllCustomers();
            books=t1.GetBooks().Rows.Count;
            Table2 = t1.ShowTable("Books");
            Table3 = t1.ShowTable("Orders");
            Table4 = t1.ShowTable("Categories");
        }
    }
}
