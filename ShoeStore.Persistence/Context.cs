
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Application.Interfaces;
using ShoeStore.Domain.Entity.Authorization;
using ShoeStore.Domain.Entity.Product;
using ShoeStore.Persistence.EntityTypeConfigurations;

namespace ShoeStore.Persistence
{
	public class Context : IdentityDbContext<User, Role, int>, IContext
	{

		public Context(DbContextOptions<Context> contextOptions) : base(contextOptions)
		{
			//	base.Database.EnsureDeleted();
			base.Database.EnsureCreated();
		}

		public DbSet<Product>? Products { get; set; }
		public DbSet<User>? Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductTypeConfigurations());
			modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}
