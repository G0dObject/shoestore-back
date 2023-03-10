using System.ComponentModel.DataAnnotations;

namespace ShoeStore.Domain.Base
{
	public interface IBaseEntity
	{
		[Key]
		public int Id { get; set; }
	}
}