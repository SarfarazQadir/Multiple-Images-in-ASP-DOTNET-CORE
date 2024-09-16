using System.ComponentModel.DataAnnotations;

namespace Multiple_Images_in_ASP_DOTNET_CORE.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
