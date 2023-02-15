using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Server.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.AddRepositories();

var Conn = builder.Configuration.GetConnectionString("PSQL");

services.AddDbContext<DatabaseContext>
(opt =>
{
	opt.UseNpgsql(Conn);
	
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
