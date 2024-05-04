using Microsoft.EntityFrameworkCore;
namespace AppApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<SalePerformanceView> SalesPerformanceView { get; set; } = null!;
    public DbSet<SaleSummaryView> SalesSummaryView { get; set; } = null!;
}