using Microsoft.AspNetCore.Mvc;
using Multiple_Images_in_ASP_DOTNET_CORE.Models;

namespace Multiple_Images_in_ASP_DOTNET_CORE.Controllers
{
    public class ProductController : Controller
    {
        private readonly myContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(myContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Create product form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create a new product with images
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new product
                var product = new Product
                {
                    Name = model.Name,
                    Description = model.Description
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // Save images
                if (model.Images != null && model.Images.Count > 0)
                {
                    foreach (var image in model.Images)
                    {
                        // Save the image to wwwroot folder
                        var imagePath = await SaveImageAsync(image);

                        // Save image path to the database
                        var productImage = new ProductImage
                        {
                            ImagePath = imagePath,
                            ProductId = product.Id
                        };

                        _context.ProductImages.Add(productImage);
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("Index"); // Redirect to a product listing page or details
            }

            return View(model);
        }

        private async Task<string> SaveImageAsync(IFormFile image)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return "/images/" + uniqueFileName; // Return the path relative to wwwroot
        }
    }
}
