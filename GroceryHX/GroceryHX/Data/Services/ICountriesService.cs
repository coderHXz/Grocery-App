using GroceryHX.Data.Base;
using GroceryHX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryHX.Data.Services
{
    public interface ICountriesService:IEntityBaseRepository<Country>
    {
    }
}
