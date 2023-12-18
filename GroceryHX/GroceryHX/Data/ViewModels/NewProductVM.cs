using System.ComponentModel.DataAnnotations;
using System;
using GroceryHX.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using GroceryHX.Data.Base;

namespace GroceryHX.Models
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
		[Required(ErrorMessage = "Product Name is Required")]
		public string Name { get; set; }

		[Display(Name = "Product Description")]
		[Required(ErrorMessage = "Product Description is Required")]
		public string Description { get; set; }

		[Display(Name = "Product Price in ₹")]
		[Required(ErrorMessage = "Product Price is Required")]
		public double Price { get; set; }

		[Display(Name = "Product ImageURL")]
		[Required(ErrorMessage = "Product ImageURL is Required")]
		public string ImageURL { get; set; }

		[Display(Name = "Product ExpiryDate")]
		[Required(ErrorMessage = "Product ExpiryDate is Required")]
		public DateTime ExpiryDate { get; set; }

		[Display(Name = "Select a Catogary")]
		[Required(ErrorMessage = "Product Catogary is Required")]
		public ProductCatogary ProductCatogary { get; set; }

		//Relationships
		[Display(Name = "Select Country(s)")]
		[Required(ErrorMessage = "Product Country(s) is Required")]
		public List<int> CountryIds { get; set; }

		[Display(Name = "Select a Supplier")]
		[Required(ErrorMessage = "Product Supplier is Required")]
		public int SupplierId { get; set; }

		[Display(Name = "Select a Producer")]
		[Required(ErrorMessage = "Product Producer is Required")]
		public int ProducerId { get; set; }
        
    }
}
