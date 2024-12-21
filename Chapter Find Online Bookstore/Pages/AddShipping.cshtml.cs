using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_Find_Online_Bookstore.Pages
{
    [Authorize(Roles = "admin")]
    public class AddShippingModel : PageModel
    {
        [BindProperty]
        public string CityName { get; set; }
        [BindProperty]
        public decimal Cost { get; set; }
        public bool output { get; private set; }

        private ILogger<AddShippingModel> _logger;
        private dbclass t1;
        public AddShippingModel(ILogger<AddShippingModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            output = t1.AddShippingCost(CityName, Cost);
            return RedirectToPage("/ShippingList");
        }
        
    }
}
