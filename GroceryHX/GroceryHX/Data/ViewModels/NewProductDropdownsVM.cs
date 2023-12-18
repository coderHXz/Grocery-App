using GroceryHX.Models;
using System.Collections.Generic;

namespace GroceryHX.Data.ViewModels
{
	public class NewProductDropdownsVM
	{
        public NewProductDropdownsVM()
        {
			//Producers = new List<Producer> { new Producer() };
			Producers = new List<Producer>();
			Suppliers = new List<Supplier>();
			Countries = new List<Country>(); 
		}
        public List<Producer> Producers { get; set; }

		public List<Supplier> Suppliers { get; set; }

		public List<Country> Countries { get; set; }

	}
}
