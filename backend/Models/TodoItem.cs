using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class TodoItem
{
	public int ID { get; set; }
	public string Label { get; set; } = string.Empty;
	public bool Completed { get; set; }
}
