using Microsoft.AspNetCore.Identity;
using ShoeStore.Domain.Base;

namespace ShoeStore.Domain.Entity.Authorization
{
	public class User : IdentityUser<int>, IBaseEntity
	{

	}
}