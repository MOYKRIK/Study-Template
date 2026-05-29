namespace Lab3CrudAPI.Models;

public class Platform
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Manufacturer { get; set; } = "";

    public int ReleaseYear { get; set; }
}