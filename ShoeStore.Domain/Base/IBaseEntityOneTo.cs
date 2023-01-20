namespace ShoeStore.Domain.Base
{
	public interface IBaseEntityOneTo : IBaseEntity
	{
		public int UserId { get; set; }
	}
}
