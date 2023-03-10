using ShoeStore.Persistence;

namespace ShoeStore.Persistent
{
	public class DbInitialize
	{
		public static async void Initialize(Context context)
		{
			//context.Database.EnsureDeleted();
			context.Database.EnsureCreated();
		}
	}
}

