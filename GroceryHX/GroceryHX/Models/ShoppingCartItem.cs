using System.ComponentModel.DataAnnotations;

namespace GroceryHX.Models
{
	public class ShoppingCartItem
	{
		// Shopping cart table 
		//Primary key 
		[Key]
		public int Id { get; set; }

		//Prouduct Model
		public Product Product { get; set; }

		//Amount 
		public int Amount { get; set; }

		//Shopping cart Id
		public string ShoppingCartId { get; set; }
	}
}
