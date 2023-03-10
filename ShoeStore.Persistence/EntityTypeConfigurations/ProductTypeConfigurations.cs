
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeStore.Domain.Entity.Product;
using ShoeStore.Domain.Entity.Product.Enum;
using System.Xml.Linq;

namespace ShoeStore.Persistence.EntityTypeConfigurations
{
	public class ProductTypeConfigurations : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			_ = builder.HasKey(e => e.Id);
			_ = builder.Property(e => e.CategoryType);
			_ = builder.Property(e => e.ProductType);
			_ = builder.Property(e => e.ImgUrl);
			_ = builder.HasData(new Product()
			{
				Id = 1,
				Description = "f",
				Manufacturer = "2",
				Name = "2",
				Price = 2,
				CategoryType = ProductCategorys.Kids,
				ProductType = ProductTypes.Keds,

			},
			new Product()
			{
				Id = 2,
				Description = "f",
				Manufacturer = "2",
				Name = "2",
				Price = 2,
				CategoryType = ProductCategorys.Man,
				ProductType = ProductTypes.Keds
			}); ;

		}

	}
}
