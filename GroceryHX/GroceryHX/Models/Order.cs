using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GroceryHX.Models
{
	public class Order
	{
		//Order Table
		//Primary Key
		[Key]
		public int Id { get; set; }

		//User Email
		public string Email { get; set; }

		//User Id
		public string UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public ApplicationUser User { get; set; }
		//OrderItem Model
		public List<OrderItem> OrderItems { get; set; }
	}
}
