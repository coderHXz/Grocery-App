using GroceryHX.Data.Base;
using GroceryHX.Models;

namespace GroceryHX.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context): base(context) { }
    }
}
