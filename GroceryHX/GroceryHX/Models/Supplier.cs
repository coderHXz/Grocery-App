using GroceryHX.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GroceryHX.Models
{
    public class Supplier : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Supplier Logo")]
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }

		[Display(Name = "Supplier Name")]
        [Required(ErrorMessage = "Supplier is required")]
        public string Name { get; set; }

		[Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
