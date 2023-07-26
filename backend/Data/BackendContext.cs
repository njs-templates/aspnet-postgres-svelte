using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend;

public class BackendContext : DbContext
{
	public BackendContext(DbContextOptions<BackendContext> options)
	: base(options)
	{
	}

	// Tables here
	public DbSet<TodoItem> TodoItems { get; set; } = null!;
}
