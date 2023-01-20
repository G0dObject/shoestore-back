
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeStore.Domain.Entity.Product;

namespace ShoeStore.Persistence.EntityTypeConfigurations
{
	public class ProductConfigurations : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(e => e.Id);
		}
	}
}
