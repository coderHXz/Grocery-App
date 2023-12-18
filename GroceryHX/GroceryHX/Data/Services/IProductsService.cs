using GroceryHX.Data.Base;
using GroceryHX.Data.ViewModels;
using GroceryHX.Models;
using System.Threading.Tasks;

namespace GroceryHX.Data.Services
{
    public interface IProductsService : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);

        Task DeleteProductAsync(int id);
    }
}
