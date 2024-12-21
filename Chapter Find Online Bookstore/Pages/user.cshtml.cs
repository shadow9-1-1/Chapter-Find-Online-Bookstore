using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_Find_Online_Bookstore.Pages
{
    [Authorize(Roles = "customers")]
    public class userModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        public ApplicationUser? appUser;
        public userModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
            var user = userManager.GetUserAsync(User);
            user.Wait();
            appUser = user.Result;
            
        }
    }
}
