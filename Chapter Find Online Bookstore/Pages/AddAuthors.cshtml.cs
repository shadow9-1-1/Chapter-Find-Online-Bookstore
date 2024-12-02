using Chapter_Find_Online_Bookstore.Model;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class AddAuthorsModel : PageModel
    {
        [BindProperty]
        public string Username1 { get; set; }
        [BindProperty]
        public IFormFile ImageFile { get; set; }

        [BindProperty]
        public string description { get; set; }
        [BindProperty]
        public string name { get; set; }
        [BindProperty]
        public string topCategoryID { get; set; }
        public bool output { get; private set; }
        public DataTable Table1 { get; set; }

        private ILogger<AddAuthorsModel> _logger;
        private dbclass t1;
        public AddAuthorsModel(ILogger<AddAuthorsModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            Username1 = t1.AUsername;
            Table1 = t1.ShowTable("Categories");
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
            string newFileName = $"A_{id}{fileExtension}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", newFileName);

            try
            {
                // Save the image to wwwroot/img folder
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                // Insert the book data into the database
                output = t1.AddAuthors(id, name, topCategoryID, description, newFileName);
                return RedirectToPage("/AuthorsList");
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
