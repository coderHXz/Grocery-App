using GroceryHX.Data.Base;
using GroceryHX.Models;

namespace GroceryHX.Data.Services
{
    public class SuppliersService : EntityBaseRepository<Supplier>, ISuppliersService
    {
        public SuppliersService(AppDbContext context) : base(context) { }
        
    }
}
