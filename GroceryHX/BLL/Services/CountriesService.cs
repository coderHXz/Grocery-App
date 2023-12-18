using GroceryHX.Data.Base;
using GroceryHX.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryHX.Data.Services
{
    public class CountriesService : EntityBaseRepository<Country>, ICountriesService
    {
        public CountriesService(AppDbContext context) : base(context) { }
        
    }
}
