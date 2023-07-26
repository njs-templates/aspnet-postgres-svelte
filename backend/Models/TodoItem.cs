namespace Backend.Models;

// Models are tables in the database

public class TodoItem
{
	public int ID { get; set; }
	public string Label { get; set; } = string.Empty;
	public bool Completed { get; set; }
}
