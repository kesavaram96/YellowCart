using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YellowCart.Models
{
    public class ShippingAddress
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
    }
}
