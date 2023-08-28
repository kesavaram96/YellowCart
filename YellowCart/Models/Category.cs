using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YellowCart.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Sub-Category Name")]
        public string SubCategoryName { get; set; }

    }
}
