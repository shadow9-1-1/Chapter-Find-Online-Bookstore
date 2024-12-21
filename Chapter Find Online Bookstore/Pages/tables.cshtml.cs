using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Chapter_Find_Online_Bookstore.Pages
{
    [Authorize(Roles = "admin")]
    public class tablesModel : PageModel
    {
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }

        public DataTable Table3 { get; set; }
        public DataTable Table4 { get; set; }
        public DataTable Table5 { get; set; }
        public DataTable Table6 { get; set; }
        public DataTable Table7 { get; set; }
        public DataTable Table8 { get; set; }



        private readonly ILogger<tablesModel> _logger;

        public tablesModel(ILogger<tablesModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        public void OnGet()
        {
            
            //----------------------------------//
            Table = t1.GetAllCustomers();
            Table1 = t1.GetAllAdmins();
            Table2 = t1.GetAllCategories();
            Table3 = t1.GetAllAuthors();
            Table4 = t1.GetAllBooks();
            Table5 = t1.GetAllCollections();
            Table6 = t1.GetAllOrdersWithDetails();
            Table7 = t1.GetAllShippingCosts();

        }
    }
}
