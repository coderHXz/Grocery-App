using GroceryHX.Data.Base;
using GroceryHX.Data.Enums;
using GroceryHX.Data.ViewModels;
using GroceryHX.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroceryHX.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ExpiryDate = data.ExpiryDate,
                ProductCatogary = data.ProductCatogary,
                SupplierId = data.SupplierId,
                ProducerId = data.ProducerId
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            //Add Products Origin Country
            foreach (var countryId in data.CountryIds)
            {
                var newcountryProduct = new Country_Product()
                {
                    ProductId = newProduct.Id,
                    CountryId = countryId,
                };
                await _context.Country_Product.AddAsync(newcountryProduct);
            }
            await _context.SaveChangesAsync();  
        }

		public async Task DeleteProductAsync(int id)
		{
			var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
			if (product != null)
			{
				// Remove the product from the context
				_context.Products.Remove(product);

				// Remove any associated country-product relationships
				var countryProducts = _context.Country_Product.Where(cp => cp.ProductId == id);
				_context.Country_Product.RemoveRange(countryProducts);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Countries = await _context.Countries.OrderBy(n => n.Name).ToListAsync(),
                Suppliers = await _context.Suppliers.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = _context.Products
                .Include(s => s.Supplier)
                .Include(p => p.Producer)
                .Include(cp => cp.Country_Products).ThenInclude(c => c.Country)
                .FirstOrDefaultAsync(n => n.Id == id);

            return await productDetails;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync( n=> n.Id == data.Id );

            if (dbProduct != null)
            {

                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.ExpiryDate = data.ExpiryDate;
                dbProduct.ProductCatogary = data.ProductCatogary;
                dbProduct.SupplierId = data.SupplierId;
                dbProduct.ProducerId = data.ProducerId;
               
                await _context.SaveChangesAsync();
            }

            //Remove existing products
            var existingProductsDb = _context.Country_Product.Where( n=> n.ProductId == data.Id ).ToList();
            _context.Country_Product.RemoveRange(existingProductsDb );
            await _context.SaveChangesAsync();

            //Add Products Origin Country
            foreach (var countryId in data.CountryIds)
            {
                var newcountryProduct = new Country_Product()
                {
                    ProductId = data.Id,
                    CountryId = countryId,
                };
                await _context.Country_Product.AddAsync(newcountryProduct);
            }
            await _context.SaveChangesAsync();
        }
    }
}
