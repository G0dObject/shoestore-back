using ShoeStore.Domain.Base;
using ShoeStore.Domain.Entity.Authorization;

namespace ShoeStore.Domain.Entity
{
	public class Note : IBaseEntityOneTo
	{
		public string Title { get; set; } = string.Empty;
		public string Text { get; set; } = string.Empty;
		public int Id { get; set; }
		public virtual User? User { get; set; }
		public int UserId { get; set; }
	}
}