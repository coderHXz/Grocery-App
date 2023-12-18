using GroceryHX.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GroceryHX.Models
{
    public class Producer : IEntityBase
    {
        //Primary Key For Producer Table
        [Key]
        public int Id { get; set; }

        //Image of the Producer
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image is Required")]
        public string ProfilePictureURL { get; set; }

        //Name of the Producer
		[Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        //Details of the Producer
		[Display(Name = "Detail")]
        [Required(ErrorMessage = "Details is Required")]
        public string Details { get; set; }

        //Relationships
        public List<Product> Products { get; set; }
    }
}
