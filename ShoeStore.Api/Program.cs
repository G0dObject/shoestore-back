
using Notes.Api.Services;
using Notes.Persistent.DependencyInjection;
using ShoeStore.Application.Interfaces.Servises;
using ShoeStore.Persistence;
using ShoeStore.Persistent;
using ShoeStore.Persistent.DependencyInjection;
using System.Text.Json.Serialization;

namespace ShoeStore.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			_ = builder.Services.AddControllers()
	.AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbDependency(builder.Configuration);
			builder.Services.AddIdentityDependency();
			builder.Services.AddAuthenticationDependency(builder.Configuration);
			builder.Services.AddAuthorizationBuilderDependency();
			builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

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
			app.MapGet("/", () => "Server is on");
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}