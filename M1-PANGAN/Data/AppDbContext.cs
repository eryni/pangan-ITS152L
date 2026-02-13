using Microsoft.EntityFrameworkCore;
using M1_PANGAN.Models;

namespace M1_PANGAN.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Item> Items => Set<Item>();
    public DbSet<LogEntry> Logs => Set<LogEntry>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Item>().HasIndex(i => i.Code).IsUnique();
        mb.Entity<LogEntry>()
          .Property(l => l.TimestampUtc)
          .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
