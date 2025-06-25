namespace CrudApi.NewFolder.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
    }

}
