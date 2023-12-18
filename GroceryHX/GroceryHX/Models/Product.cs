using System.ComponentModel.DataAnnotations;
using System;
using GroceryHX.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using GroceryHX.Data.Base;

namespace GroceryHX.Models
{
    public class Product : IEntityBase
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Name of the Product
        public string Name { get; set; }

        // Description of the Product
        public string Description { get; set; }

        // Price of the Product
        public double Price { get; set; }

        //ImageUrl of the Product
        public string ImageURL { get; set; }

        //Expiry date of the product
        public DateTime ExpiryDate { get; set; }

        // Category of the Product
        public ProductCatogary ProductCatogary { get; set; }

        //Relationships
        public List<Country_Product> Country_Products { get; set; }

        //Supplier
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
