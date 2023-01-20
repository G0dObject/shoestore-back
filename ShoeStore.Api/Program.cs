
using Notes.Persistent.DependencyInjection;
using ShoeStore.Application.Interfaces.Servises;
using ShoeStore.Persistence;
using ShoeStore.Persistent;
using ShoeStore.Persistent.DependencyInjection;

namespace ShoeStore.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbDependency(builder.Configuration);
			builder.Services.AddIdentityDependency();
			builder.Services.AddAuthenticationDependency(builder.Configuration);
			builder.Services.AddAuthorizationBuilderDependency();
			//builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

			_ = builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: "local",
								  policy =>
								  {
									  _ = policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
								  });
			});

			WebApplication app = builder.Build();

			using Context? db = app.Services.CreateScope().ServiceProvider.GetRequiredService<Context>();
			DbInitialize.Initialize(db);

			app.UseCors("local");

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.MapGet("/", () => "Ok");
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}