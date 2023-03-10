using ShoeStore.Domain.Base;
using ShoeStore.Domain.Entity.Product.Enum;

namespace ShoeStore.Domain.Entity.Product
{
	public class Product : IBaseEntity
	{
		public int Id { get; set; } = 1;
		public decimal? Price { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Manufacturer { get; set; }
		public ProductTypes ProductType { get; set; }
		public ProductCategorys CategoryType { get; set; }
		public string? ImgUrl { get; set; }
	}
}
