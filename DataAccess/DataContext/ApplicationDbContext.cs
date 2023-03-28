using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DbSet<User> users) : base(options)
    {
        Users = users;
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
             new User
             {
                 Id = 1,
                 Name = "Oleg",
                 Password = "123",
                 Role = Role.Administrator
             }
         );
        
        modelBuilder.Entity<Shop>().HasData(
            new Shop
            {
                Id = 1,
                Name = "ООО зеленоглазове такси",
                ManagerId = 1
            }
        );
        
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Хлеб",
                Quantity = 5,
                Price = 45
            }
        );
    }
}