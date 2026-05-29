namespace Lab3CrudAPI.Models;

public class Developer
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Country { get; set; } = "";

    public int FoundedYear { get; set; }
}