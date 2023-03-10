using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoeStore.Domain.Entity.Authorization;

namespace ShoeStore.Persistence.EntityTypeConfigurations
{
	public class UserTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasData(new User() { Email = "Aboba1@gmail.com", Id = 1, UserName = "Aboba1", PasswordHash = "AQAAAAIAAYagAAAAECiWytxSs+RvEN4fJnChfbvrQat/dpiH724CwqKVtqrpp0n5aX9K0cdM2K4zKPnP8g==", SecurityStamp = "TVX5SLPVMQLTGF7SPP6QHUMTZ23MYV76", NormalizedEmail = "ABOBA1@GMAIL.COM", NormalizedUserName = "ABOBA1" });
		}
	}
}
