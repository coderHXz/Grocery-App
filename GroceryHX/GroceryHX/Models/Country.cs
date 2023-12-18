using GroceryHX.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GroceryHX.Models
{
    // Country_Of_Origins Table
    public class Country:IEntityBase
    {
        //Primary key
        [Key]
        public int Id { get; set; }

        //Imageurl of the country
        [Display(Name ="Country Image url")]
        [Required(ErrorMessage = "Image is Required")]
        public string CountryImageUrl { get; set; }

        //Name of the country
		[Display(Name = "Country Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        // Description of the country
        [Display(Name= "Description")]
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        //Relationships
        public List<Country_Product> Country_Products { get; set; }

        public Supplier Supplier { get; set; }  
    }
}
