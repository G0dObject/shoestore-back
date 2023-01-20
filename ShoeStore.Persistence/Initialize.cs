using ShoeStore.Persistence;

namespace ShoeStore.Persistent
{
	public class DbInitialize
	{
		public static void Initialize(Context context)
		{
			context.Database.EnsureCreated();
		}
	}
}

