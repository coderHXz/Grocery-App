using GroceryHX.Data;
using GroceryHX.Data.Services;
using GroceryHX.Data.Static;
using GroceryHX.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace GroceryHX.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        public ProductsController(IProductsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? page, string sortOrder)
        {
            var allProducts = await _service.GetAllAsync(n => n.Supplier);
            ViewBag.PriceSortParam = string.IsNullOrEmpty(sortOrder) ? "price_desc" : "";

            switch (sortOrder)
            {
                case "price_asc":
                    allProducts = allProducts.OrderBy(p=> p.Price);
                    break;
                case "price_desc":
                    allProducts = allProducts.OrderByDescending(p=> p.Price);
                    break;
                default:
                    break;
            }

            var pagedProducts = await allProducts.ToPagedListAsync(page ?? 1, 3);
            return View(pagedProducts);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString, int ? page)
        {
            var allProducts = await _service.GetAllAsync(n => n.Supplier);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                var pagedResult = filteredResult.ToPagedList(page ?? 1, 3);
                return View("Index", pagedResult);
            }
            var allProductsPaged = allProducts.ToPagedList(page ?? 1, 3);
            return View("Index", allProductsPaged);
        }
        [AllowAnonymous]
        //Details
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }

        //Create
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Suppliers = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
            ViewBag.Producers = new SelectList(productDropdownsData.Producers, "Id", "Name");
            ViewBag.Countries = new SelectList(productDropdownsData.Countries, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();
                ViewBag.Suppliers = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
                ViewBag.Producers = new SelectList(productDropdownsData.Producers, "Id", "Name");
                ViewBag.Countries = new SelectList(productDropdownsData.Countries, "Id", "Name");
                return View(product);
            }
            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                Description = productDetails.Description,
                Price = productDetails.Price,
                ExpiryDate = productDetails.ExpiryDate,
                ImageURL = productDetails.ImageURL,
                ProductCatogary = productDetails.ProductCatogary,
                SupplierId = productDetails.SupplierId,
                ProducerId = productDetails.ProducerId,
                CountryIds = productDetails.Country_Products.Select(n => n.CountryId).ToList(),
            };


            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Suppliers = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
            ViewBag.Producers = new SelectList(productDropdownsData.Producers, "Id", "Name");
            ViewBag.Countries = new SelectList(productDropdownsData.Countries, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();
                ViewBag.Suppliers = new SelectList(productDropdownsData.Suppliers, "Id", "Name");
                ViewBag.Producers = new SelectList(productDropdownsData.Producers, "Id", "Name");
                ViewBag.Countries = new SelectList(productDropdownsData.Countries, "Id", "Name");
                return View(product);
            }
            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteProductAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
