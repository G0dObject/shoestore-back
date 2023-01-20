using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShoeStore.Domain.Entity.Authorization;
using ShoeStore.Persistence;

namespace Notes.Persistent.DependencyInjection
{
	public static class IdentityInjection
	{
		public static IServiceCollection AddIdentityDependency(this IServiceCollection services)
		{
			IdentityBuilder? builder = services.AddIdentity<User, Role>(option =>
			{
				option.User.RequireUniqueEmail = false;

				option.Stores.MaxLengthForKeys = 128;
				option.User.RequireUniqueEmail = true;
				option.Password.RequireUppercase = false;
				option.Password.RequireNonAlphanumeric = false;
				option.Password.RequireDigit = false;

				option.SignIn.RequireConfirmedPhoneNumber = false;
				option.SignIn.RequireConfirmedEmail = false;
				option.SignIn.RequireConfirmedAccount = false;
			}).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();


			services.AddIdentityCore<User>();
			return services;
		}
	}
}
