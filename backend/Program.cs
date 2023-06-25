using Backend;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var parentFolder = Directory.GetParent(
		Directory.GetCurrentDirectory()
	)
	.ToString();

var config = new ConfigurationBuilder();
config.SetBasePath(parentFolder).AddEnvironmentVariables();
config.Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BackendContext>(options =>
	options
		.UseNpgsql(builder.Configuration.GetConnectionString("BackendContext"))
		.UseSnakeCaseNamingConvention()
		.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
		.EnableSensitiveDataLogging()
);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

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
