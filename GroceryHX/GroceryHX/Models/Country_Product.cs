namespace GroceryHX.Models
{
    public class Country_Product
    {
        // Relationship between country and product

        //Product Id
        public int ProductId { get; set; }

        //Product Model 
        public Product Product { get; set; }
        //Country Id
        public int CountryId { get; set; } 
        //Country Model
        public Country Country { get; set; }
    }
}
