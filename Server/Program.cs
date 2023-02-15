
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<DatabaseContext>(opt => {
				opt.UseNpgsql(@"Host=hansken.db.elephantsql.com;Username=bdtfzrna;Password=lyDXtGkj1nxguy3l1UOYY8g7DGP7TWO5;Database=bdtfzrna");
			});	

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}