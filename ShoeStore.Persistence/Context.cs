
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoeStore.Application.Interfaces;
using ShoeStore.Domain.Entity.Authorization;
using ShoeStore.Domain.Entity.Product;
using ShoeStore.Persistence.EntityTypeConfigurations;
using ShoeStore.Persistent;

namespace ShoeStore.Persistence
{
	public class Context : IdentityDbContext<User, Role, int>, IContext
	{
		public Context(DbContextOptions<Context> contextOptions) : base(contextOptions) { DbInitialize.Initialize(this); }

		public DbSet<Product>? Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductConfigurations());
			base.OnModelCreating(modelBuilder);
		}
	}
}
