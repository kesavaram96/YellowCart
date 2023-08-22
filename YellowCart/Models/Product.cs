using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YellowCart.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        public string ProductName { get; set; }

        public string Description { get; set; }
        [Required]

        public int Price { get; set; }
    
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
