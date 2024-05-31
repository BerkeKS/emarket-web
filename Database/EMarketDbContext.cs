using emarket.Models;
using Microsoft.EntityFrameworkCore;

public class EMarketDbContext : DbContext
{
    public EMarketDbContext(DbContextOptions<EMarketDbContext> options) : base(options)
    {
        
    }
    public DbSet<ItemViewModel> Items {get; set;}
    public DbSet<UserViewModel> Users {get; set;}
    public DbSet<OrderViewModel> Orders {get; set;}
}