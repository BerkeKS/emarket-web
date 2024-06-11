using emarket.Models;
using Microsoft.EntityFrameworkCore;

public class EMarketDbContext : DbContext
{
    public EMarketDbContext(DbContextOptions<EMarketDbContext> options) : base(options)
    {
        
    }
    public DbSet<ItemViewModel> Items {get; set;}
    public DbSet<UserViewModel> Users {get; set;}
    public DbSet<OrderItemModel> OrderItems {get; set;}
    public DbSet<OrderUserModel> OrderUsers {get; set;}
}