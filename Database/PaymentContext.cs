namespace DataManager.Database;

using Microsoft.EntityFrameworkCore;
using DataManager.Models.Entities;

public class PaymentContext : DbContext
{
    private readonly string _connectionString;

    public PaymentContext() :base()
    {
        _connectionString = "";
    }

    public PaymentContext(string connectionString) : base()
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(_connectionString);
    }

    public DbSet<PaymentItem> PaymentItems { get; set; }
}