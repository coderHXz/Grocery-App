using GroceryHX.Data;
using GroceryHX.Data.Services;
using GroceryHX.Data.Static;
using GroceryHX.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace GroceryHX.Controllers
{
	[Authorize(Roles = UserRoles.Admin)]
	public class SuppliersController : Controller
    {
        private readonly ISuppliersService _service;
        public SuppliersController(ISuppliersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allSuppliers = await _service.GetAllAsync();
            return View(allSuppliers);
        }

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Supplier supplier)
		{
			if (!ModelState.IsValid) return View(supplier);
			await _service.AddAsync(supplier);
			return RedirectToAction(nameof(Index));
		}
		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
        {
            var supplierDetails = await _service.GetByIdAsync(id);
            if (supplierDetails == null) return View("NotFound");
            return View(supplierDetails);
        }

		public async Task<IActionResult> Edit(int id)
		{
			var supplierDetails = await _service.GetByIdAsync(id);
			if (supplierDetails == null) return View("NotFound");
			return View(supplierDetails);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id,[Bind("Id,Logo,Name,Description")] Supplier supplier)
		{
			if (!ModelState.IsValid) return View(supplier);
			await _service.UpdateAsync(id, supplier);
			return RedirectToAction(nameof(Index));
		}

        public async Task<IActionResult> Delete(int id)
        {
            var supplierDetails = await _service.GetByIdAsync(id);
            if (supplierDetails == null) return View("NotFound");
            return View(supplierDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var supplierDetails = await _service.GetByIdAsync(id);
            if (supplierDetails == null) return View("NotFound");

            
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
