using Microsoft.EntityFrameworkCore;
using ShoeStore.Domain.Entity.Product;

namespace ShoeStore.Application.Interfaces
{
	public interface IContext
	{
		DbSet<Product>? Products { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
