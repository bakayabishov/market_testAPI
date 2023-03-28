namespace DataAccess.Entities;

public class Shop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public User? Manager { get; set; }
    public int ManagerId { get; set; }
}