using System.ComponentModel.DataAnnotations;

namespace Multiple_Images_in_ASP_DOTNET_CORE.Models
{
    public class ProductViewModel
    {
        [Key]

        public string Name { get; set; }
        public string Description { get; set; }

        // For uploading multiple images
        public List<IFormFile> Images { get; set; }
    }
}
