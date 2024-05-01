using Microsoft.EntityFrameworkCore;
using CleanModel.Domain.Dto;

namespace CleanModel;

public class AppDbContext : DbContext
{
     public DbSet<ProductDto> Products { get; set; }  = null!;
     public DbSet<MaterialDto> Materials { get; set; }  = null!;
     public DbSet<PhotoAndVideoDto> PhotoAndVideos { get; set; }  = null!;
     public DbSet<CategoryDto> Categories { get; set; }  = null!;
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
            // Конфигурация EF Core для использования базы данных в памяти
        optionsBuilder.UseInMemoryDatabase("InMemoryDb");
     }
}
