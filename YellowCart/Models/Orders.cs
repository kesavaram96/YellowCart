using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YellowCart.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public int Quantitive { get; set; }
    }
}
