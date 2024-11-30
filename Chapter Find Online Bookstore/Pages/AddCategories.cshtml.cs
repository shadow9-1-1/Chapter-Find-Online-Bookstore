using Chapter_Find_Online_Bookstore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class AddCategoriesModel : PageModel
    {
        [BindProperty]
        public string Username1 { get; set; }
        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public IFormFile ImageFile { get; set; }
        public bool output { get; private set; }

        private ILogger<AddCategoriesModel> _logger;
        private dbclass t1;
        public AddCategoriesModel(ILogger<AddCategoriesModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.AUsername;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            // Generate a unique ID for the book and the image file
            string id = DateTime.Now.ToString("yyMMddHHmmss");
            string fileExtension = Path.GetExtension(ImageFile.FileName);
            string newFileName = $"C_{id}{fileExtension}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", newFileName);

            try
            {
                // Save the image to wwwroot/img folder
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                // Insert the book data into the database
                output = t1.AddCategory(id, name, newFileName);
                return RedirectToPage("/Admin");
            }
            catch (Exception ex)
            {
                // Log the error (you might want to log the specific error in the logger)
                ModelState.AddModelError(string.Empty, "An error occurred while uploading the file or adding the book.");
                return Page();
            }
        }
    }
}
