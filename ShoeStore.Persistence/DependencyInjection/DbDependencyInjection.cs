using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoeStore.Application.Interfaces;
using ShoeStore.Persistence;
using System.Configuration;
using System.Data;

namespace Notes.Persistent.DependencyInjection
{
	public static class DbDependencyInjection
	{
		public static IServiceCollection AddDbDependency(this IServiceCollection services, IConfiguration configuration)
		{
			string _connectionString = configuration.GetConnectionString("Sqlite") ?? throw new ConfigurationErrorsException();
			_ = services.AddDbContext<Context>(opt => { _ = opt.UseSqlite(_connectionString); });

			services.AddScoped<IContext>(provider =>
			   provider.GetService<Context>() ?? new Context(new DbContextOptions<Context>()));


			return services;
		}

	}
}

