namespace GroceryHX.Models
{
    public class Country_Product
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CountryId { get; set; } 
        public Country Country { get; set; }
    }
}
