using System.ComponentModel.DataAnnotations;

namespace Multiple_Images_in_ASP_DOTNET_CORE.Models
{
    public class ProductImage
    {
        [Key]

        public int Id { get; set; }
        public string ImagePath { get; set; }

        // Foreign key for the related product
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
