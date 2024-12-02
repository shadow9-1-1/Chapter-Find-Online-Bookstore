using Chapter_Find_Online_Bookstore.Model;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chapter_Find_Online_Bookstore.Pages
{
    public class AddBookModel : PageModel
    {
        

        public string UserError { get; set; }
        [BindProperty]
        public string title { get; set; }
        [BindProperty]
        public string authorID { get; set; }
        [BindProperty]
        public string categoryID { get; set; }
        [BindProperty]
        public string description { get; set; }
        [BindProperty]
        public string Sdescription { get; set; }
        [BindProperty]
        public decimal price { get; set; }
        [BindProperty]
        public int isDiscount { get; set; }
        [BindProperty]
        public decimal discount { get; set; }
        [BindProperty]
        public int inStock { get; set; }
        [BindProperty]
        public int releaseDate { get; set; }
        [BindProperty]
        public int pages { get; set; }
        [BindProperty]
        public int visability { get; set; }
        [BindProperty]
        public string image { get; set; }
        [BindProperty]
        public string id { get; set; }
        [BindProperty]
        public IFormFile ImageFile { get; set; }


        private ILogger<AddBookModel> _logger;
        private dbclass t1;
        public DataTable Table { get; set; }
        public DataTable Table1 { get; set; }
        public DataTable Table2 { get; set; }
        public DataTable Table3 { get; set; }
        public bool output { get; private set; }

        public AddBookModel(ILogger<AddBookModel> logger, dbclass t1)
        {
            _logger = logger;
            this.t1 = t1;
        }
        public void OnGet()
        {
            
            Table = t1.ShowTable("Authors");
            Table1 = t1.ShowTable("Categories");

        }

        /*public IActionResult OnPost()
        {


            id = DateTime.Now.ToString("yyMMddHHmmss");
            output = t1.AddBook(id,title, authorID, categoryID, price, isDiscount, discount, inStock, Sdescription, description, releaseDate, pages, 0, image, visability);
            return RedirectToPage("/Admin");

        }*/

        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            // Generate a unique ID for the book and the image file
            string id = DateTime.Now.ToString("yyMMddHHmmss");
            string fileExtension = Path.GetExtension(ImageFile.FileName);
            string newFileName = $"B_{id}{fileExtension}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", newFileName);

            try
            {
                // Save the image to wwwroot/img folder
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                // Insert the book data into the database
                output = t1.AddBook(id, title, authorID, categoryID, price, isDiscount, discount, inStock, Sdescription, description, releaseDate, pages, 0, newFileName, visability);
                return RedirectToPage("/BooksList");
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
