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
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime ExpiryDate { get; set; }

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
