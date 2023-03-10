using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Application.Interfaces;
using ShoeStore.Domain.Entity.Product;
using ShoeStore.Domain.Entity.Product.Enum;
using System.Collections.Generic;
using System.Globalization;

namespace ShoeStore.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoeController : ControllerBase
	{
		private IContext _context;
		public ShoeController(IContext context)
		{
			_context = context;
		}
		[HttpGet]
		public List<Product> GetList([FromQuery] ProductCategorys? category, [FromQuery] ProductTypes? type, [FromQuery] string? sortBy)
		{
			Func<Product, object> orderByFunc = new Func<Product, object>(f => f.Id);

			orderByFunc = sortBy switch
			{
				"name" => item => item.Name,
				_ => item => item.Id,

			};

			Console.WriteLine(category);
			IQueryable<Product> _First = _context!.Products!.AsQueryable();
			IOrderedEnumerable<Product> _Sort = _First.OrderBy(orderByFunc);
			IEnumerable<Product> _Category = _Sort.Where(w => w.CategoryType == category);
			IEnumerable<Product> _Type = type == null || type == ProductTypes.All ? _Category : _Category.Where(w => w.ProductType == type);
			List<Product> result = _Type.ToList();
			return result;
		}


		[HttpPost]
		public async Task AddProduct([FromBody] Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync(new CancellationToken());
		}
		[HttpDelete]
		public async Task DeleteProduct(int id)
		{
			_context.Products.Remove(await _context.Products.FindAsync(id));
			await _context.SaveChangesAsync(new CancellationToken());
		}
	}
}