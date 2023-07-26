using Backend;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
	.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json", true);

// Add services to the container.

static string createConnectionString()
{
	DotNetEnv.Env.TraversePath().Load();

	string host = "localhost";
	string database = DotNetEnv.Env.GetString("POSTGRES_DB");
	string username = DotNetEnv.Env.GetString("POSTGRES_USER");
	string password = DotNetEnv.Env.GetString("POSTGRES_PASSWORD");

	string output = string.Format
	(
		"Host={0};Database={1};Username={2};Password={3};",
		host, database, username, password
	);

	// string msg = string.Format("Created connection string: {0}", output);
	// Console.WriteLine(msg);

	return output;
}

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: "Default", policy =>
	{
		policy
			.WithOrigins("http://localhost:5173")
			// You may need to change .WithOrigins() to .AllowAnyOrigin()
			// if you host this publicly.
			// .AllowAnyOrigin()
			.WithHeaders("Content-Type", "Authorization", "X-Requested-With")
			.WithMethods("GET", "POST", "PUT", "DELETE");
	});
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BackendContext>(options =>
	options
		.UseNpgsql(createConnectionString())
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
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo v1");
		c.RoutePrefix = "";
	});
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
